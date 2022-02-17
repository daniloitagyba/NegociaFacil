using NegociaFacil.Application.Models.Login;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services
{
    public interface IIdentityService
    {
        Task RegisterUser(RegisterModel registerModel);
        Task RegisterUserAdmin(RegisterModel registerModel);
        Task<LoginResponseModel> Login(LoginModel registerModel);
    }
}