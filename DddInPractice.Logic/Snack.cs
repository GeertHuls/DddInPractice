namespace DddInPractice.Logic
{
    public class Snack : AggregateRoot
    {
        //When types are defined explictly in code
        //you should write integration test to verify its existance in the database
        public static readonly Snack None = new Snack(0, "None");
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");
        public static readonly Snack Soda = new Snack(2, "Soda");
        public static readonly Snack Gum = new Snack(3, "Gum");

        public virtual string Name { get; protected set; }

        protected Snack()
        {
            
        }

        private Snack(long id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}