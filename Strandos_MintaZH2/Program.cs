using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strandos_MintaZH2.UzletiLogika;

namespace Strandos_MintaZH2
{
    class Program
    {
        static void EsemenyKezelo(string uzenet) { Console.WriteLine(uzenet); }
        
        static void Main(string[] args)
        {
            Strand strand = new Strand("Római");

            strand.SzolgaltatasFelvetele(new Bufe("Lángos", 500));
            strand.SzolgaltatasFelvetele(new Bufe("Sör", 400));
            strand.SzolgaltatasFelvetele(new Bufe("Víz", 300));
            strand.SzolgaltatasFelvetele(new ViziSzolgaltatas("Csúszda", 100));
            strand.SzolgaltatasFelvetele(new ViziSzolgaltatas("Szauna", 100));
            try
            {
                strand.SzolgaltatasTorlese("Víz");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Strandolo strandolo = new Strandolo("Feri", 1000);
            strandolo.FigyelotFeliratkoztat(EsemenyKezelo);

            if(strandolo.Penz >= strand.szolgaltatasok.SzolgaltatasokAraOsszesitve())
            {
                Console.WriteLine($"{strandolo.Nev} meg tudja látogatni az összes szolgáltatást!");
            }
            else
            {
                Console.WriteLine($"{strandolo.Nev} nem tudja meglátogatni az összes szolgáltatást!");
            }

            int bufe = 0;
            foreach (ISzolgaltatas szolgaltatas in strand.szolgaltatasok)
            {
                try
                {
                    strandolo.SzolgaltatasIgenybevetele(szolgaltatas);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Bufe bufeE = szolgaltatas as Bufe;
                if(bufeE != null) { bufe++; }
            }

            Console.WriteLine("Összesen, {0} db büfét látogatott meg.", bufe);

            Console.ReadKey();
        }
    }
}
