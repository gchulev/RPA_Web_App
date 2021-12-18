using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RPA_Queue.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace RPA_Queue.Middleware
{
    public class RpaMiddleware
    {
        private readonly RequestDelegate _next;

        public RpaMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRPAQueueUserAuthenticationService authSrv)
        {
            await authSrv.CheckIfUserCanAuthenticateAsync("test", "password"); // Call a service to check if the user is authenticated.
            await _next(context);
        }
    }
}
