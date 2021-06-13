using HamedRashnoCrudTest.Data;
using HamedRashnoCrudTest.Data.Contexts.Interfaces;
using HamedRashnoCrudTest.Domain.Base.Services;
using HamedRashnoCrudTest.Domain.Customer;

namespace HamedRashnoCrudTest.Service.EntityServices
{
    public class CustomerService : CrudService<CustomerEntity>, ICustomerService
    {
        ISqlDataContext _unitOfWork;
        public CustomerService(ISqlDataContext unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
