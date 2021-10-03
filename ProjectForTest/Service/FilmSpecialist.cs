using ProjectForTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForTest.Service
{
    public class FilmSpecialist : IFilmSpecialist
    {
        private static readonly Movie[] Films =
        {
            new Movie("RoboCop", "10/08/1987", new[] {"Action", "Thriller", "Science Fiction"}, "1h 42m"),
            new Movie("The Matrix", "05/21/1999", new[] {"Action", "Science Fiction"}, "2h 16m"),
            new Movie("Soul", "12/25/2020", new[] {"Family", "Animation", "Comedy", "Drama", "Music", "Fantasy"}, "1h 41m"),
            new Movie("Space Jam", "12/25/1996", new[] {"Adventure", "Animation", "Comedy", "Family"}, "1h 28m"),
            new Movie("Aladdin", "07/03/1993", new[] {"Animation", "Family", "Adventure", "Fantasy", "Romance"}, "1h 28m"),
            new Movie("The World of Dragon Ball Z", "01/21/2000", new[] {"Action"}, "20m")
        };

        public Movie SuggestMovie()
        {
            Random random = new Random();
            var filmIndexThatIWillSuggest = random.Next(0, Films.Length);

            return Films[filmIndexThatIWillSuggest];
        }
    }
}
