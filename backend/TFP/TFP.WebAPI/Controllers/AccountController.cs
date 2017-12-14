using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TFP.Domain.Entities;
using TFP.Models.ViewModels.AuthorizationModel;
using TFP.Core.Interfaces.ControllerInterfaces;

namespace TFP.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IAccountControllerService accountService;

        public AccountController(IAccountControllerService accountService)
        {
            this.accountService = accountService;
        }

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