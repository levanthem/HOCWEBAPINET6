using System.ComponentModel.DataAnnotations;

namespace MyWEBAPI.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]

        public String TenLoai { get; set; }
    }
}
