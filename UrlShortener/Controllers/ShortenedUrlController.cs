using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UrlShortener.Data;

namespace UrlShortener.Controllers
{
    public class ShortenedUrlController : Controller
    {
        private readonly UrlShortenerDbContext _dbContext;
        private readonly UrlShorteningService _urlShorteningService;

        public ShortenedUrlController(
            UrlShortenerDbContext dbContext,
            UrlShorteningService urlShorteningService)
        {
            _dbContext = dbContext;
            _urlShorteningService = urlShorteningService;
        }
        public IActionResult Index()
        {
            IEnumerable<ShortenedUrlEntry> urls = _dbContext.UrlEntries.AsEnumerable();
            return View(urls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShortenedUrlEntry urlEntry)
        {
            
            _dbContext.UrlEntries.Add(urlEntry);
            _dbContext.SaveChanges();

            urlEntry.Key = _urlShorteningService.Encode(urlEntry.Id);
            Uri uri = new Uri(urlEntry.Url);
            Uri baseUri = new Uri(uri.GetLeftPart(UriPartial.Authority));
            urlEntry.ShortUrl = new Uri(baseUri, urlEntry.Key).AbsoluteUri;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult TestUrl([FromQuery] string queryParam)
        {
            ViewBag.queryParam = queryParam;
            return View();
        }
    }
}
