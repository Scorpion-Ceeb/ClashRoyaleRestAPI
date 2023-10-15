﻿using ClashRoyaleRestAPI.Domain.Common.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Relationships
{
    public class ClanWarsConfiguration : IEntityTypeConfiguration<ClanWarsModel>
    {
        public void Configure(EntityTypeBuilder<ClanWarsModel> builder)
        {
            builder.Property<int>("WarId");
            builder.Property<int>("ClanId");

            builder.HasKey("ClanId", "WarId");
            
            builder.HasOne(c => c.War)
                .WithMany()
                .HasForeignKey("WarId");
            
            builder.HasOne(c => c.Clan)
                .WithMany()
                .HasForeignKey("ClanId");

        }
    }
}
