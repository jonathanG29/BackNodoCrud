using AztroWebApplication1.Data;
using AztroWebApplication1.Models;



namespace AztroWebApplication1.Services
{
    public class UserService
    {

        private readonly UserRepository UserRepository;

        public UserService(ApplicationDbContext context)
        {
            UserRepository = new UserRepository(context);
        }

        public async Task<List<User>> GetAllUsers()
        {
            
            return await UserRepository.GetAllUsers();

        }

        public User? GetUserById(int id)
        {

            var user1 = new User {Id= 1, Name = "John Doe", Email = "", Age = 30};

            // llamaria al repositorio para traer la información de la base de datos
            // si la entiedad no existe en la base de datos, el repositorio deberia devolver null
            if (id != 1)
            {
                return null;
            }
            
            return user1;
        }

        public User CreateUser()
        {
            return new User();
        }

        public User UpdateUser(int id)
        {
            return new User();
        }

        public User DeleteUser(int id)
        {
            return new User();
        }
            
    }
}    