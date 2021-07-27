using AutoMapper;
using RaroLabs.Cep.Api.Models;
using RaroLabs.Cep.Domain.Entities;
using RaroLabs.Cep.Infrastructure.Integrations.ViaCep;

namespace RaroLabs.Cep.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Endereco, EnderecoResponse>();
            CreateMap<ViaCepResponse, Endereco>();
        }
    }
}
