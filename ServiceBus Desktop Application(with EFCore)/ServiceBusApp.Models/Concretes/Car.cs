using ServiceBusApp.Models.Abstractions;


namespace ServiceBusApp.Models.Concretes;

public class Car : BaseEntity
{
    public string Name { get; set; } = null!;

    public string CarNumber { get; set; } = null!;

    public int SeatCount { get; set; }

    public virtual Driver? Driver { get; set; }


    public sealed override string ToString() => $"{Name}-{CarNumber}-{SeatCount}";
}