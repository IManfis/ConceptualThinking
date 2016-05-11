using System.Collections.Generic;

namespace ConceptualThinking.Model
{
    public class Experiment1Data
    {

        public Experiment1Data()
        {
            this.Experiment1Result = new HashSet<Experiment1Result>();
        }

        public int Id { get; set; }
        public string InitialNotion { get; set; }
        public string SeriesNotion { get; set; }
        public string CorrectWord1 { get; set; }
        public string CorrectWord2 { get; set; }


        public virtual ICollection<Experiment1Result> Experiment1Result { get; set; }
    }
}
