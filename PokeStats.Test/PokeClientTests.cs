using PokeStats.Lib;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PokeStats.Test
{
    public class PokeClientTests
    {
        private readonly PokeClient client = new PokeClient(new HttpClient());


        [Fact]
        public async Task Test1()
        {
            const string input = "squirtle, bulbasaur, pikachu, ditto, charmander, , ,,";

            var pokemonResults = await input
                .Split(',', StringSplitOptions.None)
                .AsParallel()
                .Select(static str => str.Trim())
                .Bind(static trimmedStr => PokemonName.From(trimmedStr))
                .Map(async pokemonName => {
                    Console.WriteLine($"Starting fetch for {pokemonName.Value}");
                    await Task.Delay(1000);
                    return await client.GetPokemonAsync(pokemonName);
                })
                .WhenAll();

            var pokemonList = pokemonResults
                .Where(p => p.IsSome)
                .ToList();

            Assert.Equal(5, pokemonList.Count);
        }
    }
}