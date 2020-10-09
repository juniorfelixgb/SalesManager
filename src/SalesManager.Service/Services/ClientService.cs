using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Dtos;
using SalesManager.Domain.Entities;
using SalesManager.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManager.Service.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
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

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _context.Clients.ToListAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
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
