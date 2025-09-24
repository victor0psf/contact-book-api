using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contact_book_api.Models
{
    public class AgendaModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = null!;

        public List<ContactModel> Contacts { get; set; } = new List<ContactModel>();

    }
}