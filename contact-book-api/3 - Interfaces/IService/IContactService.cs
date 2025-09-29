
using contact_book_api.Models;

namespace contact_book_api.Interfaces.IService;

public interface IContactService
{
    Task<ContactModel> Add(ContactModel contact);

    Task<ContactModel> Update(ContactModel contact, Guid id);

    Task<bool> Delete(Guid id);

    Task<List<ContactModel>> GetAll();

    Task<ContactModel> GetById(Guid id);

}