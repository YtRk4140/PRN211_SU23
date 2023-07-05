namespace Buoi2
{
    internal class Program
    {
        public delegate int Test(int a, string b);
        // tham chieu toi thg tong nay
        public static void HienThi(string s)
        {
            Console.WriteLine(s);
        }
        public static int Tong(int a, string b) { return a + int.Parse(b); }
        // (string s) => Console. Writeline(s)
        // (int a, trìn b) => { int sum = a+b;
        //                      Return sum
        //                    }

        //public static int Tong1(int a1, int b1) { return a1; }


        static void Main(string[] args)
        {
            
            Student s= new Student();
            s.Input();
            Console.WriteLine(s.ToString());

            Teacher t = new Teacher();
            t.Input();
            Console.WriteLine(t.ToString());

            People p1 = new Student();
            People p2 = new Teacher();
            List<People> p3 = new List<People>();
            

            /*
            TestInterface t  = new HinhVuong();
            TestInterface t1 = new HCN();
            */

            // Delegate
            /*
            Test t = null;
            t = Tong;
            int a1 = t(1, "22");
            Console.WriteLine(t.Invoke(1,"hi"));
            */


            /*
            // 1. Action la 1 ham void
            Action<string> a1;
            a1 = HienThi;
            a1("Hello cac friend");
            HienThi("Hello wibu");
            */

            /*
            Action<string> a2 = (string s) => Console.WriteLine(s);
            a2.Invoke("Brhhhh");

            Func<int, int, int> tinhsum = (int s1, int s2) =>
            {
                int sum = s1 + s2;
                return sum;
            };
            

            int sum = TinhTong(10, 20);
            int sum2 = tinhsum(10, 20);
            Console.WriteLine(sum +"    "+ sum2);
            */

            /*
            //2. Func<>
            Func<int, string, int> tong;
            tong = Tong;
            int a = tong(1, "2");
            Console.WriteLine(a);
            */

        }
        
        /*
        public static int TinhTong(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
        */
        
    }
}
/*
 * Interface : khai bao ra cac ham tinh tong, hieu, nhan, chia
 * 
 */


// Bai toan co ban Quan ly hoc sinh va giao vien
/*
 * 1. Danh sach dung de chua hoc sinh va giao vien
 * 2. Cho nhap thong tin cua gv
 * 3. Cho nhap tt cua hoc sinh
 * 4. In ra thong tin cua tat ca giao vien
 * 5. In ra thong tin tat ca hoc sinh
 * 6. Thoat ctr
 * 7. Sap xep tuoi, neu trung tuoi sap xep theo ten
 * 8. Tim nhung thang nao co ten la abc
 */

// linq