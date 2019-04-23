using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    public class SzolgaltatasListaException : Exception
    {
        public SzolgaltatasListaException(string uzenet) : base(uzenet)
        {

        }
    }
}
