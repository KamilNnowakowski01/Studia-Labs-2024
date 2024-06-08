namespace Labs2024_WebPages.ServicesClient
{
    public class JwtService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetToken()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("JWTToken");
        }

        public void SetToken(string token)
        {
            _httpContextAccessor.HttpContext.Session.SetString("JWTToken", token);
        }

        public void RemoveToken()
        {
            _httpContextAccessor.HttpContext.Session.Remove("JWTToken");
        }
    }
}
