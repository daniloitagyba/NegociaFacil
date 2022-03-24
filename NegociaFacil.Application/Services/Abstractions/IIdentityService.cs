using NegociaFacil.Application.Models.User;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services
{
    public interface IIdentityService
    {
        Task RegisterUser(RegisterRequestModel registerModel);
        Task RegisterUserAdmin(RegisterRequestModel registerModel);
        Task<LoginViewModel> Login(LoginRequestModel registerModel);
    }
}