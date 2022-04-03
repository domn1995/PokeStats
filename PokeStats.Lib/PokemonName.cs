global using static LanguageExt.Prelude;
global using LanguageExt;

namespace PokeStats.Lib;

public record PokemonName
{
    public string Value { get; }

    private PokemonName(string value) => Value = value;

    public static Option<PokemonName> From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return None;
        }

        return new PokemonName(value);
    }
}