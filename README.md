# CSharpRailway
A C# Result class with Railway-Oriented extension methods.

# Nuget

[![Nuget](https://img.shields.io/nuget/v/FacioRatio.CSharpRailway.svg)](https://www.nuget.org/packages/FacioRatio.CSharpRailway/) 
[![Nuget](https://img.shields.io/nuget/dt/FacioRatio.CSharpRailway.svg)](https://www.nuget.org/packages/FacioRatio.CSharpRailway/)

# List of Methods

Unless specified otherwise, all methods only perform on successful Results and otherwise pass the failure down the pipeline.
Most methods work with both synchronous and asynchronous inputs and outputs.

**Method** | **From->To** | **Description**
--- | --- | ---
```Bind``` | ```Result<T>``` -> ```Result<U>``` | Transform a Result to another Result type.
```Bind``` | ```Result<(T, U)>``` -> ```Result<V>``` | Same
```Bind``` | ```Result<(T, U, V)>``` -><br/>```Result<W>``` | Same
```Bind``` | ```Result<(T, U, V, W)>``` -><br/>```Result<X>``` | Same
```Bind``` | ```Result<(T, U, V, W, X)>``` -><br/>```Result<Y>``` | Same
```BindTuple``` | ```Result<T>``` -><br/>```Result<(T, U)>``` | Bind and return a Tuple with the original value.
```BindTuple``` | ```Result<(T, U)>``` -><br/>```Result<(T, U, V)>``` | Same
```BindTuple``` | ```Result<(T, U, V)>``` -><br/>```Result<(T, U, V, W)>``` | Same
```BindTuple``` | ```Result<(T, U, V, W)>``` -><br/>```Result<(T, U, V, W, X)>``` | Same
```Tee``` | ```Result<T>``` -> ```Result<T>``` | Act on a Result and preserve the original Result.
```Combine``` | ```Result<T>, Result<U>``` -><br/>```Result<V>``` | Combine two Results into an aggregate Result.
```Empty``` | ```Result<T>``` -> ```Result<Empty>``` | Transform a Result into an Empty Result.
```Each``` | ```List<T>``` -> ```Result<Empty>``` | Act on each element in a list and return an aggregate Empty Result.
```Filter``` | ```Result<List<T>>``` -><br/>```Result<List<T>>``` | Filter a list Result into a smaller-sized list Result of the same type.
```Map``` | ```Result<List<T>>``` -><br/>```Result<List<U>>``` | Transform a list Result into a same-sized list Result of another type.
```Reduce``` | ```Result<List<T>>``` -><br/>```Result<U>``` | Reduce a list Result into a single Result of another type.
```First``` | ```Result<List<T>>``` -> ```Result<T>``` | Retrieve the first item in a list Result.
```FirstOrDefault``` | ```Result<List<T>>``` -> ```Result<T>``` | Retrieve the first or default item in a list Result.
```Last``` | ```Result<List<T>>``` -> ```Result<T>``` | Retrieve the last Result in a list Result.
```NotAny``` | ```Result<List<T>>``` -><br/>```Result<Empty>``` | Verify a list Result is empty.
```UnfailIf``` | ```Result<Empty>``` -><br/>```Result<Empty>``` | Specify a condition to convert a failure Result into a success Result.
```ValueOrFallback``` | ```Result<T>``` -> ```T``` | Retrieve the value of a Result.
```OnFailure``` | ```Result<T>``` -> ```Result<T>``` | Act on the error of a failure Result.
```OnBoth``` | ```Result<T>``` -> ```Result<T>``` | Act on both success and failure Results and preserve the original Result.

# Example

Note that only a single (and sometimes optional) await is needed at the beginning of the pipeline.

```csharp
class Program
{
    static async Task Main(string[] args)
    {
        var db = new Database();

        var result1 = args
            .Each(s => Log(s))
            .Bind(_ => db.GetAll())
            .First()
            .Tee(thing => Log($"Retrieved {thing.Name}."))
            .Empty();

        var result2 = await db.Create(new Thing(4, "Android"))
            .BindTuple(android => db.Create(new Thing(5, "Book")))
            .Tee((android, book) => Log($"Created {android.Name} and {book.Name}."))
            .Bind(_ => db.GetAll())
            .Map(thing =>
            {
                var renamedThing = thing with { Name = $"My {thing.Name}" };
                return db.Update(renamedThing)
                    .Tee(_ => Log($"Updated {thing.Id} from {thing.Name} to {renamedThing.Name}."));
            }, ignoreFails: false)
            .Tee(myThings => Log("Updated everything (won't see this)."))
            .Empty()
            .OnFailure(ex => Log(ex.ToString()));

        var result = result1
            .Combine(result2)
            .UnFailIf(ex => ex.GetType() == typeof(TimeoutException))
            .Tee(_ => Log("Something took too long but that's okay."));
    }

    public static Result<Empty> Log(string message)
    {
        Console.WriteLine(message);
        return Result.Ok();
    }
}

class Database
{
    public Task<Result<List<Thing>>> GetAll()
    {
        var result = new List<Thing>()
        {
            new Thing(1, "Universe"),
            new Thing(2, "Planet"),
            new Thing(3, "Spaceship"),
            new Thing(4, "Android"),
            new Thing(5, "Book"),
        };
        return Task.FromResult(Result.Ok(result));
    }

    public Task<Result<Thing>> Create(Thing thing)
    {
        return Task.FromResult(Result.Ok(thing));
    }

    public Task<Result<Thing>> Update(Thing thing)
    {
        if (thing.Id == 1)
        {
            return Task.FromResult(Result.Fail<Thing>(new TimeoutException($"Update for {thing.Id} {thing.Name} took too long.")));
        }
        return Task.FromResult(Result.Ok(thing));
    }
}

record Thing(int Id, string Name);
```

## License

Licensed under the [MIT License](https://github.com/FacioRatio/CSharpRailway/blob/master/LICENSE).