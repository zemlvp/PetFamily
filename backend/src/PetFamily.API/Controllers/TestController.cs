/*using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Volunters;

namespace PetFamily.API.Controllers;

public class TestController : ControllerBase
{
    // GET
    public IActionResult Get(string fullName, string email)
    {
        var volunterResult = Volunter.Create(Guid.NewGuid(), fullName, email);

        if (volunterResult.IsFailure)
            return BadRequest(volunterResult.Error);
        
        SaveVolunter(volunterResult.Value);
        
        return Ok();
    }

    public void SaveVolunter(Volunter volunter)
    {
    }
}*/