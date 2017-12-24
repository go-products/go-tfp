using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TFP.Core.UnitOfWork;
using TFP.Domain.Entities;
using TFP.Models.ViewModels.AuthorizationModel;

namespace TFP.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IdentityResult> Register(RegisterModel model)
        {
            return null;
        }
    }
}
