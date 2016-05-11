using System.Data.Entity;

namespace ConceptualThinking.Model
{
    public class ConceptualThinkingContext : DbContext
    {
        public ConceptualThinkingContext()
            : base("ConceptualThinking")
        {
        }
    
        public virtual DbSet<Experiment1Data> Experiment1Data { get; set; }
        public virtual DbSet<Experiment1Result> Experiment1Result { get; set; }
        public virtual DbSet<Experiment2Data> Experiment2Data { get; set; }
        public virtual DbSet<Experiment2Result> Experiment2Result { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
