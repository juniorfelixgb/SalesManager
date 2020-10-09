using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManager.Domain.Dtos
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }
    }

    public class ClientUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
