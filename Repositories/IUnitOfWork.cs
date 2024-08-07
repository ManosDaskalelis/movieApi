namespace MovieAPI.Repositories
{
    public interface IUnitOfWork
    {
        public MovieRepository MovieRepository { get;}
        public UserRepository UserRepository { get;}

        Task<bool> SaveAsync();
    }
}
