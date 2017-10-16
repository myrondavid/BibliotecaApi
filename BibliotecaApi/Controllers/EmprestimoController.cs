using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Data;
using BibliotecaApi.Models;

namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Emprestimo")]
    public class EmprestimoController : Controller
    {
        private readonly DataContext _context;

        public EmprestimoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Emprestimo
        [HttpGet]
        public IEnumerable<Emprestimo> GetEmprestimos()
        {
            return _context.Emprestimos;
        }

        // GET: api/Emprestimo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmprestimo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emprestimo = await _context.Emprestimos.SingleOrDefaultAsync(m => m.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return Ok(emprestimo);
        }

        // PUT: api/Emprestimo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmprestimo([FromRoute] int id, [FromBody] Emprestimo emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emprestimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(emprestimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(id))
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

        // POST: api/Emprestimo
        [HttpPost]
        public async Task<IActionResult> PostEmprestimo([FromBody] Emprestimo emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmprestimo", new { id = emprestimo.Id }, emprestimo);
        }

        // DELETE: api/Emprestimo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmprestimo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emprestimo = await _context.Emprestimos.SingleOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();

            return Ok(emprestimo);
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }
    }
}