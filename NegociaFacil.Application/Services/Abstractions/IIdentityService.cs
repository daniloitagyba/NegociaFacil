using NegociaFacil.Models.User;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services
{
    public interface IIdentityService
    {
        Task RegisterUser(UsuarioRequestModel requestModel);
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);
    }
}