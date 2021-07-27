using AutoMapper;
using RaroLabs.Cep.Domain.Entities;
using RaroLabs.Cep.Domain.Services;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RaroLabs.Cep.Infrastructure.Integrations.ViaCep
{
    public class ViaCepService : IEnderecoService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly JsonSerializerOptions _serializerOptions;

        public ViaCepService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

        public async Task<Endereco> BuscarEndereco(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var viaCepResponse = JsonSerializer.Deserialize<ViaCepResponse>(responseContent, _serializerOptions);
                return _mapper.Map<Endereco>(viaCepResponse);
            }

            return new Endereco();
        }
    }
}
