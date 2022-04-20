using M03_REST01.Entite;
using M03_REST01.SERVICE_Municipalite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace M03_REST01.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        const string clefValide = "12345";
        public async Task OnActionExecutionAsync(ActionExecutingContext p_context, ActionExecutionDelegate p_next)
        {
            IDepotMunicipalite depot = p_context.HttpContext.RequestServices.GetService<IDepotMunicipalite>();

            ClefAPI clefObtenu =  depot.ObtenirClefAPI();

            StringValues clefAPI;

            if(!p_context.HttpContext.Request.Headers.TryGetValue("clefAPI", out clefAPI))
            {
                p_context.Result = new UnauthorizedResult();
                return;
            }

            if(!clefObtenu.Clef.ToString().Equals(clefAPI))
            {
                p_context.Result =  new UnauthorizedResult();
                return;
            }

            await p_next();
        }
    }
}
