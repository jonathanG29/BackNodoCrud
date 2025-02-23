// create a model class named user.cs and add the following code to it.

using System.ComponentModel.DataAnnotations;

namespace AztroWebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }

        public User()
        {
        }
    }
    
}