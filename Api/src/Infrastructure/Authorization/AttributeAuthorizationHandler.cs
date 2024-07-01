using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;

namespace Infrastructure.Authorization
{
    public abstract class AttributeAuthorizationHandler<TRequirement, TAttribute> : AuthorizationHandler<TRequirement> 
        where TAttribute : AuthorizeAttribute 
        where TRequirement : IAuthorizationRequirement
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement)
        {
            var endpoint = (context.Resource as HttpContext)?.Features.Get<IEndpointFeature>().Endpoint as RouteEndpoint;
            var attribute = endpoint?.Metadata.GetMetadata<TAttribute>()!;

            await HandleRequirementAsync(context, attribute, requirement);
        }

        protected abstract Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            TAttribute attribute, 
            TRequirement requirement);
    }
}
