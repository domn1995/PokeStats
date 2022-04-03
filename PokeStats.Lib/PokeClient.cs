namespace PokeStats.Lib;

public class PokeClient
{
    private const string baseUrl = "https://pokeapi.co/api/v2";
    private readonly HttpClient client;

    public PokeClient(HttpClient httpClient) => this.client = httpClient;

    public async Task<Try<Pokemon>> GetPokemonAsync(PokemonName name)
    {
        var fetch = () => client.GetFromJsonAsync<Pokemon>($"{baseUrl}/pokemon/{name.Value}");
        return await TryAsync(fetch);
    }
}