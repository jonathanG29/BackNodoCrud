using AztroWebApplication1.Models;
using AztroWebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;


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


        // Función para crear un usuario
        public async Task<User> CreateUser(User user)
        {
            var newUser =  db.User.Add(user);
            await db.SaveChangesAsync();
            return newUser.Entity;
        }
        

        // Función para eliminar un usuario por ID
        public async Task<User?> DeleteUser(int id)
        {
            var user = await this.GetUserById(id);
            if (user == null) return null;
            
            

            db.User.Remove(user);
            await db.SaveChangesAsync();
            return user;
        }
        

        // Función para actualizar un usuario por ID
        public async Task<User?> UpdateUser(int id, User user)
        {
            var userToUpdate = await this.GetUserById(id);
            if (userToUpdate == null) return null;

            user.Id = userToUpdate.Id;
            var userUpdated = UpdateObject(userToUpdate, user);

            db.User.Update(userUpdated);
            await db.SaveChangesAsync();
            return userToUpdate;
        }
        // Función para actualizar un objeto y usarlo en el método UpdateUserById
        private static T UpdateObject<T>(T current, T newObject)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var newValue = prop.GetValue(newObject);

                // Si es un string y está vacío, se ignora
                if (newValue == null || string.IsNullOrEmpty(newValue.ToString()))
                    continue;

                // Si es un int y su valor es 0 en newObject, se ignora
                if (newValue is int intValue && intValue == 0)
                    continue;
                prop.SetValue(current, newValue);
            }
            return current;
        }
    }
    
}