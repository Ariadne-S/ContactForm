using System;
using System.ComponentModel.DataAnnotations;

namespace ContactForm.Contact
{
    public class ContactModel
    {
        [Required, MaxLength(100), MinLength(2)]
        public string ContactName { get; set; }
        [Required, MaxLength(100), MinLength(2)]
        public string Email { get; set; }
        [Required, MaxLength(1000), MinLength(2)]
        public string Comment { get; set; }

        public ContactModelAction Actions { get; set; }
    }

    public class ContactModelAction
    {
        public Uri Submit;
    }
}
