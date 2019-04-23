using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    public class SzolgaltatasListaBejaro<T> : IEnumerator
    {
        ListaElem<T> fej;
        ListaElem<T> aktualis;

        public SzolgaltatasListaBejaro(ListaElem<T> fej)
        {
            this.fej = fej;
            aktualis = null;
        }

        public object Current
        {
            get
            {
                if(aktualis == null)
                {
                    return null;
                }
                return aktualis.ertek;
            }
        }

        public bool MoveNext()
        {
            if(aktualis == null && fej.kovetkezo != null)
            {
                aktualis = fej.kovetkezo;
                return true;
            }
            if(aktualis.kovetkezo != null)
            {
                aktualis = aktualis.kovetkezo;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            aktualis = null;
        }
    }
}
