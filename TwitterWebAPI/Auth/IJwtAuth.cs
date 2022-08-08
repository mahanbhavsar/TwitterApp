namespace TwitterWebAPI.Auth
{
    public interface IJwtAuth
    {
        string Authenticate(string username, string password);
    }
}
