﻿using System.Data;
using ClashRoyaleRestAPI.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ClashRoyaleDbContext _context;
    public UnitOfWork(ClashRoyaleDbContext context)
    {
        _context = context;
    }
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }
}
