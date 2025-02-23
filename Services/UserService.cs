using AztroWebApplication1.Data;
using AztroWebApplication1.Models;



namespace AztroWebApplication1.Services
{
    public class UserService(ApplicationDbContext context)
    {

        private readonly UserRepository UserRepository = new(context);

        public async Task<List<User>> GetAllUsers()
        {
            
            return await UserRepository.GetAllUsers();

        }

        public async Task<User?> GetUserById(int id)
        {
            
            return await UserRepository.GetUserById(id);
        }

        public async Task<User> CreateUser(User user)
        {

            if (user.Age < 18){
                return null;
            }

            return await UserRepository.CreateUser(user);
        }
        

        public async Task<User?> DeleteUser(int id)
        {
            return await UserRepository.DeleteUser(id);
            
        }
    }
}    