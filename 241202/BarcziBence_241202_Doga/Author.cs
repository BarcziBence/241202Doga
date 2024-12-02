using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcziBence_241202_Doga
{
    internal class Author
    {
        private string _vezeteknev;
        private string _keresztnev;
        private Guid _id;

        public string Vezeteknev { 
            get => _vezeteknev; 
            set {
                if (value.Length < 4 || value.Length > 32) throw new Exception("A Vetéknév minimum 4, maximum 32 hosszú lehet");
                _vezeteknev = value;
            } 
        }
        public string Keresztnev { 
            get => _keresztnev;
            set
            {
                if (value.Length < 4 || value.Length > 32) throw new Exception("A Vetéknév minimum 4, maximum 32 hosszú lehet");
                _keresztnev = value;
            }
        }
        public Guid Id { get => _id; set => _id = value; }

        public Author(string nev)
        {
            var nevek = nev.Split(' ');
            Id = Guid.NewGuid();
            Vezeteknev = nevek[0];
            Keresztnev = nevek[1];
        }

        public override string ToString()
        {
            return $"{Vezeteknev} {Keresztnev}";
        }
    }
}
