﻿using System;
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
    public class PessoasController : ControllerBase
    {
        private readonly API_QrCodeContext _context;

        public PessoasController(API_QrCodeContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
            return await _context.Pessoas.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(string id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(string id, Pessoa pessoa)
        {
            if (id != pessoa.PIN)
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
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

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PessoaExists(pessoa.PIN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPessoa", new { id = pessoa.PIN }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(string id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(string id)
        {
            return _context.Pessoas.Any(e => e.PIN == id);
        }
    }
}
