using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETAuthorizationExample.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase {

    [HttpGet]
    public IEnumerable<KeyValuePair<string, string>> Get() {
        return User.Claims.Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
    }
}
