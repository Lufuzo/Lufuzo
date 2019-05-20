using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Model
{
    public interface IAddressBookReposatory
    {
        bool CreateAddressBookContact(AddressBook account);
        IQueryable<AddressBook> GetAllCreateAddressBookContact { get; }
        IEnumerable<AddressBook> SearchAddressBookContact(string name);

    }
}
