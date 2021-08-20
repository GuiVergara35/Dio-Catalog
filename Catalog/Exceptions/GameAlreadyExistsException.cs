using System;

namespace Catalog.Exceptions
{
    public class GameAlreadyExistsException : Exception
    {
        public GameAlreadyExistsException() : base("This game already exists on the catalog.") { }
    }
}
