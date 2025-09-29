using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact_book_api.Models;

namespace contact_book_api.IRepository
{
    public interface IContactRepository
    {
        public Task<ContactModel> Add(ContactModel contact);
        public Task<ContactModel> Update(ContactModel contact);
        public Task<bool> Delete(Guid id);
        public Task<IEnumerable<ContactModel>> GetAll();
        public Task<ContactModel> Get(Guid id);

    }
}