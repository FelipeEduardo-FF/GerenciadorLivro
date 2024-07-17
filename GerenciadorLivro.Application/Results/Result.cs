using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciadorLivro.Application.Results
{

    public class Result : IResultBase
    {

        public Error Error => _error;
        public bool Success => _error == null;

        private readonly Error _error;


        private Result(Error error)
        {
            _error = error;
        }
        private Result()
        {
        }


        // Implicitamente chama new Result
        public static Result Ok() => new Result();
        // Implicitamente chama new Error
        public static implicit operator Result(Error error) => new Result(error);

        public T Match<T>(Func<T> success, Func<Error, T> failure)
        {
            return Success ? success() : failure(Error);
        }
    }

    public class Result<TValue> : IResultBase
    {
        public readonly TValue? Value;
        public Error Error { get; private set; }
        public bool Success { get; }

        private Result(TValue value)
        {
            Success = true;
            Value = value;
            Error = default!;
        }

        private Result(Error error)
        {
            Success = false;
            Value = default!;
            Error = error;
        }
        // Implicitamente chama new Result
        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);
        // Implicitamente chama new Error
        public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);

        public T Match<T>(Func<TValue, T> success, Func<Error, T> failure)
        {
            if (Success)
            {
                return success(Value!);
            }
            return failure(Error);
        }
    }

}
