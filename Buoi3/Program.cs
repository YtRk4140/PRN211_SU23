namespace Buoi3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq : Dung de truy van du lieu tu nhieu nguon Object, SQL, XML
            // Method
            // query
            /*
            List<int> listA = new List<int> { 1, 2, 3, 4, 5, 6, 7, 6, 7 };
            List<int> listB = new List<int>();
            */

            //1. Where dung de loc
            /*
            listB = listA.Where(x=> x>4).ToList();
            foreach(int item in listB)
            {
                Console.WriteLine(item);
            }
            */

            //2. Xoa di phan tu trung Distinct
            /*
            listB = listA.Where(x => x > 4).Distinct().ToList();
            foreach (int item in listB)
            {
                Console.WriteLine(item);
            }
            */

            //3. Check cac ptu trong list >4 ko neu dung tra ve true
            // check tat ca
            //bool result = listA.All(x => x > 4);
            // check mot phan thoa man tra ve true
            //bool result = listA.Any(x => x > 9);
            /*
            foreach (int item in listB)
            {
                Console.WriteLine(item);
            }
            */
            //Console.WriteLine(result);

            //4.Tinh tong
            /* 
                int sum = listA.Sum();
                Console.WriteLine(sum);
            */

            //5.Tinh trung binh
            /*
            var tb = listA.Average();
            Console.WriteLine(tb);
            */

            //6. Take, Skip
            // Take lay cac phan tu dau tien Take(2) lay 2 phantu dau tien
            //Skip la bo qua Skip(2) bo qua 2 phtu dau tien
            /*
            listB = listA.Take(3).ToList();
            listB = listA.Take(4).ToList();
            */

            // ung dung de phan trang
            /*
            int index = 2;
            int size = 3;
            listB = listA.Skip((index-1)*size).Take(size).ToList();

            foreach (int item in listA) 
            {
                Console.Write(item + "-");
            }
            Console.WriteLine("\n");
            foreach (int item in listB)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(result);
            */


            List<SanPham> listsp = new List<SanPham>()
            {
                new SanPham(1, "Snack", 5000, 1),
                new SanPham(2, "Keo Cao Su", 6000, 1),
                new SanPham(3, "Keo Mut", 7000, 1),
                new SanPham(4, "Nuoc C2", 6000, 2),
                new SanPham(5, "Sting", 6000, 2),
                new SanPham(6, "Nuoc Yen", 9000,2),
            };

            List<LoaiSanPham> listlsp = new List<LoaiSanPham>()
            {
                new LoaiSanPham(1,"Do An"),
                new LoaiSanPham(2,"Do Uong")
            };

            // FirstOrDefault vs SingleOrDefault
            //ca 2 deu tra ve 1 record
            //Default= null;
            //SanPham sp = listsp.Where(x => x.Gia == 1000).FirstOrDefault();
            //SanPham sp = listsp.Where(x => x.Gia == 6000).SingleOrDefault();
            //Console.WriteLine(sp.ToString()) ;

            //.Sap xep cac san pham theo gia tien asc, idloai asc
            //List<SanPham> sp = listsp.OrderBy(x => x.Gia).ThenBy(x=>x.Id).ToList();

            //8.Tim nhung san pham co chu m
            // dung contain <=> like %m%
            // s = "M";
            //List<SanPham> sp = listsp.Where(x => x.Ten.ToLower().Contains(s.ToLower())).ToList();
            //9.So luong ptu trong danh sach
            //int count = listsp.Count;
            //Console.WriteLine(count);

            //10.GroupBy
            // dung de nhom thanh cac loai theo yeu cau

            var group = listsp.GroupBy(x => x.LoaiSP).ToList();
            //Key-Value

            foreach (var item in group.OrderByDescending(x => x.Key))
            {
                LoaiSanPham lsp = listlsp.FirstOrDefault(x => x.Id == item.Key);
                Console.WriteLine($"Loai sp:{lsp.Name}");
                foreach (SanPham item1 in item.OrderBy(x => x.Gia))
                {
                    Console.WriteLine(item1.ToString());
                }
            }


            //foreach (SanPham item in sp)
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }
    }
}