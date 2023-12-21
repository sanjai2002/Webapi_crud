namespace Read.Data;
using Microsoft.EntityFrameworkCore;

public class Appdbcontext:DbContext{
    public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
    {
        
    }
    public DbSet<Usermodel> Usermodels{get; set;}


}