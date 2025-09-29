using contact_book_api.Interfaces.IService;
using contact_book_api.IRepository;
using contact_book_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace contact_book_api._2___Domain.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<ContactModel> Add(ContactModel contact)
    {
        if (string.IsNullOrEmpty(contact.Name) || string.IsNullOrEmpty(contact.PhoneNumber) || string.IsNullOrEmpty(contact.Email))
        {
            return null;//tratar mensagem de erro
        }

        await _contactRepository.Add(contact);
        return contact;

    }
    public async Task<ContactModel> Update(ContactModel contact, Guid id)
    {
        var contactExistente = await _contactRepository.Get(id);

        if (contactExistente == null)
            return null;

        await _contactRepository.Update(contact);

        return contactExistente;

    }
    public async Task<bool> Delete(Guid id)
    {

        var contactExistente = await _contactRepository.Get(id);

        if (contactExistente == null)
            return false;

        await _contactRepository.Delete(id);

        return true;
    }
    public async Task<List<ContactModel>> GetAll()
    {
        var registros = await _contactRepository.GetAll();

        if (registros == null)
            return null;

        return registros.ToList();
    }
    public async Task<ContactModel> GetById(Guid id)
    {
        var contact = await _contactRepository.Get(id);

        if (contact == null)
            return null;

        return contact;
    }
}


