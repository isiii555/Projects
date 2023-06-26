using ServiceBusApp.Models.Abstractions;


namespace ServiceBusApp.Models.Concretes;

public class Driver : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool HasLicense { get; set; }

    public string Address { get; set; }

    public virtual Car? Car { get; set; }

    public int? CarId { get; set; }

    public virtual Ride? Ride { get; set; }

    public int? RideId { get; set; }


    public sealed override string ToString() => $"{FirstName} {LastName} ";
}