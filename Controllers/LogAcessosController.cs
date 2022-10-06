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
    public class LogAcessosController : ControllerBase
    {
        private readonly API_QrCodeContext _context;

        public LogAcessosController(API_QrCodeContext context)
        {
            _context = context;
        }

        // GET: api/LogAcessos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAcesso>>> GetLogAcesso()
        {
            return await _context.LogAcesso.ToListAsync();
        }

        // GET: api/LogAcessos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogAcesso>> GetLogAcesso(int id)
        {
            var logAcesso = await _context.LogAcesso.FindAsync(id);

            if (logAcesso == null)
            {
                return NotFound();
            }

            return logAcesso;
        }

        // PUT: api/LogAcessos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAcesso(int id, LogAcesso logAcesso)
        {
            if (id != logAcesso.lacNumero)
            {
                return BadRequest();
            }

            _context.Entry(logAcesso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAcessoExists(id))
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

        // POST: api/LogAcessos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogAcesso>> PostLogAcesso(LogAcesso logAcesso)
        {
            _context.LogAcesso.Add(logAcesso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogAcesso", new { id = logAcesso.lacNumero }, logAcesso);
        }

        // DELETE: api/LogAcessos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAcesso(int id)
        {
            var logAcesso = await _context.LogAcesso.FindAsync(id);
            if (logAcesso == null)
            {
                return NotFound();
            }

            _context.LogAcesso.Remove(logAcesso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogAcessoExists(int id)
        {
            return _context.LogAcesso.Any(e => e.lacNumero == id);
        }
    }
}
