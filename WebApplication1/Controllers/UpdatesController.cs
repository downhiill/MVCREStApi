using Microsoft.AspNetCore.Mvc;
using WebApplication1;

[Route("api/updates")]
[ApiController]
public class UpdatesController : ControllerBase
{
    private static readonly Dictionary<Guid, Update> Updates = new();

    // Метод для обработки POST-запросов с массивом объектов Update
    [HttpPost("complex")]
    public IActionResult PostComplex([FromForm] Update[] updates)
    {
        if (updates != null && ModelState.IsValid)
        {
            foreach (var update in updates)
            {
                update.Status = System.Net.WebUtility.HtmlEncode(update.Status);

                var id = Guid.NewGuid();
                Updates[id] = update;
            }

            return Ok("Updates processed successfully");
        }

        return BadRequest("Invalid data");
    }

    // Метод для обработки GET-запроса: api/updates/status/{id}
    [HttpGet("status/{id}")]
    public IActionResult Status(Guid id)
    {
        if (Updates.TryGetValue(id, out var update))
        {
            return Ok(update);
        }
        return NotFound("Update not found");
    }
}
