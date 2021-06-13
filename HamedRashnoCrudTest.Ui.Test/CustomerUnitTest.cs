using HamedRashnoCrudTest.Data;
using HamedRashnoCrudTest.Data.Contexts;
using HamedRashnoCrudTest.Data.Contexts.Interfaces;
using HamedRashnoCrudTest.Domain.Base.Services;
using HamedRashnoCrudTest.Service.EntityServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HamedRashnoCrudTest.Ui.Test
{
    [TestClass]
    public class CustomerUnitTest
    {
        private readonly ICustomerService _customerService;

        public CustomerUnitTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISqlDataContext, SqlDataContext>();
            //services.AddTransient<ICrudService, CrudService>();
            var serviceProvider = services.BuildServiceProvider();
            _customerService = serviceProvider.GetService<ICustomerService>();

        }

        [TestMethod]
        public void CreateMethod()
        {
            var beforCount = _customerService.All().Count();
            _customerService.Create(new Domain.Customer.CustomerEntity
            {
                BankAccountNumber = "1",
                DateOfBirth = DateTime.Now,
                Email="Some@One.com",
                FirstName="Hamed",
                LastName="Rashno",
                PhoneNumber=9358355040,
            });
            
            var afterCount = _customerService.All().Count();
            Assert.AreEqual(beforCount + 1, afterCount);
        }

        [TestMethod]
        public void DeleteMethod()
        {
            var toDeleteCustomer = _customerService.All().First();

            _customerService.Delete(toDeleteCustomer);

            var currentCustomer = _customerService.All().First();

            Assert.AreEqual(currentCustomer.Deleted, true);
        }


        [TestMethod]
        public void UpdateMethod()
        {
            var toUpdateCustomer = _customerService.All().First();
            var currentDateTime = DateTime.Now;

            toUpdateCustomer.DateOfBirth = currentDateTime;

            _customerService.Update(toUpdateCustomer);

            var currentCustomer = _customerService.All().First(c=>c.Id== toUpdateCustomer.Id);

            Assert.AreEqual(currentCustomer.DateOfBirth, currentDateTime);
        }
    }
}
