using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TFP.Models.ViewModels.AuthorizationModel;

namespace TFP.Core.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterModel model);
    }
}
