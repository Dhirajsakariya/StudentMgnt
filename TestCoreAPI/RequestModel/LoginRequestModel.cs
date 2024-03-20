using System.ComponentModel.DataAnnotations.Schema;

namespace TestCoreApi.RequestModel
{
    [NotMapped]
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
