using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway.Example
{
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
                })
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
}
