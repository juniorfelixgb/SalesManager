using SalesManager.Domain.Dtos;
using SalesManager.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Service.Services
{
    public interface IOrderService
    {
        Task<DataCollection<OrderDto>> GetAllAsync();
        Task<OrderDto> GetAsync(int Id);
        Task<OrderDto> CreateAsync(OrderCreateDto model);
        Task UpdateAsync(int Id, OrderUpdateDto model);
        Task DeleteAsync(int Id);
    }

    public class OrderService : IOrderService
    {
        public Task<OrderDto> CreateAsync(OrderCreateDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<DataCollection<OrderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int Id, OrderUpdateDto model)
        {
            throw new NotImplementedException();
        }
    }
}
