namespace MovieApi.DTOs.MovieDTOs
{
    public class MovieCreateDto
    {
        public bool IsDeleted { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }
        public string Description { get; set; }
    }
}
