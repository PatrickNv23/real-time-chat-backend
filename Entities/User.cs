using Postgrest.Attributes;
using Postgrest.Models;

namespace real_time_chat_backend.Entities;

[Table("User")]
public class User : BaseModel 
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    [Column("lastname")]
    public string LastName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("phoneNumber")]
    public string? PhoneNumber { get; set; }
    [Column("username")]
    public string UserName { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("usercode")]
    public string UserCode { get; set; }
    [Column("creationDate")]
    public DateTime CreationDate { get; set; }
    [Column("updateDate")]
    public DateTime? UpdateDate { get; set; }
}