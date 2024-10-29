namespace SmartMed.Contracts.BaseClasses;

public abstract class BaseEntity<TId> where TId : IEquatable<TId>
{
    public TId Id { get; set; }
}