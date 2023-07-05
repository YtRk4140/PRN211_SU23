using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
{
    public interface TestInterface
    {
        // tinh chu vi
        public int Chuvi(int a, int b);
        // tinh dien tich
        public int Dientich(int a, int b);

    }

    public class HinhVuong : TestInterface
    {
        public int Chuvi(int a, int b)
        {
            int sum = a*4;
            return sum;
        }

        public int Dientich(int a, int b)
        {
            int dt = a * a;
            return dt;
        }
    }

    public class HCN : TestInterface
    {
        public int Chuvi(int a, int b)
        {
            return (a + b) * 2;
        }

        public int Dientich(int a, int b)
        {
            return (a*b);
        }
    }
}
