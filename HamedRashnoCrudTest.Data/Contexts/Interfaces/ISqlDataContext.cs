using HamedRashnoCrudTest.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HamedRashnoCrudTest.Data.Contexts.Interfaces
{
    public interface ISqlDataContext
    {
        SqlDataContext Context { get; }

        DbSet<TEntity> EntitySet<TEntity>() where TEntity : BaseEntity;

        void SetModified<TEntity>(TEntity item) where TEntity : BaseEntity;
        int Commit();

    }
}
