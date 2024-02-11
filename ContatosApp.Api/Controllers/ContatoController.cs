using ContatosApp.Api.Models;
using ContatosApp.Data.Entities;
using ContatosApp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContatosApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ContatoPostModel model)
        {
            try
            {
                var c = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    DataHoraCadastro = DateTime.Now
                };
                var contatoRepository = new ContatoRepository();
                contatoRepository.Insert(c);
                return StatusCode(201, new { message = "O contato de " + c.Nome + " Foi cadastrado com sucesso!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(ContatoPostModel model)
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var c = contatoRepository.GetById(model.Id.Value);
                if (c != null)
                {
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Telefone = model.Telefone;
                    contatoRepository.Update(c);
                    return StatusCode(200, new { message = "O contato " + c.Nome + ", foi atualizado com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { message = "Contato não encontrado, tente outra vez" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var c = contatoRepository.GetById(id);
                if (c != null)
                {
                    contatoRepository.Delete(c);
                    return StatusCode(200, new { message = "Conato Excluido" });
                }
                else
                {
                    return StatusCode(400, new { message = "Contato não encontrado, tente novamente" });
                }



            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var contatoRepositor = new ContatoRepository();
                var c = contatoRepositor.GetAll();
                if (c != null)
                {
                    return StatusCode(200, c);//http 200
                }
                else
                {
                    return NoContent();//http 204
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var contatoReposititory = new ContatoRepository();
                var c = contatoReposititory.GetById(id);
                if (c != null)
                {
                    return StatusCode(200, c);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
