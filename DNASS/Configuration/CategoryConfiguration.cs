﻿using DNASS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNASS.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(category => category.Product)
                .WithOne(product => product.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
