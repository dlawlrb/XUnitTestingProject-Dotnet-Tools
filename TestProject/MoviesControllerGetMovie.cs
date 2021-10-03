using ProjectForTest.Models;
using ProjectForTest.Service;
using FluentAssertions;
using Xunit;

namespace TestProject
{
    public class MoviesControllerGetMovie
    {
        private readonly IFilmSpecialist _filmSpecialist = new FilmSpecialist();
        [Fact]
        public void ReturnRandomMovieWhenAsked()
        {
            var suggestedMovie = _filmSpecialist.SuggestMovie();
            var expectedTitles = new string[]
            {
                "RoboCop", "The Matrix", "Soul", "Space Jam", "Aladdin", "The World of Dragon Ball Z"
            };
            suggestedMovie.Title.Should().BeOneOf(expectedTitles);
        }
    }
}
