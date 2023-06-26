using ServiceBusApp.Models.Abstractions;


namespace ServiceBusApp.Models.Concretes;

public class Parent : BaseEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual IEnumerable<Student>? Students { get; set; }


    public sealed override string ToString() =>  $"{Id} {FirstName} {LastName}";
}