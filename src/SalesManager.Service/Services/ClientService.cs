using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Dtos;
using SalesManager.Domain.Entities;
using SalesManager.Persistence;
using SalesManager.Service.Common;
using SalesManager.Service.Extentions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManager.Service.Services
{
    public interface IClientService
    {
        Task<DataCollection<ClientDto>> GetAllAsync(int page, int take);
        Task<ClientDto> GetByIdAsync(int Id);
        Task<ClientDto> CreateAsync(ClientCreateDto model);
        Task UpdateAsync(int Id, ClientUpdateDto model);
        Task DeleteAync(int Id);
    }
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ClientService(ApplicationDbContext context,
                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<ClientDto>> GetAllAsync(int page, int take)
        {
            return _mapper.Map<DataCollection<ClientDto>>(
                    await _context.Clients.OrderByDescending(c => c.Id)
                                          .AsQueryable()
                                          .PagedAsync(page, take)
                );
        }

        public async Task<ClientDto> GetByIdAsync(int Id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == Id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> CreateAsync(ClientCreateDto model)
        {
            var entity = new Client { Name = model.Name };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return  _mapper.Map<ClientDto>(entity);
        }

        public async Task UpdateAsync(int Id, ClientUpdateDto model)
        {
            var entity = await _context.Clients.FirstOrDefaultAsync(c => c.Id == Id);
            entity.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAync(int Id)
        {
            var entity = await _context.Clients.FirstOrDefaultAsync(c => c.Id == Id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
