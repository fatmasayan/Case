using Case.Models.Comman;

namespace Case.Models;

public class AuthToken : BaseModel
{
    //public int Id { get; set; }
    public string Token { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }

}
