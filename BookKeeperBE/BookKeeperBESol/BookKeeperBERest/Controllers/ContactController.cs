using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookKeeperBECommon.BusinessObjects;
using BookKeeperBECommon.Services;

namespace BookKeeperBERest.Controllers
{
    //[Route("api/controllers")]
    [ApiController]
    [Route("/api/contact")]

    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        private readonly ContatsService _ContatsService;



        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
            // Temporary solution
            _ContatsService = new ContatsService();
        }



        // REST API path: GET /api/users
        // REST API path: GET /api/users/?username=ba
        //public IEnumerable<User> Get()
        [HttpGet]
        public IActionResult Get([FromQuery] Contact contact)
        {
            IEnumerable<Contact> contats = _ContatsService.SearchContact(Contact);
            // HTTP status code: 200 (OK)
            return Ok(contats);
            //return users;
        }



        // REST API path: GET /api/users/3
        //public User Get(int id)
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Contact contact = new Contact { ID = id };
            try
            {
                contact = _ContatsService.LoadContact(id);
            }
            catch (Exception)
            {
                // No such user (non-existing ID).
                // HTTP status code: 404 (Not Found)
                return NotFound(new { id = contact.ID });
            }
            // HTTP status code: 200 (OK)
            return Ok(contact);
            // return user;
        }



        // REST API path: PUT /api/users
        // Data is in the request body in JSON format.
        // Therefore, we have an HTTP header of "Content-Type", with a value of "application/json".
        [HttpPut]
        public IActionResult Put(Contact contact)
        {
            _logger.LogInformation(contact.ToString());

            // Is there a user with the given ID?
            bool exists = _ContatsService.ExistsContact(contact.ID);
            if (!exists)
            {
                // HTTP status code: 404 (Not Found)
                return NotFound(contact);
            }

            // Update the user.
            _ContatsService.SaveContact(contact);

            // REST API recommends either a status code of 200 (OK) or 204 (No Content) to be returned.
            // HTTP status code: 200 (OK)
            //return Ok(user);
            // HTTP status code: 204 (No Content)
            return NoContent();
        }



        // REST API path: POST /api/users
        // Data is in the request body in JSON format.
        // Therefore, we have an HTTP header of "Content-Type", with a value of "application/json".
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            _logger.LogInformation(contact.ToString());

            // Add a new user.
            User newContact = _ContatsService.SaveContact(contact);

            // HTTP status code: 201 (Created)
            return Created(this.Request.Path, newContact);
        }



        // REST API path: DELETE /api/users/3
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation(id.ToString());

            // Is there a user with the given ID?
            bool exists = _ContatsService.ExistsContact(id);
            if (!exists)
            {
                // HTTP status code: 404 (Not Found)
                return NotFound(new { id = id });
            }

            // Delete the user.
            User ContactDeleted = _ContatsService.DeleteContact(id);

            // HTTP status code: 200 (OK)
            return Ok(ContactDeleted);
            //return Ok(new { id = userDeleted.ID });
        }
    }
}
