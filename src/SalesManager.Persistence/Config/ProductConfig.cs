﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManager.Domain.Entities;

namespace SalesManager.Persistence.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                         .IsRequired()
                         .HasMaxLength(100);
            entityBuilder.Property(x => x.Description)
                         .IsRequired()
                         .HasMaxLength(250);
        }
    }
}
