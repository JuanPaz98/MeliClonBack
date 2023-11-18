using MeliClon.Models.Request;
using MeliClon.Models.Response;

namespace MeliClon.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
