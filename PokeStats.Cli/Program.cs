using PokeStats.Lib;

PokeClient client = new PokeClient(new HttpClient());

const string input = "squirtle, bulbasaur,,,   ,pikachu, ditto,        charmander, invalid,";

var fetchPokemon = async (PokemonName pokemonName) =>
{
    // Simulate verbose logging.
    Console.WriteLine($"Starting fetch for {pokemonName.Value}");
    // Simulate slow network.
    await Task.Delay(1000);
    var pokemon = await client.GetPokemonAsync(pokemonName);
    // Simulate verbose logging.
    Console.WriteLine($"Finished fetch for {pokemonName.Value}");
    return pokemon;
};

var pokemonResults = await input
    .Split(',', StringSplitOptions.None)
    .Select(static str => str.Trim())
    .Bind(static trimmedStr => PokemonName.From(trimmedStr))
    .Select(fetchPokemon)
    .WhenAll();

var getOutput = () => pokemonResults
    .Map(p => 
        p.Match(
            Succ: pokemon => pokemon.ToString(),
            Fail: error => error.Message
        )
    );

var printOutput = () => getOutput()
    .ToList()
    .ForEach(Console.WriteLine);

printOutput();