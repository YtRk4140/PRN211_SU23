using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
{
    public class Student : People
    {
        private string lop;

        public Student(string name, int age, string diachi, string lop) : base(name,age,diachi)
        {
            this.lop = lop;
        }
        public Student()
        {

        }

        public override void Input()
        {
            base.Input();
            Console.Write("Lop hoc: ");
            Lop = Console.ReadLine();
        }

        public string Lop { get => lop; set => lop = value; }

        public override string ToString()
        {
            return base.ToString() + $" Lop: {Lop}";
        }
    }

    public class Teacher : People 
    {
        private string level;

        public Teacher(string name, int age, string diachi, string level) : base(name, age, diachi)
        {
            this.level = level;
        }
        public Teacher() { }
        public string Level { get => level; set => level = value; }

        public override void Input()
        {
            base.Input();
            Console.Write("Cap bac: ");
            level = Console.ReadLine();
        }

        public override string ToString()
        {
            return base.ToString() + $" Cap bac: {level}";
        }
    }

}
