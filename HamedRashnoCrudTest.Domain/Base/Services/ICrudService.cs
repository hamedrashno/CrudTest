using HamedRashnoCrudTest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace HamedRashnoCrudTest.Domain.Base.Services
{
    public interface ICrudService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> All();
        bool Commit();
        bool Create(TEntity item, bool commit = true);
        bool Delete(TEntity item, bool commit = true);
        bool Update(TEntity updatedItem, bool commit = true);
    }
}
