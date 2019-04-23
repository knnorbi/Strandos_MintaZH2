using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    /// <summary>
    /// Viziszolgáltatás osztály.
    /// </summary>
    public class ViziSzolgaltatas : ISzolgaltatas
    {
        string megnevezes;
        int ar;

        /// <summary>
        /// A szolgáltatás megnevezése.
        /// </summary>
        public string Megnevezes { get { return megnevezes; } }

        /// <summary>
        /// A szolgáltatás ára.
        /// </summary>
        public int SzolgaltatasAra { get { return ar; } }

        /// <summary>
        /// Létrehoz egy szolgáltatást.
        /// </summary>
        /// <param name="megnevezes">A szolgáltatás megnevezése.</param>
        /// <param name="ar">A szolgáltatás ára.</param>
        public ViziSzolgaltatas(string megnevezes, int ar)
        {
            this.megnevezes = megnevezes;
            this.ar = ar;
        }
    }
}
