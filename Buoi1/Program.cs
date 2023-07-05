using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Buoi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // cac kieu co ban
            // kieu so nguyen

            /*
            int a = 0;
            double d = 1.2;
            string s = "Hellp world!";
            Console.WriteLine(a);
            bool b = false; // false
            Console.Writeln(b);
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
             */

            /*
            Console.WriteLine("Nhap data tu ban phim");
            string s = Console.ReadLine(); //1
            */


            //ep kieu du lieu
            //ep sang int
            // 3 cach ep kieu:
            //c1 parse
            // int a = int.Parse(s);
            //c2 tryparse
            // int a;
            // int.TryParse(s, out a); // neu ma loi thi tra ve 0
            //c3 convert
            // int a = Convert.ToInt32(s);

            // Console`.WriteLine(a);
            //thuc hien f5 f10

            //try catch dung de bat loi ngoai le
            /*
            try
            {
                int a = int.Parse(s); // khi bi loi
                Console.WriteLine(a);
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("thuc hien finally");
            }
            */



            // hieu ve ref out
            // ref truyen cai dia chi
            // sau khi thuc hien xong thi van tiep tuc giu ket qua lai

            /*
            int a = 1;
            Console.WriteLine("Truoc khi Test " +a);
            Test(ref a);
            Console.WriteLine($"Sau khi Test {a}");
            int b;
            TestOut(out b);
            Console.WriteLine($"Sau khi Test {b}");
            }
            */

            /*
            //list array list
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            // add 1 item vao vi tri [0] gia tri la 10
            //list.Insert(0, 10);

            foreach (int item in list) { 
                Console.WriteLine(item);
            }
            Console.WriteLine("--------");
            // dem phan tu trong list
            Console.WriteLine(list.Count);

            // xoa het cac phan tu
            //list.Clear();
            //Console.WriteLine(list.Count);

            // xoa 1 phan tu
            list.Remove(1);
            Console.WriteLine(list.Count);
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            */


            // dictionảy key-value nen tim hieu



            /*
            // var khi var int, string, 
            ArrayList listarray = new ArrayList();
            listarray.Add(1);
            listarray.Add(2.3);
            listarray.Add("Ban hai");
            listarray.Add(4);

            
            
            foreach (var item in listarray)
            {
                // in ra item kieu int
                if(item is int)
                {
                    Console.WriteLine(item);
                }
                
            }
            */


            /*
            int a = 5;
            Console.WriteLine(a);
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine(a+i);
            }
            */

            /*
            int a = 10;
            while (a<=11)
            {
                Console.WriteLine(a);
                a++;
            }

            Console.WriteLine("--------");
            do 
            { 
                Console.WriteLine(a); 
            } 
            while (a<=9);
            */



            /*
            public static void Test(ref int a)
            {
                a = a + 1;
                // a++;
                // a +=1;
            }

            public static void TestOut(out int b)
            {
                b = 2; 
                b = b + 1;
            }
            */

            
                // dung switch case
                // nhap 2 so
                // 1 tinh tong
                // 2 tinh hieu
                // 3 nhan
                // 4 kthuc ctr

                Console.Write("Nhap so thu 1: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Nhap so thu 2: ");
                int b = int.Parse(Console.ReadLine());
                while (true)
                {
                    Console.WriteLine("1. Tinh tong");
                    Console.WriteLine("2. Tinh hieu");
                    Console.WriteLine("3. Tinh nhan");
                    Console.WriteLine("4. Ket thuc");
                    Console.Write("Nhap lua chon thuc hien.");
                    Console.WriteLine();
                    int luachon = int.Parse(Console.ReadLine());
                    switch (luachon)
                    {
                        case 1:
                            Console.WriteLine(a + b);
                            break;
                        case 2:
                            Console.WriteLine(a - b);
                            break;
                        case 3:
                            Console.WriteLine(a * b);
                            break;
                        case 4:
                            Console.WriteLine("Ket thuc ctr.");
                            System.Environment.Exit(0);
                            break;
                    }
                }
            


            // extension method
            /*
            string a = "Hello bitch";
            if(a.EpKieu== true)
            {
                Console.WriteLine("Chuoi a duoc ep kieu int");
            }
            else
            {
                Console.WriteLine("Chuoi a ko the ep kieu dc sang int");
            }

            public static class Demo
            {
            pub
            }
            */
        }
    }
}