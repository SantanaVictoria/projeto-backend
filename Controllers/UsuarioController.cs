using EscolaAPI.Data;
using EscolaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        EscolaContexto _contexto;

    
        public UsuarioController(EscolaContexto escolaContexto)
        {
            _contexto = escolaContexto;
        }
        
        [HttpGet("GetListaUsuarios")]
        public List<Usuario> GetListaUsuario()
        {

            List<Usuario> lstUsuario = _contexto.Usuarios.ToList();
            return lstUsuario;

        }

        [HttpPost("InsertUsuario")]
        public ActionResult InsertUsuario(object Usuario)
        {
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Usuario.ToString());

            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
            return Ok();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Usuario>> PegarUsuarioPeloId(int Id)
        {
            Usuario usuario = await _contexto.Usuarios.FindAsync(Id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost("UpdateUsuario")]
        public ActionResult UpdateUsuario(Usuario usuario)
        {

            Usuario usu = _contexto.Usuarios.Where(p => p.Id == usuario.Id).FirstOrDefault();
            usu.Nome = usuario.Nome;
            usu.Sobrenome = usuario.Sobrenome;
            usu.Email = usuario.Email;
            usu.DataNascimento = usuario.DataNascimento;
            usu.Escolaridade = usuario.Escolaridade;
            _contexto.SaveChanges();

            return Ok();

        }

        [HttpPost("DeleteUsuario")]
        public ActionResult DeleteUsuario(Usuario usuario)
        {

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();

            return Ok();

        }

    }
}
