using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HamedRashnoCrudTest.Domain.Base.Services;
using HamedRashnoCrudTest.Domain.Customer;
using HamedRashnoCrudTest.Domain.Customer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HamedRashnoCrudTest.Ui.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var model = _customerService.All().Where(c => !c.Deleted).Select(c => new CustomerListViewModel
            {
                Email = c.Email,
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName
            });
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            var entity = new CustomerEntity
            {
                BankAccountNumber = model.BankAccountNumber,
                LastName = model.LastName,
                FirstName = model.FirstName,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
            _customerService.Create(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var entity = _customerService.All().FirstOrDefault(c => c.Id == id);
            var model = new CustomerDetailsViewModel
            {
                Email = entity.Email,
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BankAccountNumber = entity.BankAccountNumber,
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.PhoneNumber
            };
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var entity = _customerService.All().FirstOrDefault(c => c.Id == id);
            if (entity == null) return RedirectToAction("Index");
            var model = new CustomerEditViewModel
            {
                Email = entity.Email,
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BankAccountNumber = entity.BankAccountNumber,
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.PhoneNumber,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerEditViewModel model)
        {
            var entity = _customerService.All().FirstOrDefault(c => c.Id == model.Id);
            if(entity==null) return RedirectToAction("Index");

            entity.Email = entity.Email;
            entity.Id = entity.Id;
            entity.FirstName = entity.FirstName;
            entity.LastName = entity.LastName;
            entity.BankAccountNumber = entity.BankAccountNumber;
            entity.DateOfBirth = entity.DateOfBirth;
            entity.PhoneNumber = entity.PhoneNumber;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var entity = _customerService.All().FirstOrDefault(c => c.Id == id);
            if (entity != null)
                _customerService.Delete(entity);

            return RedirectToAction("Index");
        }
    }
}