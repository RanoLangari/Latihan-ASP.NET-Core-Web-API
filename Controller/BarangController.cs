using CRUD_ASP.Context;
using CRUD_ASP.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public BarangController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddBarang(TblBarang barang)
        {
            
            _myDbContext.TblBarangs.Add(barang);
            await _myDbContext.SaveChangesAsync();

            return Ok(new{Message="Berhasil Menambahkan Data Barang"});
        }

        [HttpGet]
        public async Task<IActionResult> GetBarang()
        {
            var dataBarang = await _myDbContext.TblBarangs.ToListAsync();
            return Ok(new {Message="Berhasil Mendapatkan Data Barang", Data=dataBarang});
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarang(int id, TblBarang barang)
        {
            
            _myDbContext.Entry(barang).State = EntityState.Modified;
            try
            {
                await _myDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok(new { Success = true, Message = "Berhasil Memngubah Data Barang Data Barang" });
            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarang(int id)
        {
            var barang = await _myDbContext.TblBarangs.FindAsync(id);
            if (barang == null)
            {
                return NotFound();
            }

            _myDbContext.TblBarangs.Remove(barang);
            await _myDbContext.SaveChangesAsync();

            return Ok(new { Message = "Berhasil Menghapus Data Barang" });
        }

        private bool BarangExists(int id)
        {
            return _myDbContext.TblBarangs.Any(e => e.IdBarang == id);
        }

    }
}