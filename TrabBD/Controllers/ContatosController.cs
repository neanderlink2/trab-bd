using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrabBD.Context;
using TrabBD.Models;

namespace TrabBD.Controllers
{
    [ApiController]
    [Route("api/contatos")]
    public class ContatosController : ControllerBase
    {
        private readonly DbSet<Contato> _contatos;
        private readonly DbSet<Email> _emails;
        private readonly DbSet<Telefone> _telefones;
        private readonly ContatosContext _dbContext;

        public ContatosController(ContatosContext contatosContext)
        {
            _contatos = contatosContext.Set<Contato>();
            _emails = contatosContext.Set<Email>();
            _telefones = contatosContext.Set<Telefone>();
            _dbContext = contatosContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contatos
                .Include(x => x.Emails)
                .Include(x => x.Telefones)
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_contatos
                .Include(x => x.Telefones)
                .Include(x => x.Emails)
                .FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            try
            {
                var entity = _contatos.Add(contato);
                _dbContext.SaveChanges();
                return Ok(entity.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Contato contato, Guid id)
        {
            try
            {
                var entity = _contatos.Include(x => x.Telefones).Include(x => x.Emails).FirstOrDefault(c => c.Id == id);
                _emails.RemoveRange(entity.Emails);
                _telefones.RemoveRange(entity.Telefones);

                entity.Nome = contato.Nome;
                entity.Telefones = contato.Telefones;
                entity.Emails = contato.Emails;

                var result = _contatos.Update(entity);
                _dbContext.SaveChanges();
                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var entity = _contatos.Include(c => c.Emails).Include(c => c.Telefones).FirstOrDefault(c => c.Id == id);
                var result = _contatos.Remove(entity);
                _dbContext.SaveChanges();
                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
