namespace Domain.Contracts.v1;

public interface IEntity<TId>
{
    TId Id { get; set; }
}