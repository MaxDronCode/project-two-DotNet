using Store.Controllers.Dtos.Product;

namespace Store.Controllers.Dtos.Client;

public class PastSalesResponseDto
{
    public string Id { get; set; }
    public List<ProductInSaleDto> Products { get; set; }
}