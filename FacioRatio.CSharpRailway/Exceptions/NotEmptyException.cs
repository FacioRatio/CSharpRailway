using System;

namespace FacioRatio.CSharpRailway
{
    public class NotEmptyException : Exception
    {
        public NotEmptyException(string typeName)
            : base($"{typeName} collection is not empty.")
        {
        }
    }
}
