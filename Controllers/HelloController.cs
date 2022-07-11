using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    IHello helloService;
    public HelloController(IHello _helloService)
    { 
        helloService = _helloService;
    }

[HttpGet]
    public IActionResult Get()
    {
        return Ok(helloService.GetHello());
    }

}