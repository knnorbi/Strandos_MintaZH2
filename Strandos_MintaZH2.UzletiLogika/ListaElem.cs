using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    /// <summary>
    /// Generikus láncolt lista elem.
    /// </summary>
    /// <typeparam name="T">Tárolt érték típusa.</typeparam>
    public class ListaElem<T>
    {
        public T ertek;
        public ListaElem<T> kovetkezo;

        /// <summary>
        /// Konstruktor, amely létrehoz egy üres listaelemet.
        /// </summary>
        public ListaElem()
        {
            ertek = default(T);
            kovetkezo = null;
        }

        /// <summary>
        /// Konstruktor, amely létrehoz egy listaelemet előre beállított értékkel.
        /// </summary>
        /// <param name="ertek">Tárolt érték.</param>
        public ListaElem(T ertek)
        {
            this.ertek = ertek;
            kovetkezo = null;
        }

        /// <summary>
        /// ToString metódus felüldefiniálása.
        /// </summary>
        /// <returns>A tárolt érték stringesítve.</returns>
        public override string ToString()
        {
            return ertek.ToString();
        }
    }
}
