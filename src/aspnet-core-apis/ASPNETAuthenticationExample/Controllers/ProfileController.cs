using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETAuthenticationExample.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class ProfileController : ControllerBase {
    [HttpGet]
    public IEnumerable<KeyValuePair<string, string>> Get() {
        return User.Claims.Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
    }
}
