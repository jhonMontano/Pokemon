namespace POKEMON.Clases;

public class Pokemon : IPokemon
{
    private List <PokemonDTO> BD;

    public Pokemon(){
        this.BD = new List<PokemonDTO>();
    } 
    public void Add(PokemonDTO pokemon)
    {
        this.BD.Add(pokemon);
    }

    public void Delete (int id)
    {
        this.BD.RemoveAll(pokemon => pokemon.Id == id);
    }

    public List <PokemonDTO>All()
    {
        return this.BD;
    }
    public void Update(int id, PokemonDTO pokemon)
    {
        PokemonDTO pokemonUpdate = this.BD.Single(pokemon => pokemon.Id == id);
        //pokemonUpdate.Id = pokemon.Id;
        pokemonUpdate.Nombre = pokemon.Nombre;
        pokemonUpdate.Tipo = pokemon.Tipo;
        pokemonUpdate.Habilidades = pokemon.Habilidades;
        pokemonUpdate.Defensa = pokemon.Defensa;
    }
    
}