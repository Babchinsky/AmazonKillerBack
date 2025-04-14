namespace AmazonKillerBack.Domain.Entities;

public class AddInfo
{
    public string FullName { get; set; } = User.FirstName + " " + User.LastName;
    public Address Address { get; set; } 
    public PaymentType PaymentType { get; set; }
    public DateTime OrderedAt { get; set; }
}