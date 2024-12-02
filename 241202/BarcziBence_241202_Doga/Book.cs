using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcziBence_241202_Doga
{
    internal class Book
    {
        private Random rnd = new Random();

        private long _ISBN;
        private string _cim;
        private int _kiadas;
        private int _keszlet;
        private int _ar;
        private Nyelvek _nyelv;
        private Author[] _szerzok;

        public long ISBN { 
            get => _ISBN; 
            private set {
                if (value.ToString().Length != 10) throw new Exception($"Az ISBN azonosító pontosan 10 karakter hosszú kell legyen. Jelenleg megadott hossza: {value.ToString().Length} => {value}");   
            } 
        }
        public string Cim { 
            get => _cim; 
            private set {
                if (value.Length < 4 || value.Length > 64) throw new Exception("A könyv címe minumum 4, maximum 64 karakter lehet");
            }
        }
        public int Kiadas { 
            get => _kiadas; 
            private set {
                if (value < 2007 || value > DateTime.Now.Year) throw new Exception("Az évszám 2007 és a jelenlegi év között érvényes");
                _kiadas = value;
            } 
        }
        public int Keszlet { 
            get => _keszlet; 
            set {
                if (value < 0) throw new Exception("A készleten lévő könyvek száma nem lehet kissebb mint 0");
                _keszlet = value;
            } 
        }
        public int Ar { 
            get => _ar; 
            private set {
                if (value < 999 || value > 10000) throw new Exception("A könyv ára 1000 és 10000 közötti érték kell legyen");
                else if (value % 100 != 0) throw new Exception("A könyv ára 100-al maradék nélkül ösztható érték kell legyen");
                _ar = value;
            }
        }
        public Author[] Szerzok { 
            get => _szerzok; 
            private set {
                if (value.Length < 1 || value.Length > 3) throw new Exception("Egy könyvnek legalább 1, maximum 3 szerzője lehet");
                _szerzok = value;
            }
        }
        public Nyelvek Nyelv { get => _nyelv; private set => _nyelv = value; }
       

        public enum Nyelvek
        {
            Magyar,
            Angol,
            Német
        }

        public Book(string cim, string nev)
        {
            Szerzok = new Author[] { new(nev) };
            Cim = cim;
            Keszlet = 0;
            Ar = 4500;
            Kiadas = 2024;
            Nyelv = Nyelvek.Magyar;
            //ISBN = Math.Round(8999999999 * rnd.NextDouble()) + 1000000000;
           
        }

        public Book(long iSBN, string cim, int kiadas, int keszlet, int ar, Nyelvek nyelv, params string[] szerzok)
        {
            ISBN = iSBN;
            Cim = cim;
            Kiadas = kiadas;
            Keszlet = keszlet;
            Ar = ar;
            Nyelv = nyelv;
            Szerzok = new Author[szerzok.Length];
            for (int i = 0; i < szerzok.Length; i++) { Szerzok[i] = new Author(szerzok[i]); }
        }

        public override string ToString()
        {
            string szerzok = "";
            foreach (Author s in Szerzok) { szerzok += (s.ToString() + (Szerzok.Length > 1 && s != Szerzok[Szerzok.Length-1] ? ", " : "")); }

            return $"\tAzonosító: {ISBN}\n" +
                $"\tCím: {Cim}\n" +
                $"\tKiadás éve: {Kiadas}\n" +
                $"\tÁr : {Ar}Ft\n" +
                $"\tNyelv: {Nyelv}\n" +
                $"\tKészleten: {(Keszlet > 0 ? Keszlet.ToString() + "db" : "Beszerzés alatt")}\n" +
                $"\t{(Szerzok.Length < 2 ? "Szerző" : "Szerzők")}: {szerzok}\n";
        }
    }
}
