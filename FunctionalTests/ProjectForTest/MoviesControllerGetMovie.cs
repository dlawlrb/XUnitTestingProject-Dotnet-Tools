using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using ProjectForTest;
using ProjectForTest.Models;
using ProjectForTest.Service;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.ProjectForTest
{
    public class MoviesControllerGetMovie : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IFilmSpecialist _filmSpecialist;
        private HttpClient _httpClient;

        public MoviesControllerGetMovie(WebApplicationFactory<Startup> factory)
        {
            _filmSpecialist = Mock.Of<IFilmSpecialist>();
            _httpClient = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll<IFilmSpecialist>();
                    services.TryAddTransient(_ => _filmSpecialist);
                });
            }).CreateClient();
        }
        [Fact]
        public async Task CreateGameGivenFirstMovementIsBeingExecuted()
        {
            var requestPath = "/api/movies/getMovie";
            var movieToBeSuggested = new Movie("Schindler's List", "12/31/1993", new[] { "Drama", "History", "War" }, "3h 15m");
            Mock.Get(_filmSpecialist)
                .Setup(f => f.SuggestMovie())
                .Returns(movieToBeSuggested)
                .Verifiable();

            var response = await _httpClient.GetAsync(requestPath);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var movie = await response.Content.ReadFromJsonAsync<Movie>();

            movie.Should().BeEquivalentTo(movieToBeSuggested);
            Mock.Get(_filmSpecialist).Verify();
        }
    }
}
