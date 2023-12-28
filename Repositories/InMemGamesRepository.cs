using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository
{
    private readonly List<Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "String Fighter II",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 2,
        Name = "Final Fantasy XIV",
        Genre = "Roleplaying",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010,9,30),
        ImageUri = "https://placehold.co/100"
    },
       new Game()
    {
        Id = 3,
        Name = "Fifa 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022,9,27),
        ImageUri = "https://placehold.co/100"
    }
};

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? GetAsync(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void UpdateAsync(Game updatedGame)
    {
        var gameIndex = games.FindIndex(game => game.Id == updatedGame.Id);
        games[gameIndex] = updatedGame;
    }

    public void DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}