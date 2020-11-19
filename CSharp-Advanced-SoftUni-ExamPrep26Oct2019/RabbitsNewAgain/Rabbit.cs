using System;
namespace RabbitsNewAgain
{
    public class Rabbit
    {
        public Rabbit()
        {
            this.Available = true;
        }

        public Rabbit(string name, string species)
            :this()
        {
            this.Name = name;
            this.Species = species;
        }

        public string Name { get; set; }

        public string Species { get; set; }

        public bool Available { get; set; }

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
