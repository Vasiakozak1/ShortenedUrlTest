using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Data;

namespace UrlShortener
{
    public class ShortenedUrlHandler
    {
        private readonly RequestDelegate _next;

        public ShortenedUrlHandler(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var dbContext = httpContext.RequestServices.GetService(typeof(UrlShortenerDbContext)) as UrlShortenerDbContext;

            string currentUrl = httpContext.Request.GetDisplayUrl();
            ShortenedUrlEntry urlToRedirect = dbContext.UrlEntries.FirstOrDefault(entry => entry.ShortUrl == currentUrl);
            if(urlToRedirect != null)
            {
                httpContext.Response.Redirect(urlToRedirect.Url);
                return Task.CompletedTask;
            }


            return _next.Invoke(httpContext);
        }
    }
}
