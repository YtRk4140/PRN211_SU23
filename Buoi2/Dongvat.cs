using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
{
    public abstract class Dongvat
    {
        protected Dongvat(string loai, string can)
        {
            Loai = loai;
            Can = can;
        }

        public string Loai { get; set; }
        public string Can { get; set; }

        public abstract void DisPlay(string loai, string can);
    }

    public class Dog : Dongvat
    {
        public Dog(string loai, string can, int tuoi): base(loai,can)
        {
            Tuoi = tuoi;
        }

        public int Tuoi { get; set; }
        public override void DisPlay(string loai, string cannang)
        {
            Console.WriteLine("Gau gau gau" + loai);
        }
    }
}

