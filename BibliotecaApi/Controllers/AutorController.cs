using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BibliotecaApi.Data;
using BibliotecaApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    public class AutorController : Controller
    {
        private readonly DataContext _context;

        public AutorController(DataContext context)
        {
            _context = context;

            if (_context.Autores.Count() == 0)
            {
                _context.Autores.Add(new Autor { Nome = "Autor1" });
                _context.SaveChanges();
            }
        }

        // GET: api/autor
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return _context.Autores.ToList();
        }

        // GET api/autor/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.Autores.FirstOrDefault(l => l.Id == id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        // POST api/create
        [HttpPost]
        public IActionResult Create([FromBody]Autor autor)
        {
            if (autor == null)
                return BadRequest();
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return CreatedAtRoute("GetAutor", new { id = autor.Id }, autor);
        }

        // PUT api/update/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Autor autor)
        {
            if (autor == null || autor.Id != id)
                return BadRequest();
            var au = _context.Autores.FirstOrDefault(l => l.Id == id);
            if (au == null)
                return NotFound();

            au = autor;
            _context.Autores.Update(au);
            _context.SaveChanges();
            return new NoContentResult();

        }

        // DELETE api/delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var autor = _context.Autores.FirstOrDefault(l => l.Id == id);
            if (autor == null)
                return NotFound();
            _context.Autores.Remove(autor);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
