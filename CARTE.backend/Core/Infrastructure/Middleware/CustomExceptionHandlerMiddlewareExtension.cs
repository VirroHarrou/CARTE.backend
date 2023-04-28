namespace CARTE.backend.Core.Infrastructure.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
