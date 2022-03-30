#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CanonImgApi;
using CanonImgApi.Data;
using Microsoft.AspNetCore.Cors;

namespace CanonImgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ImgsController : ControllerBase
    {
        private readonly DataContext _context;

        public ImgsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Imgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Img>>> GetImgs()
        {
            return await _context.Imgs.ToListAsync();
        }

        // GET: api/Imgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Img>> GetImg(int id)
        {
            var img = await _context.Imgs.FindAsync(id);

            if (img == null)
            {
                return NotFound();
            }

            return img;
        }

        // PUT: api/Imgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImg(int id, Img img)
        {
            if (id != img.Id)
            {
                return BadRequest();
            }

            _context.Entry(img).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Imgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Img>> PostImg(Img img)
        {
            _context.Imgs.Add(img);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImg", new { id = img.Id }, img);
        }

        // DELETE: api/Imgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImg(int id)
        {
            var img = await _context.Imgs.FindAsync(id);
            if (img == null)
            {
                return NotFound();
            }

            _context.Imgs.Remove(img);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgExists(int id)
        {
            return _context.Imgs.Any(e => e.Id == id);
        }
    }
}
