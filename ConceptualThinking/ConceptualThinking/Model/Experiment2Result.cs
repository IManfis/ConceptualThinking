namespace ConceptualThinking.Model
{
    public class Experiment2Result
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdExpData { get; set; }
        public string UserAnswer { get; set; }
        public int NumberPoints { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }

        public virtual Experiment2Data Experiment2Data { get; set; }
        public virtual Users Users { get; set; }
    }
}
