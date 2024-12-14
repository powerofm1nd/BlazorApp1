namespace BlazorApp1.Services
{
    public class AppState
    {
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public void ClearState()
        {
            Username = string.Empty;
            Password = string.Empty;
            IsAuthenticated = false;
            IsAdmin = false;
        }
    }
}