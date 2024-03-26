namespace StackOverflowRESTAPIProject.Models
{
    public class StackOverflowData
    {
        public DateOnly Date { get; set; }
        public StackOverflowTag Tag { get; set; }

        protected StackOverflowData() { }

        public StackOverflowData(DateOnly date, StackOverflowTag tag)
        {
            Date = date;
            Tag = tag;
        }

        public static StackOverflowData Create(DateOnly date, StackOverflowTag tag)
            => new StackOverflowData(date, tag);
    }
}