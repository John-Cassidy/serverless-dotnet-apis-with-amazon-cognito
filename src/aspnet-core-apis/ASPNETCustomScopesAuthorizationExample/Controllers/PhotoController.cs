using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCustomScopesAuthorizationExample.Controllers;
[Route("[controller]")]
[ApiController]
public class PhotoController : ControllerBase {

    [HttpGet]
    [Authorize(Policy = "ReadPhotos")]
    public IActionResult Get() {
        return Ok();
    }

    [HttpPost]
    [Authorize(Policy = "WritePhotos")]
    public IActionResult Post() {
        return Ok();
    }
}
