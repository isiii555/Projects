using ServiceBusApp.Models.Abstractions;


namespace ServiceBusApp.Models.Concretes;

public class Student : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public virtual Ride? Ride { get; set; }

    public int? RideId { get; set;}

    public virtual Parent Parent { get; set; }

    public int ParentId { get; set; }

    public virtual Class? Class { get; set; }

    public int? ClassId { get; set; }
}