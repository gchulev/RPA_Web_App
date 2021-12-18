using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPA_Queue.Middleware
{
    public static class RpaMiddlewareExtension
    {
        public static IApplicationBuilder UseRpaMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<RpaMiddleware>();
    }
}
