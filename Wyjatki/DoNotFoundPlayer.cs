using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Wyjatki
{
    public class DoNotFoundPlayer : Exception
    {
        public DoNotFoundPlayer()
        {
        }

        public DoNotFoundPlayer(string message) : base(message)
        {
        }

        public DoNotFoundPlayer(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
