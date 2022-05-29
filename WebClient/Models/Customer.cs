namespace WebClient
{
    public class Customer
    {
        public long Id { get; init; }

        public string Firstname { get; init; }

        public string Lastname { get; init; }

        public override string ToString()
        {
            return $"Customer: ID={this.Id}, Name: {this.Firstname} {this.Lastname}";
        }
    }

}