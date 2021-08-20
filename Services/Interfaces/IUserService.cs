using pokemon_tcg_collection_api.Models;
using System.Threading.Tasks;

namespace pokemon_tcg_collection_api.Services.Interfaces
{
    public interface IUserService
    {
        public string GenerateToken(UserEntity user);
        Task<UserEntity> GetUserByUsernameAsync(string username);
        Task<UserEntity> InsertUserAsync(UserEntity user);
    }
}
