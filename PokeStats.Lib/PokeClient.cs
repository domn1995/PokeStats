namespace PokeStats.Lib;

public class PokeClient
{
    private const string baseUrl = "https://pokeapi.co/api/v2";
    private readonly HttpClient client;

    public PokeClient(HttpClient httpClient) => this.client = httpClient;

    public async Task<Option<Pokemon>> GetPokemonAsync(PokemonName name)
    {
        var fetch = () => client.GetFromJsonAsync<Pokemon>($"{baseUrl}/pokemon/{name.Value}");
        var result = await TryAsync(fetch);
        return result.Match(
            Succ: pokemon => Some(pokemon),
            Fail: None
        );
    }
}