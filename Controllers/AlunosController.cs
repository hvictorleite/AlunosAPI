using AlunosAPI.Models;
using AlunosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        /*[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]*/
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosByNome([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                
                if (alunos.Count() == 0)
                    return NotFound($"Não existem alunos com o critério '{nome}'");

                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }
    }
}
