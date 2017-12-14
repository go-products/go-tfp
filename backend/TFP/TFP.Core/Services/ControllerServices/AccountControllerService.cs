using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TFP.Core.Interfaces.ControllerInterfaces;
using TFP.Core.UnitOfWork;
using TFP.Domain.Entities;
using System.Threading.Tasks;
using TFP.Models.ViewModels.AuthorizationModel;

namespace TFP.Core.Services.ControllerServices
{
   public class AccountControllerService : IAccountControllerService
    {
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;


        public AccountControllerService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IdentityResult> Register(RegisterModel model)
        {
            var user = new User
            {
                FirstName = model.FirsName,
                LastName = model.LastName,
                UserName = model.UserName
            };

            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
