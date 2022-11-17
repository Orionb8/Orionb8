using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestProject.Interfaces;

namespace TestProject.Mvc.Repo
{
	public class BaseHRepo<TEntity> : IHRepo<TEntity> where TEntity : class, new()
    {

        protected DbContext _ctx;

        public BaseHRepo(DbContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
        }

        public IQueryable<TEntity> Set()
        {
            return _ctx
                .Set<TEntity>()
                .AsQueryable();
        }
    }
}

