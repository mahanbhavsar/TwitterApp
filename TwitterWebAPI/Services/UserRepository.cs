using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using TwitterWebAPI.Models;

namespace TwitterWebAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly TwitterDbContext _context;
        public UserRepository(TwitterDbContext context)
        {
            _context = context;
        }

        public bool Login(string username, string password)
        {
            var user =_context.Users.FirstOrDefault(x => x.LoginId == username);
            if(user != null)
            {
                var hashedPassword = this.HashPassword(password, user.Salt);
                if (user.Password == hashedPassword)
                {
                    return true;
                }
            }
            
            return false;
        }

        public User RegisterUser(User user)
        {
            var salt = this.GenerateRandomSalt();
            user.Salt = salt;
            var hashedPassword = this.HashPassword(user.Password, salt);
            user.Password = hashedPassword;
            _context.Users.Add(user);
            _context.SaveChanges();
            return _context.Users.SingleOrDefault(x => x.UserId == user.UserId);
        }

        public User ResetPassword(User user, string userName)
        {
            var dbUser =_context.Users.FirstOrDefault(x => x.LoginId == userName);
            
            if(dbUser != null)
            {
                var salt = this.GenerateRandomSalt();
                dbUser.Salt = salt;
                var hashedPassword = this.HashPassword(user.Password, salt);
                dbUser.Password = hashedPassword;
                _context.Users.Update(dbUser);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        private string HashPassword(string password, string strSalt)
        {
            byte[] salt = Convert.FromBase64String(strSalt);
            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            // byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            // Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            
            return hashed;
        }

        private string GenerateRandomSalt()
        {
            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            return Convert.ToBase64String(salt);
        }
    }
}
