﻿namespace ClashRoyaleRestAPI.Domain.Common.Interfaces
{
    public interface IEntity<TId>
    {
        public TId Id { get; }
    }
}
