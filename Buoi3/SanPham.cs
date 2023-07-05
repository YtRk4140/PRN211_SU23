using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3
{
    public class SanPham
    {
        public SanPham(int id, string ten, int gia, int loaiSP)
        {
            Id = id;
            Ten = ten;
            Gia = gia;
            LoaiSP = loaiSP;
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public int Gia { get; set; }
        public int LoaiSP { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Ten} - {Gia} - {LoaiSP}";
        }
    }
}
