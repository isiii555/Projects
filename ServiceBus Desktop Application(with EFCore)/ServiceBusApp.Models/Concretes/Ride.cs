using ServiceBusApp.Models.Abstractions;


namespace ServiceBusApp.Models.Concretes;

public class Ride : BaseEntity
{
    public virtual Driver Driver { get; set; }

    public virtual IEnumerable<Student> Students { get; set; }


    public sealed override string ToString() => Students.Count().ToString();
}