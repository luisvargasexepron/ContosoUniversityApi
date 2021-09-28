using System;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;

namespace ContosoUniversityApi
{
    public class CustomEnableQueryAttribute : EnableQueryAttribute
    {
        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            dynamic currentType = queryable;
            ODataQuerySettings objSettings = new ODataQuerySettings();
            if (queryOptions.Filter != null)
            {
                currentType = queryOptions.Filter.ApplyTo(queryable, objSettings);
            }
            if (queryOptions.Count != null)
            {
                try
                {
                    var count = (currentType as IQueryable<object>).Count();
                    queryOptions.Request.HttpContext.Response.Headers.Add("x-total-items", count.ToString());
                    queryOptions.Request.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-total-items");
                }
                catch (Exception) { }
            }

            return base.ApplyQuery(queryable, queryOptions);
        }

    }
}