using Dashboard.Domain.Models;
using System.Threading.Tasks;

namespace Dashboard.Domain.Interface.AccountService
{
    public interface IAuthenticate
    {
        Task<ResponseModel> Authenticate(LoginModel model);
        Task<ResponseModel> RegisterUser(RegisterUserModel model);
        Task Logout();
    }
}
