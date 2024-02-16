using Contacts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ContactsController(ApplicationDbContext data)
        {
            context = data;
        }

        public
    }
}
