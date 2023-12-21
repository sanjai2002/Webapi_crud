using Microsoft.AspNetCore.Mvc;
namespace UpdateApi.Controllers;
using UpdateApi.Models;
using UpdateApi.Data;
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }
    [Route("Updateuser")]
    [HttpPut]
    public async Task<IActionResult> Updateuser(UserModel userdata)
    {
        if (userdata == null || userdata.Id == 0)
            return BadRequest();

        var user = await _context.Users.FindAsync(userdata.Id);
        if (user == null)
            return NotFound();
        user.Username = userdata.Username;
        user.EmailId = userdata.EmailId;
        user.Password = userdata.Password;
        await _context.SaveChangesAsync();
        return Ok();
    }

}

