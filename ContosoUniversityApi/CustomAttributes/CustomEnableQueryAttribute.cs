using System;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;

namespace ContosoUniversityApi;

public class CustomEnableQueryAttribute : EnableQueryAttribute
{
    public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
    {
        var objSettings = new ODataQuerySettings();
        if (queryOptions.Filter != null)
        {
            queryable = queryOptions.Filter.ApplyTo(queryable, objSettings);
        }
        if (queryOptions.Count != null)
        {
            var count = (queryable as IQueryable<object>)?.Count() ?? 0;
            queryOptions.Request.HttpContext.Response.Headers.Add("x-total-items", count.ToString());
            queryOptions.Request.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-total-items");
        }

        return base.ApplyQuery(queryable, queryOptions);
    }

}