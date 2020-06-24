using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAsync.API.Filters
{
    public class BookResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result =  context.Result as ObjectResult;
            if (result?.Value == null || result.StatusCode < 200
                || result.StatusCode >= 300)
            {
                await next();
                return;
            }

            await next();
            //return base.OnResultExecutionAsync(context, next);
        }
    }
}
