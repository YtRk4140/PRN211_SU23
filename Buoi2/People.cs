using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
{
    public class People
    {
        private string name;
        private int age;
        private string diachi;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age { get => age; set => age = value; }
        public string Diachi { get => diachi; set => diachi = value; }

        // Contructor co tham so
        public People(string name, int age, string diachi)
        {
            this.name = name;
            this.age = age; 
            this.diachi = diachi;
        }

        // contructor khong tham so
        public People()
        {

        }
        // pham vi truy cap
        // private/ protected, public

        /// <summary>
        /// nhap thong tin People
        /// </summary>
        public virtual void Input()
        {
            Console.Write("Nhap ten: ");
            Name = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Nhap dia chi: ");
            Diachi = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Ten: {Name} - Tuoi: {Age} - Dia chi: {Diachi} -";
        }
       

    }
}
 // ke thua tinh chat cua class people
