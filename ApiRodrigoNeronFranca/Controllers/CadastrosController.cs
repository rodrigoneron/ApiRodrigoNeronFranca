using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRodrigoNeronFranca
{
    [ApiController]
    [Route("[Controller]")]
    public class CadastrosController : ControllerBase
    {

        private ApplicationDbContext _context;

        public CadastrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cadastro> Get()
        {
            return _context.Cadastros;
        }

        [HttpPost]
        public IActionResult Post(Cadastro cadastro)
        {
            if (cadastro != null)
            {
                _context.Cadastros.Add(cadastro);
                _context.SaveChanges();
                return Ok("Cadastrado com Sucesso!");
            }
            return BadRequest("Não foi possivel cadastrar, tente novamente!");
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var cadastro = _context.Cadastros.First(c => c.Id == id);

            if (cadastro != null)
            {
                _context.Cadastros.Remove(cadastro);
                _context.SaveChanges();
                return Ok("Cadastro Removido!");
            }
            return BadRequest("Cadastro não existe!");
        }

        [HttpPut]
        public IActionResult Put(int id, Cadastro dados)
        {
            var cadastro = _context.Cadastros.First(c => c.Id == id);

            if (cadastro != null)
            {
                cadastro.Nome = String.IsNullOrEmpty(dados.Nome) ? cadastro.Nome : dados.Nome;
                cadastro.Email = String.IsNullOrEmpty(dados.Email) ? cadastro.Email : dados.Email;
                cadastro.CPF = String.IsNullOrEmpty(dados.CPF) ? cadastro.CPF : dados.CPF;
                cadastro.DataNascimento =dados.DataNascimento.ToShortDateString() == null ? cadastro.DataNascimento : dados.DataNascimento;
                cadastro.Sexo = String.IsNullOrEmpty(dados.Sexo) ? cadastro.Sexo : dados.Sexo;
                cadastro.Telefone = String.IsNullOrEmpty(dados.Telefone) ? cadastro.Telefone : dados.Telefone;
                _context.Cadastros.Remove(cadastro);
                _context.SaveChanges();
                return Ok(cadastro);
            }
            return BadRequest("Algo deu errado!");
        }

    }
}
