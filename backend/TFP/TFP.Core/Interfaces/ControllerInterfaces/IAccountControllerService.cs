using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TFP.Models.ViewModels.AuthorizationModel;

namespace TFP.Core.Interfaces.ControllerInterfaces
{
    public interface IAccountControllerService
    {
        Task<IdentityResult> Register(RegisterModel model);
    }
}
