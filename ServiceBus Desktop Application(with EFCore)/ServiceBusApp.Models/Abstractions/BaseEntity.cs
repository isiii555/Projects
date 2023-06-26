namespace ServiceBusApp.Models.Abstractions;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreationTime { get; set; } 

    public DateTime LastModifiedTime { get; set; }
}