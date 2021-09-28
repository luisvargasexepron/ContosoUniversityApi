using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Query;

namespace ContosoUniversityApi
{
    public class CustomEnableQueryOneAttribute : EnableQueryAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Result is BadRequestObjectResult
                || actionExecutedContext.Result is ObjectResult && (actionExecutedContext.Result as ObjectResult).StatusCode == 403)
                return;

            base.OnActionExecuted(actionExecutedContext);
            if (actionExecutedContext.Result is ObjectResult queryResult && queryResult.Value is IQueryable)
                queryResult.Value = (queryResult.Value as IQueryable<object>)!.FirstOrDefault();
        }
    }
}