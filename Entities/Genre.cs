using System.Globalization;
using System.Security.Principal;

namespace MovieApi.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
