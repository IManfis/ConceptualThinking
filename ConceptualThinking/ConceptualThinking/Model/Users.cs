using System;
using System.Collections.Generic;

namespace ConceptualThinking.Model
{
    public class Users
    {
        public Users()
        {
            this.Experiment1Result = new HashSet<Experiment1Result>();
            this.Experiment2Result = new HashSet<Experiment2Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? Group { get; set; }
        public string Password { get; set; }


        public virtual ICollection<Experiment1Result> Experiment1Result { get; set; }

        public virtual ICollection<Experiment2Result> Experiment2Result { get; set; }
    }
}
