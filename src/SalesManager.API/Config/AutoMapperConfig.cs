using AutoMapper;
using SalesManager.Domain.Dtos;
using SalesManager.Domain.Entities;
using SalesManager.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManager.API.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();
        }
    }
}
