using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Dtos;
using SalesManager.Domain.Entities;
using SalesManager.Persistence;
using SalesManager.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Service.Services
{
    public interface IProductService
    {
        Task<DataCollection<ProductDto>> GetAllAsync();
        Task<ProductDto> GetAsync(int Id);
        Task<ProductDto> CreateAsync(ProductCreateDto model);
        Task UpdateAsync(int Id, ProductUpdateDto model);
        Task DeleteAsync(int Id);
    }

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(ProductCreateDto model)
        {
            var entity = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<DataCollection<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetAsync(int Id)
        {
            return _mapper.Map<ProductDto>(await _context.Products
                                                         .FirstOrDefaultAsync(p => p.Id == Id));
        }

        public Task UpdateAsync(int Id, ProductUpdateDto model)
        {
            throw new NotImplementedException();
        }
    }
}
