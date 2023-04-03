namespace CQRS_CDP_.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Certificate> Certificates { get; set; }
    }
}
