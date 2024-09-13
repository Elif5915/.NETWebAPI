namespace eCommerceHomeworkAPI.Dtos;

public sealed record UpdateProductDto
(Guid Id,
    string Name,
    decimal Price
    );
