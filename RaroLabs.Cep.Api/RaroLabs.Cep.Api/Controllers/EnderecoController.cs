using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RaroLabs.Cep.Api.Models;
using RaroLabs.Cep.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RaroLabs.Cep.Api.Controllers
{
    /// <summary>
    /// Serviço para busca de endereço
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService enderecoService, IMapper mapper)
        {
            _enderecoService = enderecoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Realiza a busca de endereço a partir do CEP informado.
        /// </summary>
        /// <param name="cep">CEP a ser buscado (apenas números)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            if (cep.Any(c => !char.IsDigit(c)))
                return BadRequest("CEP inválido. Informar apenas números.");            

            var endereco = await _enderecoService.BuscarEndereco(cep);

            return Ok(_mapper.Map<EnderecoResponse>(endereco));
        }
    }
}
