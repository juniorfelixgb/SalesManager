using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManager.Domain.Entities;

namespace SalesManager.Persistence.Config
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> entityBuilder)
        {

        }
    }
}
