using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    /// <summary>
    /// Strandoló osztály.
    /// </summary>
    public class Strandolo
    {
        string nev;
        int penz;
        event SzolgaltatasFigyelo figyelok;

        /// <summary>
        /// A strandoló neve.
        /// </summary>
        public string Nev { get { return nev; } }

        /// <summary>
        /// A strandoló egyenlege.
        /// </summary>
        public int Penz { get { return penz; } }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="nev">A strandoló neve.</param>
        /// <param name="penz">A strandoló egyenlege.</param>
        public Strandolo(string nev, int penz)
        {
            this.nev = nev;
            this.penz = penz;
        }

        /// <summary>
        /// Feliratkoztat egy SzolgaltatasFigyelo-t.
        /// </summary>
        /// <param name="figyelo">Figyelő.</param>
        public void FigyelotFeliratkoztat(SzolgaltatasFigyelo figyelo)
        {
            figyelok += figyelo;
        }

        /// <summary>
        /// Szolgáltatás igénybevétele.
        /// </summary>
        /// <param name="szolgaltatas">Szolgáltatás.</param>
        /// <exception cref="Exception"></exception>
        public void SzolgaltatasIgenybevetele(ISzolgaltatas szolgaltatas)
        {
            if(szolgaltatas.SzolgaltatasAra > penz)
            {
                throw new Exception($"{nev} strandolónak nincs elég pénze a {szolgaltatas.Megnevezes}-t igénybe venni!");
            }

            penz -= szolgaltatas.SzolgaltatasAra;

            if(figyelok != null)
            {
                figyelok.Invoke($"{nev} strandoló igénybe vette a {szolgaltatas.Megnevezes}-t!");
            }
        }
    }
}
