using System;
using System.Text;

namespace RabbitsNewPractise
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
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Rabbit ({this.Species}): {this.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}
