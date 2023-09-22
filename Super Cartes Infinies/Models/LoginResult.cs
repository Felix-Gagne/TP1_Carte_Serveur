using Super_Cartes_Infinies.Controllers;

namespace Super_Cartes_Infinies.Models
{
    public class LoginResult
    {
        
            public bool Success { get; set; }
            public MonDTO MonDTO { get; set; }
            public string Error { get; set; }
        
    }
}
