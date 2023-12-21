using Microsoft.AspNetCore.Mvc;
namespace Read.Controllers;
using Read.Data;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
  public class UserController : ControllerBase{
      private readonly Appdbcontext context;
        public UserController(Appdbcontext context){
            this.context=context; 
        }

     [HttpGet]
        public async Task<IEnumerable<Usermodel>>Get(){
            return await context.Usermodels.ToListAsync();
        }
        
        }
    
  