using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;

namespace RestSample.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    
    private readonly RestSampleContext _dbContext;

    public UsersController(ILogger<UsersController> logger, RestSampleContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpPost]
    public void Post([FromBody] User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _dbContext.Users.ToList();
    }

    [HttpGet("{id:int}")]
    public User GetById(int id)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Id == id)!;
    }
}
