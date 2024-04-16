using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.DTOs.MovieDTOs;
using MovieApi.Entities;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public MoviesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _appDbContext.Movies.ToListAsync();
            List<MovieGetDto> movieDtos = new List<MovieGetDto>();
            movieDtos = movies.Select(x => new MovieGetDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                GenreId = x.GenreId,
                Price = x.Price,
            }).ToList();
            //foreach (var movie in movies) 
            //{
            //    MovieGetDto dto = new MovieGetDto()
            //    {
            //        Id = movie.Id,
            //        Name = movie.Name,
            //        Description = movie.Description,
            //        GenreId = movie.GenreId,
            //        Price = movie.Price,
            //    };
            //    movieDtos.Add(dto);
            //}

            return Ok(movieDtos );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var movie = await _appDbContext.Movies.FindAsync(id);
            if (movie is null) return NotFound();
            MovieGetDto movieGetDto = new MovieGetDto()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                GenreId = movie.GenreId,
                Price = movie.Price,

            };
            return Ok(movieGetDto); 
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> Create(MovieCreateDto dto)
        {
            Movie movie = new Movie()
            {
                Name = dto.Name,
                Description = dto.Description,
                GenreId = dto.GenreId,
                Price = dto.Price,
                CostPrice = dto.CostPrice,
                IsDeleted = dto.IsDeleted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };



            await _appDbContext.Movies.AddAsync(movie);
            await _appDbContext.SaveChangesAsync();  
            return Ok();
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieUpdateDto movieUpdateDto)
        {
            try
            {
                var movie = await _appDbContext.Movies.FindAsync(id);

                if (movie == null)
                {
                    return NotFound(); 
                }

                movie.Name = movieUpdateDto.Name;
                movie.Description = movieUpdateDto.Description;
                movie.Price = movieUpdateDto.Price;
                movie.CostPrice = movieUpdateDto.CostPrice;
                movie.IsDeleted = movieUpdateDto.IsDeleted;
                movie.UpdatedDate = DateTime.Now;

                _appDbContext.Movies.Update(movie);
                await _appDbContext.SaveChangesAsync();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var movie = await _appDbContext.Movies.FindAsync (id);
            _appDbContext.Remove(movie);
            return NoContent();
        }
    }
}
