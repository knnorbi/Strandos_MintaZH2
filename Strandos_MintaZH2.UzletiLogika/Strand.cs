using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    public delegate void SzolgaltatasFigyelo(string message);

    /// <summary>
    /// Strand osztály.
    /// </summary>
    public class Strand
    {
        string nev;

        /// <summary>
        /// A strand neve.
        /// </summary>
        public string Nev { get { return nev; } }

        /// <summary>
        /// A strandon elérhető szolgáltatások.
        /// </summary>
        public SzolgaltatasLista<ISzolgaltatas> szolgaltatasok;

        /// <summary>
        /// Konstrukor.
        /// Beállítja a strand nevét és létrehozza a szolgáltatások listáját.
        /// </summary>
        /// <param name="nev">A strand neve.</param>
        public Strand(string nev)
        {
            this.nev = nev;
            szolgaltatasok = new SzolgaltatasLista<ISzolgaltatas>();
        }

        /// <summary>
        /// Felvesz egy új szolgáltatást a listába.
        /// </summary>
        /// <param name="szolgaltatas">Szolgáltatás.</param>
        public void SzolgaltatasFelvetele(ISzolgaltatas szolgaltatas)
        {
            szolgaltatasok.UjSzolgaltatasFelvetele(szolgaltatas);
        }

        /// <summary>
        /// Megkísérli kitörölni az első olyan szolgáltatást,
        /// mely megnevezés szerint megegyezik a paraméterként átadott megnevezéssel.
        /// </summary>
        /// <param name="szolgaltatasMegnevezese">Szolgáltatás megnevezése</param>
        /// <exception cref="Exception"></exception>
        public void SzolgaltatasTorlese(string szolgaltatasMegnevezese)
        {
            try
            {
                szolgaltatasok.SzolgaltatasTorlese(szolgaltatasMegnevezese);
            }
            catch (SzolgaltatasListaException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
