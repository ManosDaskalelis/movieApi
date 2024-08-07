namespace MovieAPI.Services
{
    public interface IApplicationService
    {
        MovieService MovieService { get; }
        UserService UserService { get; }
    }
}
