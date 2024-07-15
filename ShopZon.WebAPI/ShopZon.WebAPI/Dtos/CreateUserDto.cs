namespace ShopZon.WebAPI.Dtos;

public sealed record CreateUserDto(
   string FirstName,string LastName,IFormFile File  
    
);