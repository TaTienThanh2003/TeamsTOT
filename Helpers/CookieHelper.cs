using backTOT.Entities;

namespace backTOT.Helpers
{
    public static class CookieHelper
    {
        public static void SetAuthCookies(HttpResponse response,AuthResponse authResponse)
        {
            if (authResponse == null) return;

            //Cookie cho Access Token
            Console.WriteLine("AccessToken expires at: " + authResponse.AccessTokenExpiration);
            response.Cookies.Append("AccessToken", authResponse.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires =authResponse.AccessTokenExpiration
            });
            // Coookie cho RefreshToken
            Console.WriteLine("AccessToken expires at: " + authResponse.RefreshTokenExpiration);

            response.Cookies.Append("RefreshToken", authResponse.RefreshToken, new CookieOptions
            {
                HttpOnly= true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires =authResponse.RefreshTokenExpiration
            });
        }
        public static void ClearAuthCookie(HttpResponse response)
        {
            response.Cookies.Delete("AccessToken");
            response.Cookies.Delete("RefreshToken");
        }
    }
}
