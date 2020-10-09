using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManager.Domain.Entities;

namespace SalesManager.Persistence.Config
{
    public class OrderDetailConfig
    {
        public OrderDetailConfig(EntityTypeBuilder<OrderDetail> entityBuilder)
        {

        }
    }
}
