namespace ConceptualThinking.Model
{
    public class Experiment1Result
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdExpData { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public int NumberPoints { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }

        public virtual Experiment1Data Experiment1Data { get; set; }
        public virtual Users Users { get; set; }
    }
}
