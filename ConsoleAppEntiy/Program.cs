using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace ConsoleAppEntiy
{

    class Program
    {

        public static async void JoinSinhVienLop(Task<ICollection<SinhVien>> sinhViens , Task<ICollection<Lop>> lops )
        {
            var itemsSV = await sinhViens;
            var itemsL = await lops;

            var itemsKetQua = from sv in itemsSV
                              join l in itemsL on sv.IDL equals l.IDL
                             select (sv, l);
            Console.WriteLine("Thong Tin Jion hai Bang SinhVien Va Lop");
            foreach(var sl in itemsKetQua)
            {
                Console.WriteLine($"{sl.sv.IDSV}{sl.sv.Ten,5}{sl.sv.Tuoi,5}{sl.sv.SDT,5}{sl.sv.IDL,5}" +
                    $"{sl.l.IDL,5}{sl.l.TenLop,5}");
            }
        }


        static async  Task<ICollection<SinhVien>> GetAllSV()
        {
            var context = new DbContextQLSV();
            var items = await context.sinhViens.ToListAsync();
            context.Dispose();
            return items;

        }

        static async Task<ICollection<Lop>> GetAllLop()
        {
            var context = new DbContextQLSV();
             var items =  await   context.lops.ToListAsync();

            context.Dispose();

            return items;
        }

        static async void run()
        {
            var x = await GetAllSV();
            var y = await GetAllLop();           
            var itemSV = x;
            var itemL = y;
            Console.WriteLine("ThongTinSinhVien");
            foreach (var sv in itemSV)
            {
                Console.WriteLine($"{sv.IDSV}{sv.Ten,5}{sv.Tuoi,5}{sv.SDT,5}{sv.IDL,5}");
            }
            Console.WriteLine("ThongTinLop");
            foreach (var l in itemL)
            {
                Console.WriteLine($"{l.IDL}{l.TenLop,5}");
            }
        }
        static void Main(string[] args)
        {
            run();
            JoinSinhVienLop(GetAllSV(), GetAllLop());
            Console.ReadKey();
        }
    }

    class SinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//id tự tăng
        public int IDSV { get; set; }
        [StringLength(50)]
        [Required]
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        [StringLength(10)]
        public string SDT { get; set; }       
        public int IDL { get; set; }
        public virtual Lop lop { get; set; }
    }

    class Lop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDL { get; set; }
        [StringLength(50)]
        [Required]
        public string TenLop { get; set; }
        public virtual ICollection<SinhVien> sinhViens { get; set; }
        public ICollection<Lop> lops { get; set; }

    }

    class DbContextQLSV : DbContext
    {
       public DbContextQLSV(): base("name=QLSV")
        {
        }

        public DbSet<SinhVien> sinhViens { get; set; }
        public DbSet<Lop> lops { get; set; }

    }

}
