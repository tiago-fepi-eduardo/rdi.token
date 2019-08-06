using Microsoft.AspNetCore.Mvc;
using Token.Domain.Entity;
using Token.Domain.Interfaces;

namespace Token.Presentation.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ActionResult Response(bool success, object result)
        {
            if (success)
            {
                return Ok(
                        new
                        {
                            success = success,
                            data = result
                        });
            }
            else
            {
                return BadRequest(
                        new
                        {
                            success = success,
                            errors = result
                        });
            }
        }
    }
}
