using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnatrixWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientContactController : ControllerBase
{
    private readonly ClientContactService _contactService;

    public ClientContactController(ClientContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public IActionResult Create(ClientContactDto clientContactDto)
    {
		try
		{
			if (ModelState.IsValid)
			{
                var newClientContact = _contactService.Create(clientContactDto);
                if (newClientContact)
                {
                    return Ok();
                }

                return Conflict();
            }
			
		}
		catch (Exception)
		{

			throw;
		}
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var existingClientContacts = _contactService.GetAll();
            if (existingClientContacts != null)
            {
                return Ok(existingClientContacts); 
            }

            if (existingClientContacts == null) 
            { 
                return NotFound(); 
            }           
            
        }
        catch (Exception)
        {

            throw;
        }
        return BadRequest();
    }

    [HttpGet("{email}")]
    public IActionResult GetOne(string email)
    {
        try
        {
            var existingClientContact = _contactService.GetOne(email);
            if (existingClientContact != null)
            {
                return Ok(existingClientContact);
            }

            if (existingClientContact == null)
            {
                return NotFound();
            }

        }
        catch (Exception)
        {

            throw;
        }
        return BadRequest();
    }
}
