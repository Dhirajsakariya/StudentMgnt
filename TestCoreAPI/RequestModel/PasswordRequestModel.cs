namespace TestCoreApi.RequestModel
{
    public class PasswordRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDate { get; set; }

    }
}
