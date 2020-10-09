using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManager.Domain.Entities;

namespace SalesManager.Persistence.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                         .IsRequired()
                         .HasMaxLength(100);
        }
    }
}
