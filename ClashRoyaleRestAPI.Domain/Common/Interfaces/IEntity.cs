﻿namespace ClashRoyaleRestAPI.Domain.Common.Interfaces
{
    public interface IEntity<T>
    {
        public T Id { get; }
    }
}
