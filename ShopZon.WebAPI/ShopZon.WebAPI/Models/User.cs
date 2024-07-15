using System.Collections.Specialized;

namespace ShopZon.WebAPI.Models;

public sealed class User
{
    public User() 
    { 
       Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ",FirstName,LastName);

    public string UserPhotoUrl { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; }



}
