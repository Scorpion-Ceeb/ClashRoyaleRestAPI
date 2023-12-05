﻿using ClashRoyaleRestAPI.Domain.Shared;
using System.Net;

namespace ClashRoyaleRestAPI.Domain.Errors;

public static partial class ErrorTypes
{
    public static class Instances
    {
        public static Error None() => new(
                HttpStatusCode.InternalServerError,
                string.Empty,
                string.Empty);
        public static Error NullValue() => new(
                HttpStatusCode.InternalServerError,
                ErrorCode.NullValue,
                "The specific result value is null");
        public static Error Internal(string message) => new(
                HttpStatusCode.InternalServerError,
                ErrorCode.Internal,
                message);
    }
}
