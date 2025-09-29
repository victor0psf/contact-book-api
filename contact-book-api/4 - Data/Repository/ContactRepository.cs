using contact_book_api.Data;
using contact_book_api.IRepository;
using contact_book_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contact_book_api.Repository
{
    public class ContactRepository(AppDbContext context) : IContactRepository
    {
        private readonly AppDbContext _context = context;


        public async Task<ContactModel> Add(ContactModel contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactModel> Update(ContactModel contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> Delete(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return await Task.FromResult(contact != null);
        }

        public async Task<IEnumerable<ContactModel>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<ContactModel> Get(Guid id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}