using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strandos_MintaZH2.UzletiLogika
{
    /// <summary>
    /// Generikus láncolt lista ISzolgaltatas-ok tárolására.
    /// A lista a szolgáltatás ára alpaján növekvő módon rendezett.
    /// </summary>
    /// <typeparam name="T">A tárolt elemek típusa, csak ISzolgaltatas-t megvalósító lehet.</typeparam>
    public class SzolgaltatasLista<T> : IEnumerable where T : ISzolgaltatas
    {
        ListaElem<T> fej;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SzolgaltatasLista()
        {
            fej = new ListaElem<T>();
        }

        /// <summary>
        /// Új szolgáltatás felvétele a listába.
        /// </summary>
        /// <param name="szolgaltatas">Szolgáltatás.</param>
        public void UjSzolgaltatasFelvetele(T szolgaltatas)
        {
            if (fej.kovetkezo == null)
            {
                fej.kovetkezo = new ListaElem<T>(szolgaltatas);
            }
            else
            {
                ListaElem<T> akutalisElem = fej.kovetkezo;
                while(akutalisElem.kovetkezo != null && akutalisElem.ertek.SzolgaltatasAra > szolgaltatas.SzolgaltatasAra)
                {
                    akutalisElem = akutalisElem.kovetkezo;
                }
                ListaElem<T> ujElem = new ListaElem<T>(szolgaltatas);
                ujElem.kovetkezo = akutalisElem.kovetkezo;
                akutalisElem.kovetkezo = ujElem;
            }
        }

        /// <summary>
        /// Kitöröl egy adott megnevezésű szolgáltatást a listából.
        /// </summary>
        /// <param name="megnevezes">A törlendő szolgáltatás megnevezése.</param>
        /// <exception cref="SzolgaltatasListaException"></exception>
        public void SzolgaltatasTorlese(string megnevezes)
        {
            ListaElem<T> aktualisElem = fej.kovetkezo;
            ListaElem<T> elozoElem = fej;
            while(aktualisElem.kovetkezo != null && aktualisElem.ertek.Megnevezes != megnevezes)
            {
                elozoElem = aktualisElem;
                aktualisElem = aktualisElem.kovetkezo;
            }
            if(aktualisElem != null && aktualisElem.ertek.Megnevezes == megnevezes)
            {
                elozoElem.kovetkezo = aktualisElem.kovetkezo;
                aktualisElem.kovetkezo = null;
            }
            else
            {
                throw new SzolgaltatasListaException($"Nem törölhető a {megnevezes} megnevezes, mert nem létezik.");
            }
        }

        /// <summary>
        /// Visszaadja az összes szolgáltatás árát összesítve.
        /// </summary>
        /// <returns>Az összes szolgáltatás ára összesítve.</returns>
        public int SzolgaltatasokAraOsszesitve()
        {
            int ossszeg = 0;
            foreach (ISzolgaltatas szolgaltatas in this)
            {
                ossszeg += szolgaltatas.SzolgaltatasAra;
            }
            return ossszeg;
        }

        /// <summary>
        /// Lista bejáró getter metódus.
        /// </summary>
        /// <returns>ista bejáró.</returns>
        public IEnumerator GetEnumerator()
        {
            return new SzolgaltatasListaBejaro<T>(fej);
        }
    }
}
