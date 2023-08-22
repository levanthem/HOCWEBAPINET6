using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWEBAPI.Models;

namespace MyWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa =Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hanghoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });

        }
        [HttpGet("{id}")]
        public IActionResult GetById(String id)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa ==Guid.Parse(id));
                if (hangHoa ==null)
                {
                    return NotFound();

                }
                return Ok(hangHoa);

            }
            catch
            {
                return BadRequest();
            }


        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa==Guid.Parse(id));
                if (hangHoa ==null)
                {
                    return NotFound();
                }
                if (id!= hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // update hang hoa 
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }



        }
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa ==Guid.Parse(id) )  ;
                if (hangHoa ==null)
                {
                    return NotFound();

                }
                //Delete
                hanghoas.Remove(hangHoa);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
