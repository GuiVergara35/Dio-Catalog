using System;

namespace Catalog.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException() : base("This game does not exist on the catalog yet.")
        {

        }
    }
}
