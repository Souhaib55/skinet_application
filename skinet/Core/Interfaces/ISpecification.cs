using System;
using System.Linq.Expressions;

namespace Core.Interfaces;

public interface ISpecification<T> // specification pattern
{
    Expression <Func<T, bool>>? Criteria { get; }   // Where
    Expression<Func<T, object>>? OrderBy { get; }   // OrderBy
    Expression<Func<T, object>>? OrderByDescending { get; } // OrderByDescending

    bool IsDistinct { get; } // Distinct

}


public interface ISpecification<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>>? Select { get; } 

}
