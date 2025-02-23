using AztroWebApplication1.Models;
using AztroWebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AztroWebApplication1.Data{

    public class UserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await db.User.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await db.User.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> CreateUser(User user)
        {
            var newUser =  db.User.Add(user);
            await db.SaveChangesAsync();
            return newUser.Entity;
        }
        
        public async Task<User> UpdateUser(int id, User user)
        {
            var userToUpdate = await db.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Age = user.Age;

            await db.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<User> DeleteUserById(int id)
        {
            var userToDelete = await db.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userToDelete == null)
            {
                return null;
            }

            db.User.Remove(userToDelete);
            await db.SaveChangesAsync();
            return userToDelete;
        }


        public async Task<User?> DeleteUser(int id)
        {
            var user = await this.GetUserById(id);
            if (user == null) return null;
            
            

            db.User.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
    
}