using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Core.Attributes
{
    public sealed class ApiRouteAttribute : RouteAttribute
    {
        public ApiRouteAttribute(string template) : base($"api/{template}") { }
    }
}