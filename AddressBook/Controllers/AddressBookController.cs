using AddressBook.Domain.Model;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class AddressBookController : Controller
    {

        private AddressBookReposatory _addressBookReposatory;

        public AddressBookController()
        {
            _addressBookReposatory = new AddressBookReposatory();
        }

        // GET: AddressBook
        [HttpGet]
        public ActionResult AddressBookLanding()
        {
            return View("AddressBookLanding");
        }

        [HttpGet]
        public ActionResult CreateAddressBookContact()
        {

            return View("CreateAddressBookContact");
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateAddressBookContact([Bind(Include = "Name,Company,Department,EmailAddress,Location,Elias,BusinessPhoneNumber")] AddressBookViewModel addressBookViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _addressBookReposatory.CreateAddressBookContact(new AddressBook.Domain.Model.AddressBook
                    {
                        AddressBookId = addressBookViewModel.AddressBookId,
                        Name = addressBookViewModel.Name,
                        Company = addressBookViewModel.Company,
                        EmailAddress = addressBookViewModel.EmailAddress,
                        Location = addressBookViewModel.Location,
                        Elias = addressBookViewModel.Elias,
                        BusinessPhoneNumber = addressBookViewModel.BusinessPhoneNumber,

                    });
                    ViewData["SuccessMessage"] = $"AddressContactBook{addressBookViewModel.Name} was successfully inserted";

                }
                catch (Exception ex)
                {
                    ViewData["EditError"] = ex.Message;

                }
            }

            //return View("Index");
            var model = PopulateAddressBookViewModel();

            return RedirectToAction("GetAddressBookList", model);
        }


     [HttpGet]
     public ActionResult searchByName(string name)
      { 
         if (!String.IsNullOrEmpty(name))
            {
                var record = _addressBookReposatory.SearchAddressBookContact(name);
                return View("GetAddressBookList", record);
            }
            return View();
        }

        public ActionResult GetAddressBookList([Bind(Include = "Name,BusinessPhoneNumber,Company,Department,EmailAddress,Location,Title")]AddressBookViewModel addressBookViewModel)
        {
            _addressBookReposatory.GetAllCreateAddressBookContact.Select(s => new AddressBookViewModel
            {
                AddressBookId = s.AddressBookId,
                BusinessPhoneNumber = s.BusinessPhoneNumber,
                Name = s.Name,
                Company = s.Company,
                Department = s.Department,
                EmailAddress = s.EmailAddress,
                Location = s.Location,
                Elias = s.Elias,
                Title = s.Title

            });
            var model = PopulateAddressBookViewModel();
            return View("GetAddressBookList", model);
        }
        public IQueryable<AddressBookViewModel> PopulateAddressBookViewModel()
        {
            var model = _addressBookReposatory.GetAllCreateAddressBookContact.Select(s => new AddressBookViewModel
            {
                AddressBookId = s.AddressBookId,
                BusinessPhoneNumber = s.BusinessPhoneNumber,
                Name = s.Name,
                Company = s.Company,
                Department = s.Department,
                EmailAddress = s.EmailAddress,
                Location = s.Location,
                Elias = s.Elias,
                Title = s.Title
            });
          return model;
        }
  }
}
