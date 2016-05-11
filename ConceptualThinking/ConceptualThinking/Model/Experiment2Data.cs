using System.Collections.Generic;

namespace ConceptualThinking.Model
{
    public class Experiment2Data
    {
        public Experiment2Data()
        {
            this.Experiment2Result = new HashSet<Experiment2Result>();
        }

        public int Id { get; set; }
        public string PairNotions { get; set; }
        public string CorrectAnswer { get; set; }

        public virtual ICollection<Experiment2Result> Experiment2Result { get; set; }
    }
}
