
using System.Text.RegularExpressions;

namespace Routing.CustomConstraint
{
    public class alphaNumeric : IRouteConstraint
    {
        public bool Match
            (HttpContext? httpContext,
            IRouter? route, 
            string routeKey,
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }

            Regex regex = new Regex("^[a-zA-Z][a-zA-Z-0-9]*$");

            var UserNameValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(UserNameValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
