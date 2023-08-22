using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWEBAPI.Data;
using MyWEBAPI.Models;

namespace MyWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;  
        public LoaisController(MyDbContext context)
        {
            _context = context; 
        }
        [HttpGet]   
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai ==id);    
            if(Loai != null)
            {
                return Ok(Loai);
            }
            else
            {
                return NotFound();    
            }
         }
        [HttpPost]
        public IActionResult createNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai,
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok();
            }catch
            {
                return BadRequest();    
            }
        }
        [HttpPut("{id}")]
        public IActionResult updateLoaiById(int id, LoaiModel model)
        {
            var loai =_context.Loais.SingleOrDefault(lo=>lo.MaLoai==id);
            if(loai != null)
            {
                loai.TenLoai = model.TenLoai;  
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
        
        
    }
}
