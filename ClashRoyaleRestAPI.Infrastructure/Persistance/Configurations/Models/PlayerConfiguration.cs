﻿using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Configurations.Models;

public class PlayerConfiguration : IEntityTypeConfiguration<PlayerModel>
{
    public void Configure(EntityTypeBuilder<PlayerModel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ValueObjectId.Create<PlayerId>(value));

        builder.Property(p => p.Alias)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(p => p.Level)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(p => p.Victories)
            .HasDefaultValue(0);

        builder.Property(p => p.CardAmount)
            .HasDefaultValue(0);

        builder.Property(p => p.MaxElo)
            .HasDefaultValue(0);

        builder.Property(p => p.Elo)
            .HasDefaultValue(0);

        builder.HasOne(p => p.FavoriteCard)
            .WithMany()
            .HasForeignKey("FavoriteCardId")
            .IsRequired(false);

        var navigation = builder.Metadata.FindNavigation(nameof(PlayerModel.Cards));

        navigation!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
