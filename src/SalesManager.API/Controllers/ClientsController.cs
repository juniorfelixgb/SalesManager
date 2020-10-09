using Microsoft.AspNetCore.Mvc;
using SalesManager.Domain.Dtos;
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
        
        // GET: Clients/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
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
            return CreatedAtAction("Get", new { Id = result.Id }, result);
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
