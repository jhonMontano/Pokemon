namespace POKEMON.Clases;
interface IPokemon{
    void Add(PokemonDTO pokemon);
    void Delete(int id);
    void Update(int id, PokemonDTO pokemon);
    List <PokemonDTO> All(); 
    
}