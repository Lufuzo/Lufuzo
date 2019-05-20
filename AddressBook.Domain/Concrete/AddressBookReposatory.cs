
using AddressBook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Model
{
    public class AddressBookReposatory : IAddressBookReposatory
    {
        private OutLookAddressBookEntities _dbContext;

        public AddressBookReposatory()
        {
            _dbContext = new OutLookAddressBookEntities();
        }


        public bool CreateAddressBookContact(AddressBook addressBook)
        {

            try
            {
                if (addressBook.AddressBookId == 0)
                {
                    _dbContext.AddressBooks.Add(addressBook);
                }
                else
                {
                    var addressBookRecord = _dbContext.AddressBooks.Where(x => x.AddressBookId == addressBook.AddressBookId).FirstOrDefault();
                    if (addressBookRecord != null)
                    {
                        addressBookRecord.BusinessPhoneNumber = addressBook.BusinessPhoneNumber;
                        addressBookRecord.Name = addressBook.Name;
                        addressBookRecord.Company = addressBook.Company;
                        addressBookRecord.Department = addressBook.Department;
                        addressBookRecord.EmailAddress = addressBook.EmailAddress;
                        addressBookRecord.Location = addressBook.Location;
                        addressBookRecord.Elias = addressBook.Elias;
                        addressBookRecord.Title = addressBook.Title;

                    }
                    else
                    {
                        throw new Exception("Record does not exist");
                    }
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public IQueryable<AddressBook> GetAllCreateAddressBookContact
        {
            get { return _dbContext.AddressBooks; }
        }

        public IEnumerable<AddressBook> SearchAddressBookContact(string name)
        {

            List<string> listNames = new List<string>();
            if (name != null)
            {
                return _dbContext.AddressBooks.Where(x => x.Name.StartsWith(name));
                //return record;
            }
            else
            {
                throw new Exception("Record does not exist");
            }

        }
    }
}

