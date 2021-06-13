using HamedRashnoCrudTest.Data.Contexts.Interfaces;
using HamedRashnoCrudTest.Domain.Base;
using HamedRashnoCrudTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HamedRashnoCrudTest.Domain.Base.Services;

namespace HamedRashnoCrudTest.Data
{
    public abstract class CrudService<TEntity> : ICrudService<TEntity> where TEntity : BaseEntity
    {
        private readonly ISqlDataContext _unitOfWork;

        protected CrudService(ISqlDataContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IQueryable<TEntity> All()
        {
            return _unitOfWork.EntitySet<TEntity>();
        }



        public bool Commit()
        {
            return _unitOfWork.Commit() > 0;
        }

        public bool Create(TEntity item, bool commit = true)
        {
            _unitOfWork.EntitySet<TEntity>().Add(item);
            if (commit) return Commit();
            return true;
        }

        public bool Delete(TEntity item, bool commit = true)
        {
            item.Deleted = true;
            if (commit)
            {
                if (Commit()) return true;
                else return false;
            }
            else return false;
        }

        public bool Update(TEntity updatedItem, bool commit = true)
        {
            if (updatedItem == null) return false;
            _unitOfWork.SetModified(updatedItem);
            if (commit) return Commit();
            return true;
        }
    }
}
