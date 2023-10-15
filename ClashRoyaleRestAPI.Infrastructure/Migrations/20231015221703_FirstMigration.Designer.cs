﻿// <auto-generated />
using System;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClashRoyaleRestAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ClashRoyaleDbContext))]
    [Migration("20231015221703_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.ClanPlayersModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ClanId");

                    b.HasIndex("ClanId");

                    b.ToTable("PlayerClans");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.ClanWarsModel", b =>
                {
                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("WarId")
                        .HasColumnType("int");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.HasKey("ClanId", "WarId");

                    b.HasIndex("WarId");

                    b.ToTable("ClanWars");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.CollectionModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.DonationModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ClanId", "CardId");

                    b.HasIndex("CardId");

                    b.HasIndex("ClanId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.PlayerChallengesModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("PrizeAmount")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ChallengeId");

                    b.HasIndex("ChallengeId");

                    b.ToTable("PlayerChallenges");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Battle.BattleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountTrophies")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("int");

                    b.Property<int?>("LoserId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoserId");

                    b.HasIndex("WinnerId", "LoserId", "Date")
                        .IsUnique()
                        .HasFilter("[WinnerId] IS NOT NULL AND [LoserId] IS NOT NULL");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Card.CardModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AreaDamage")
                        .HasColumnType("bit");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Elixir")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InitialLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<int>("Target")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasDiscriminator<int>("Type").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Challenge.ChallengeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountReward")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInHours")
                        .HasColumnType("int");

                    b.Property<int>("LossLimit")
                        .HasColumnType("int");

                    b.Property<int>("MinLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Clan.ClanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountMembers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinTrophies")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("TrophiesInWar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool>("TypeOpen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Clans");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("CardAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Elo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("FavoriteCardId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("MaxElo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Victories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("FavoriteCardId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.War.WarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Wars");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Card.Implementation.SpellModel", b =>
                {
                    b.HasBaseType("ClashRoyaleRestAPI.Domain.Models.Card.CardModel");

                    b.Property<int>("LifeTime")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("LifeTime");

                    b.Property<float>("Radius")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Radius");

                    b.Property<int>("TowerDamage")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Card.Implementation.StructureModel", b =>
                {
                    b.HasBaseType("ClashRoyaleRestAPI.Domain.Models.Card.CardModel");

                    b.Property<int>("HitPoints")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("HitPoints");

                    b.Property<float>("HitSpeed")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("HitSpeed");

                    b.Property<int>("LifeTime")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("LifeTime");

                    b.Property<float>("Radius")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Radius");

                    b.Property<float>("Range")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Range");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Card.Implementation.TroopModel", b =>
                {
                    b.HasBaseType("ClashRoyaleRestAPI.Domain.Models.Card.CardModel");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("HitPoints");

                    b.Property<float>("HitSpeed")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("HitSpeed");

                    b.Property<float>("Range")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Range");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Transport")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.ClanPlayersModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Clan.ClanModel", "Clan")
                        .WithMany("Players")
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.ClanWarsModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Clan.ClanModel", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.War.WarModel", "War")
                        .WithMany()
                        .HasForeignKey("WarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("War");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.CollectionModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Card.CardModel", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", "Player")
                        .WithMany("Cards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.DonationModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Card.CardModel", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Clan.ClanModel", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Clan");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Common.Relationships.PlayerChallengesModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Challenge.ChallengeModel", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Battle.BattleModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", "Loser")
                        .WithMany()
                        .HasForeignKey("LoserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Loser");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", b =>
                {
                    b.HasOne("ClashRoyaleRestAPI.Domain.Models.Card.CardModel", "FavoriteCard")
                        .WithMany()
                        .HasForeignKey("FavoriteCardId");

                    b.Navigation("FavoriteCard");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Clan.ClanModel", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("ClashRoyaleRestAPI.Domain.Models.Player.PlayerModel", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
