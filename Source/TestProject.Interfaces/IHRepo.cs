using System;
using System.Linq;

namespace TestProject.Interfaces
{
    public interface IHRepo<TEntity>
        : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> Set();

    }
}
