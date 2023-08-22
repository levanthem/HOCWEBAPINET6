namespace MyWEBAPI.Models
{
    public class HangHoaVM
    {
        public String TenHangHoa { get; set; }  
        public String DonGia { get; set; }
    }
    public class HangHoa : HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
       
    }

}
