using System;

namespace ContactForm.Contact
{
    public class ContactFormDatabaseModel
    {
        public Guid? ContactId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset SubmittedAt { get; set; }
    }
}
