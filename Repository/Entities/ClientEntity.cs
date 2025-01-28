using System.ComponentModel.DataAnnotations;

namespace Store.Repository.Entities;

public class ClientEntity
{
    [StringLength(36, MinimumLength = 36)] public string Id { get; set; }

    [StringLength(10, MinimumLength = 9)] public string Nif { get; set; }

    [StringLength(150, MinimumLength = 2)] public string Name { get; set; }

    [StringLength(150, MinimumLength = 5)] public string? Address { get; set; }

    public override bool Equals(object? obj)
    {
        if ((obj == null) | (GetType() != obj.GetType())) return false;
        var other = (ClientEntity)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}