using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_QrCode.Data;
using API_QrCode.models;

namespace API_QrCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificadoresController : ControllerBase
    {
        private readonly API_QrCodeContext _context;

        public IdentificadoresController(API_QrCodeContext context)
        {
            _context = context;
        }

        // GET: api/Identificadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Identificador>>> GetIdentificador()
        {
            return await _context.Identificadores.ToListAsync();
        }

        // GET: api/Identificadores/5
        [HttpGet("{numInterno}")]
        public async Task<ActionResult<Identificador>> GetIdentificador(string numInterno)
        {
            var identificador = await _context.Identificadores
                .Include(i => i.Pessoa)
                .Where(i => i.ideNumInterno == numInterno)
                .FirstOrDefaultAsync();

            if (identificador == null)
            {
                return NotFound();
            }

            return identificador;
        }

        // PUT: api/Identificadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentificador(string id, Identificador identificador)
        {
            if (id != identificador.ideNumInterno)
            {
                return BadRequest();
            }

            _context.Entry(identificador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentificadorExists(id))
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

        // POST: api/Identificadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Identificador>> PostIdentificador(Identificador identificador)
        {
            _context.Identificadores.Add(identificador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdentificadorExists(identificador.ideNumInterno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIdentificador", new { id = identificador.ideNumInterno }, identificador);
        }

        // DELETE: api/Identificadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentificador(string id)
        {
            var identificador = await _context.Identificadores.FindAsync(id);
            if (identificador == null)
            {
                return NotFound();
            }

            _context.Identificadores.Remove(identificador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdentificadorExists(string id)
        {
            return _context.Identificadores.Any(e => e.ideNumInterno == id);
        }
    }
}
