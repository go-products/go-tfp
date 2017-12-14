using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFP.Core.Services;
using TFP.Models.ViewModels.AuthorizationModel;

namespace TFP.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await accountService.Register(model);
            if (res.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}