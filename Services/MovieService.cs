using MovieAPI.DTO;
using MovieAPI.Models;
using MovieAPI.Repositories;

namespace MovieAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MovieReadOnlyDTO> CreateMovie(MovieCreateDTOcs movie)
        {
            var newMovie = new Movie
            {
                Title = movie.Title,
                Url = movie.Url,
            };

            await _unitOfWork.MovieRepository.CreateMovie(newMovie);
            await _unitOfWork.SaveAsync();

            var movieToReturn = new MovieReadOnlyDTO
            {
                Id = newMovie.Id,
                Title = newMovie.Title,
                Url = newMovie.Url,
            };

            return movieToReturn;
        }

        public async Task<MovieReadOnlyDTO> DeleteMovie(int id)
        {
            var movieToDelete = await _unitOfWork.MovieRepository.GetMovieById(id);

            if (movieToDelete == null)
            {
                return null;
            }
            await _unitOfWork.MovieRepository.DeleteMovie(id);
            await _unitOfWork.SaveAsync();

            var movieToReturn = new MovieReadOnlyDTO
            {
                Id = movieToDelete.Id,
                Title = movieToDelete.Title,
                Url = movieToDelete.Url,
            };
            return movieToReturn;
        }

        public async Task<IEnumerable<MovieReadOnlyDTO>> GetAllMovies()
        {
            var existingMovies = await _unitOfWork.MovieRepository.GetAllMovies();

            var movies = new List<MovieReadOnlyDTO>();
            foreach (var movie in existingMovies)
            {
                movies.Add(new MovieReadOnlyDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Url = movie.Url,
                });
            }
            return movies;
        }

        public async Task<MovieReadOnlyDTO> GetMovieById(int id)
        {
            var existingMovie = await _unitOfWork.MovieRepository.GetMovieById(id);

            if (existingMovie is null)
            {
                return null;
            }

            var movieToReturn = new MovieReadOnlyDTO
            {
                Id = existingMovie.Id,
                Title = existingMovie.Title,
                Url = existingMovie.Url,
            };
            return movieToReturn;
        }

        public async Task<MovieReadOnlyDTO> UpdateMovie(MovieUpdateDTO movie)
        {
            var existingMovie = await _unitOfWork.MovieRepository.GetMovieById(movie.Id);

            if (existingMovie == null)
            {
                return null;
            }

            var editableMovie = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Url = movie.Url,
            };


            await _unitOfWork.MovieRepository.UpdateMovie(editableMovie);
            await _unitOfWork.SaveAsync();

            var movieToUpdate = new MovieReadOnlyDTO
            {
                Id = editableMovie.Id,
                Title = editableMovie.Title,
                Url = editableMovie.Url,
            };

            return movieToUpdate;
        }
    }
}
