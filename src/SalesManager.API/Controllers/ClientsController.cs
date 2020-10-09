using Microsoft.AspNetCore.Mvc;
using SalesManager.Domain.Dtos;
using SalesManager.Service.Common;
using SalesManager.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            return await _clientService.GetAllAsync();
        }
        
        // GET: Clients/
        [HttpGet("{page}/{take}")]
        public async Task<DataCollection<ClientDto>> GetPaging(int page, int take = 10)
        {
            return await _clientService.GetAllAsync(page, take);
        }

        // GET: Clients/1
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var client = await _clientService.GetByIdAsync(Id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateDto model)
        {
            var result = await _clientService.CreateAsync(model);
            return CreatedAtAction("Get", new { result.Id }, result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, ClientUpdateDto model)
        {
            await _clientService.UpdateAsync(Id, model);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _clientService.DeleteAync(Id);
            return NoContent();
        }
    }
}
