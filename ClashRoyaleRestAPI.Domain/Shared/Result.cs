﻿using ClashRoyaleRestAPI.Domain.Errors;

namespace ClashRoyaleRestAPI.Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != ErrorTypes.Instances.None())
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == ErrorTypes.Instances.None())
        {
            throw new InvalidOperationException();
        }
        IsSuccess = isSuccess;
        Errors = new[] { error };
    }
    protected internal Result(bool isSuccess, Error[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error[] Errors { get; }

    public static Result Success() => new(true, ErrorTypes.Instances.None());

    public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, ErrorTypes.Instances.None());

    public static Result Failure(Error error) =>
        new(false, error);
    public static Result Failure(Error[] errors) =>
        new(false, errors);

    public static Result<TValue> Failure<TValue>(Error error) =>
        new(default, false, error);

    public static Result<TValue> Failure<TValue>(Error[] errors) =>
        new(default, false, errors);

    public static Result<TValue> Create<TValue>(TValue value) =>
        value is not null ? Success(value) : Failure<TValue>(ErrorTypes.Instances.NullValue());


}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }
    protected internal Result(TValue? value, bool isSuccess, Error[] errors)
        : base(isSuccess, errors)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of the failure can not be accessed");

    public static implicit operator Result<TValue>(TValue value) => Create(value);

}
