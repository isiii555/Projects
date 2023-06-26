using ServiceBusApp.Models.Abstractions;


namespace ServiceBusApp.Models.Concretes;

public class Class : BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual IEnumerable<Student>? Students { get; set; }


    public sealed override string ToString() => $"{Id} {Name}";
}