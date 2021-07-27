using RaroLabs.Cep.Domain.Entities;
using System.Threading.Tasks;

namespace RaroLabs.Cep.Domain.Services
{
    public interface IEnderecoService
    {
        public Task<Endereco> BuscarEndereco(string cep);
    }
}
