using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User?> LogIn(string userName, string password)
        {
            var user = await _dataContext.Set<User>().FirstOrDefaultAsync(user => (user.Username == userName) && (user.Password == password));

            return user;
        }
    }
}
