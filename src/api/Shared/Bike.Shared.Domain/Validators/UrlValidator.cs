using System.Text.RegularExpressions;

namespace Bike.Shared.Domain.Validators
{   
    //Valid URls:
    //  http(s) ://www.example.com
    //  http(s) ://test.example.com
    //  http(s) ://www.example.com/page
    //  http(s) ://www.example.com/page?id=1&product=2
    //  http(s) ://www.example.com/page#start
    //  http(s) ://www.example.com:8080
    //  http(s) ://127.0.0.1
    //  127.0.0.1
    //  www.example.com
    //  example.com
    public class UrlValidator
    {
        private const string UrlPattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

        public static bool IsValid(string url)
        {
            return new Regex(UrlPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase).IsMatch(url);
        }
    }
}
