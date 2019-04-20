using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;

namespace ContactForm.Contact
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly IDbConnection connection;
        readonly IDbTransaction dbTransaction;

        public ContactController(IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            this.connection = dbConnection;
            this.dbTransaction = dbTransaction;
        }


        [HttpGet]
        public ActionResult<ContactModel> Get()
        {
            return new ContactModel() {
                ContactName = null,
                Email = null,
                Comment = null,
                Actions = new ContactModelAction() {
                    Submit = new Uri("/api/contact", UriKind.Relative)
                }
            };
        }

        [HttpPost]
        public async Task<ActionResult<ContactModel>> Post(ContactModel model)
        {
            await connection.ExecuteAsync(
                @"Insert Contact (ContactId, ContactName, Email, Comment, SubmittedAt) 
                    values (@ContactId, @ContactName, @Email, @Comment, @SubmittedAt)",
                new ContactFormDatabaseModel() {
                    ContactId = Guid.NewGuid(),
                    ContactName = model.ContactName,
                    Email = model.Email,
                    Comment = model.Comment,
                    SubmittedAt = DateTimeOffset.Now
                },
                dbTransaction
            );

            return model;

        }

    }
}
