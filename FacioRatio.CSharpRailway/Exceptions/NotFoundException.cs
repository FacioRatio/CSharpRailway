using System;

namespace FacioRatio.CSharpRailway
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string typeName)
            : base($"{typeName} collection is empty.")
        {
        }
    }
}
