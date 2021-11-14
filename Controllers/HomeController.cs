using Microsoft.AspNetCore.Mvc;

namespace orbita_challenge_full_stack_web.Controllers;

[Route("/")]
public class HomeController : ControllerBase
{

    [HttpGet]
    public HomeView Index()
    {
        return new HomeView();
    }
}
