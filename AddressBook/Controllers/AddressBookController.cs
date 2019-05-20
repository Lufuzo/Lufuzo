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
     
        [HttpPost]
        public ActionResult CreateAddressBookContact([Bind(Include = "Name,Title,Company,Department,EmailAddress,Location,Elias,BusinessPhoneNumber")] AddressBookViewModel addressBookViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _addressBookReposatory.CreateAddressBookContact(new AddressBook.Domain.Model.AddressBook
                    {
                        AddressBookId = addressBookViewModel.AddressBookId,
                        Name = addressBookViewModel.Name,
                        Title = addressBookViewModel.Title,
                        Company = addressBookViewModel.Company,
                        EmailAddress = addressBookViewModel.EmailAddress,
                        Location = addressBookViewModel.Location,
                        Elias = addressBookViewModel.Elias,
                        BusinessPhoneNumber = addressBookViewModel.BusinessPhoneNumber,
                        Department = addressBookViewModel.Department

                    });
                    ViewData["SuccessMessage"] = $"AddressContactBook{addressBookViewModel.Name} was successfully inserted";
                    var model = PopulateAddressBookViewModel();
                    ViewBag.Error = "Fail creating address book model not valid";

                    return RedirectToAction("GetAddressBookListAll", model);

                }
                catch (Exception ex)
                {
                    ViewData["Error in creating"] = ex.Message;

                }
            }

            //return View("Index");
          
            ViewBag.Error = "Fail creating address book model not valid";

            return View("CreateAddressBookContact");
        }


     //[HttpGet]
     public ActionResult GetAddressBookList(string searchByName, string search)
      {
          var rec = new  AddressBookViewModel();
         if (searchByName == "Name")
            {
                var record = _addressBookReposatory.SearchAddressBookContact(search).FirstOrDefault();
               
                rec.AddressBookId = record.AddressBookId;
                rec.BusinessPhoneNumber = record.BusinessPhoneNumber;
                rec.Name = record.Name;
                rec.Company = record.Company;
                rec.Department = record.Department;
                rec.EmailAddress = record.EmailAddress;
                rec.Location = record.Location;
                rec.Elias = record.Elias;
                rec.Title = record.Title;
                var recordDetail = new List<AddressBookViewModel> { rec };

                return View("GetAddressBookList", recordDetail);
              
            }
         return View("GetAddressBookList");


        }

        public ActionResult GetAddressBookListAll([Bind(Include = "Name,BusinessPhoneNumber,Company,Department,EmailAddress,Location,Title")]AddressBookViewModel addressBookViewModel)
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
