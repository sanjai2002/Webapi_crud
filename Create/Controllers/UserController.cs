using Microsoft.AspNetCore.Mvc;
namespace Create.Controllers;
using Create.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
  public class UserController : ControllerBase{
      private readonly Appdbcontext context;
        public UserController(Appdbcontext context){
            this.context=context; 
        }

     [HttpPost]
    public async Task<IActionResult> Post(Usermodel Usermodel)
    {
        context.Add(Usermodel);
        await context.SaveChangesAsync();
        return Ok();
    }

  }