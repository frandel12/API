

namespace Parcial2.Models
{
    public class Pokemon
    {
        public string? name { get; set; }
        public string? url { get; set; }
        public Root root { get; set; }
    }

    public class Root
    {
        public Sprites Sprites { get; set; }

    }

    public class Sprites
    {
        public Other Other { get; set; }
    }

    public class Other
    {
        public Dream_World Dream_World { get; set; }
    }

    public class Dream_World
    {
        public string front_default { get; set; }
    }


    public class PokemonList
    {
        public List<Pokemon>? results;

    }

}