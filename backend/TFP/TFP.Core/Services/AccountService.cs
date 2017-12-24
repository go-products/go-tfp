using System;
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
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirsName,
                LastName = model.LastName,
                UserName = model.UserName
            };
            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
