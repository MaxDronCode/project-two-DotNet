using System.ComponentModel.DataAnnotations;

namespace Store.Repository.Entities;

public class ProductEntity
{
    [StringLength(36)] public string Id { get; set; }

    [StringLength(10, MinimumLength = 5)] public string Code { get; set; }

    [StringLength(100, MinimumLength = 2)] public string Name { get; set; }

    [Range(0, int.MaxValue)] public int Stock { get; set; }
}