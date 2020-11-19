using System;
namespace Rabbits
{
    public class Rabbit
    {
        public string Name { get; set; }

        public string Species { get; set; }

        public bool Available { get; set; }

        private Rabbit()
        {
            this.Available = true;
        }

        public Rabbit(string name, string species)
            :this()
        {
            this.Name = name;
            this.Species = species;
        }
        

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }

    }
}
