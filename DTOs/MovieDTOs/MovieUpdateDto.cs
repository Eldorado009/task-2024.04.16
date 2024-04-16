namespace MovieApi.DTOs.MovieDTOs
{
    public class MovieUpdateDto
    {
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }
        public string Description { get; set; }
    }
}
