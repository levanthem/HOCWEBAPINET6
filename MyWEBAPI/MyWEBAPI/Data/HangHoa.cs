using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWEBAPI.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHH { get; set; }
        [Required]
        [MaxLength(100)]
        public String TenHH { get; set; }
        public String MoTa { get; set; }
        [Range(0,double.MaxValue)]
        public Double DonGia { get; set; }

        public Double GiamGia { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]  
        public Loai Loai { get; set; }
        

    }
}
