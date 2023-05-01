using System.Collections.Generic;
using POKEMON.Clases;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<PokemonDTO> BDMemory = new List<PokemonDTO>();

PokemonDTO pokemon = new PokemonDTO();
/* pokemon.Id = 1;
pokemon.Nombre = "Pikachu";
pokemon.Tipo = "Electrico";
pokemon.Habilidades = new List<int> { 35, 30, 38, 37 }; 
pokemon.Defensa = 35.8;
BDMemory.Add(pokemon); */
//Ver pokemon
app.MapGet("/api/v1/pokemon", () => {
    return Results.Ok(BDMemory); 
});

//punto 1 crear pokemon
app.MapPost("/api/v1/pokemon/crearUno",(PokemonDTO pokemon)=>{
    BDMemory.Add(pokemon);
    return Results.Ok(BDMemory);
});

//punto 2 crear multiples pokemon   
app.MapPost("/api/v1/pokemon/varios", (List<PokemonDTO> pokemon)=>{
    foreach (PokemonDTO species in pokemon){
        BDMemory.Add(species);
    }
    return Results.Ok(BDMemory);
});

//punto 3 editar pokemon 
app.MapPut("/api/v1/pokemon/{Id}",(int Id, PokemonDTO pokemon)=>{
    PokemonDTO todoUpdate = (BDMemory.Single(pokemon => pokemon.Id == Id));
    todoUpdate.Habilidades = pokemon.Habilidades;
    todoUpdate.Defensa = pokemon.Defensa;
    return Results.Ok(BDMemory);
});

//punto 4 eliminar un pokemon
app.MapDelete("/api/v1/pokemon/{Id}",(int Id)=>{
    return Results.Ok(BDMemory.RemoveAll(pokemon => pokemon.Id == Id));
});

//punto 5 traer un pokemon
app.MapGet("/api/v1/pokemon/{Id}",(int Id)=>{
    return Results.Ok(BDMemory.Single(pokemon => pokemon.Id == Id));
}); 

//punto 6 traer pokemon por tipo
app.MapGet("/api/v1/pokemon/traer/{tipo}", (string tipo) => {
    return Results.Ok(BDMemory.Where(pokemon => pokemon.Tipo == tipo).ToList());
});

//punto 7 sumar habilidades
app.MapPut("/app/v1/pokemon/habilidades/",(PokemonDTO dato)=>{
    PokemonDTO updatePokemon = BDMemory.Single(item => item.Id == dato.Id);

    foreach (int habilidad in dato.Habilidades){
        if(updatePokemon.Habilidades.IndexOf(habilidad)==-1){
            updatePokemon.Habilidades.Add(habilidad);
        };
    }
    return Results.Ok(BDMemory);
});

//punto 8 crear super pokemon

app.MapPost("/api/v1/pokemon/super", (List<PokemonDTO> pokemon)=>{
try{
  PokemonDTO superPokemon = new PokemonDTO();
superPokemon.Id = 0;
superPokemon.Nombre = " ";
superPokemon.Tipo = " ";
superPokemon.Habilidades = new List<int> { }; 
superPokemon.Defensa = 0;
    
    foreach (PokemonDTO species in pokemon){
        
        superPokemon.Id= 100;
        superPokemon.Nombre=superPokemon.Nombre.ToString()+"--"+species.Nombre.ToString();
        superPokemon.Tipo=superPokemon.Tipo.ToString()+"/"+species.Tipo.ToString();
        foreach(int habilidad in species.Habilidades){
            if(superPokemon.Habilidades.IndexOf(habilidad)==-1){
                superPokemon.Habilidades.Add(habilidad);
            }
        }
        superPokemon.Defensa=(superPokemon.Defensa+species.Defensa)/2;
        
        BDMemory.RemoveAll(pokemon => pokemon.Id == species.Id);
    }

    BDMemory.Add(superPokemon);
    
}catch(FormatException e){

    Console.WriteLine(e);
}
return Results.Ok(BDMemory);
});

app.Run();
