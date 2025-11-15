using backTOT.Data;
using backTOT.Entities;
using System;

namespace backTOT.Middleware
{
    public class AuditLogMiddleware
    {
        private readonly RequestDelegate _next;
        public AuditLogMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            using var scope = context.RequestServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();

            Guid? userId = null;
            var userIdStr = context.User?.FindFirst("id")?.Value;
            if (Guid.TryParse(userIdStr, out var uid)) userId = uid;
            db.AuditLogs.Add(new AuditLog
            {
                UserId = userId,
                HttpMethod = context.Request.Method,
                Endpoint = context.Request.Path,
                Timestamp = DateTime.Now,
                Details = $"IP: {context.Connection.RemoteIpAddress}"
            });
            await db.SaveChangesAsync();
        }
    }
}
