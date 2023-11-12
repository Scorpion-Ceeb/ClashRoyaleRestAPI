﻿using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Infrastructure.Common;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers;
using ClashRoyaleRestAPI.Infrastructure.Repositories;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Auth;
using ClashRoyaleRestAPI.Infrastructure.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleRestAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
             {
                 options.Password.RequireDigit = true;
                 options.Password.RequireLowercase = true;
                 options.Password.RequireUppercase = true;
                 options.Password.RequiredLength = 6;
             });

            AddPersistance(services);

            AddScopeds(services);

            services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>)); //Important circular reference

            return services;
        }
        private static void AddScopeds(IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IBattleRepository, BattleRepository>();
            services.AddScoped<IClanRepository, ClanRepository>();
            services.AddScoped<IWarRepository, WarRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

            services.AddScoped<IPredefinedQueries, PredefinedQuery>();
        }

        private static void AddPersistance(IServiceCollection services)
        {
            services.AddDbContext<ClashRoyaleDbContext>(options =>
            {
                options.UseSqlServer(DbSettings.ConnectionName);
                options.UseTriggers(triggerOpt =>
                {
                    triggerOpt.AddTrigger<UpdateCardAmountTrigger>();
                    triggerOpt.AddTrigger<UpdateMaxEloInsertPlayerTrigger>();
                    triggerOpt.AddTrigger<UpdateDateBattleTrigger>();
                    triggerOpt.AddTrigger<UpdatePlayerStatsInsertBattleTrigger>();
                    triggerOpt.AddTrigger<UpdateAmountClanMembersTrigger>();
                });
            });
        }
    }
}
