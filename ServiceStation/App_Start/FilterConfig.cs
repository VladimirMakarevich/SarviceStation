using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new WatchFilter());
            filters.Add(new SearchBotFilter());
            //filters.Add(new ETagFiltre());
            filters.Add(new CompressFilter());
            filters.Add(new WhitespaceFilter());
        }
    }

    #region WatchFilter
    public class WatchFilter : ActionFilterAttribute
    {
        private Stopwatch watch;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch = new Stopwatch();
            watch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            watch.Stop();
            filterContext.HttpContext.Response.Write(String.Format("<div style='color:#c9302c;'>Execution Time Actions: {0} ms </div>", watch.ElapsedMilliseconds));
            base.OnResultExecuted(filterContext);
        }
    }
    #endregion

    #region SearchBotFilter
    public class SearchBotFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Request.Browser.Crawler)
            {
                filterContext.Result = new ViewResult() { ViewName = "NotFound" };
            }
        }
    }
    #endregion

    #region ETag
    public class ETagFiltre : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter = new ETagHelper(filterContext.HttpContext.Response,
                filterContext.RequestContext.HttpContext.Request);
        }
    }
    public class ETagHelper : MemoryStream
    {
        private HttpResponseBase _response = null;
        private HttpRequestBase _request;
        private Stream _filter = null;
        public ETagHelper(HttpResponseBase response, HttpRequestBase request)
        {
            _response = response;
            _request = request;
            _filter = response.Filter;
        }
        private string GetToken(Stream stream)
        {
            var checksum = new byte[0];
            checksum = MD5.Create().ComputeHash(stream);
            return Convert.ToBase64String(checksum, 0, checksum.Length);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count];
            Buffer.BlockCopy(buffer, offset, data, 0, count);
            var token = GetToken(new MemoryStream(data));
            var clientToken = _request.Headers["If-None-Match"];
            if (token != clientToken)
            {
                _response.AddHeader("ETag", token);
                _filter.Write(data, 0, count);
            }
            else
            {
                _response.SuppressContent = true;
                _response.StatusCode = 304;
                _response.StatusDescription = "Not Modified";
                _response.AddHeader("Content-Length", "0");
            }
        }
    }
    #endregion

    #region CompressFilter
    public class CompressFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool allowCompression = false;
            bool.TryParse(ConfigurationManager.AppSettings["Compression"], out allowCompression);
            if (allowCompression)
            {
                HttpRequestBase request = filterContext.HttpContext.Request;
                string acceptEncoding = request.Headers["Accept-Encoding"];
                if (string.IsNullOrEmpty(acceptEncoding)) return;
                acceptEncoding = acceptEncoding.ToUpperInvariant();
                HttpResponseBase response = filterContext.HttpContext.Response;
                if (acceptEncoding.Contains("GZIP"))
                {
                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
                else if (acceptEncoding.Contains("DEFLATE"))
                {
                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }
        }
    }
    #endregion

    #region White Space
    public class WhitespaceFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            if (filterContext.HttpContext.Request.RawUrl == "/sitemap.xml") return;

            if (response.ContentType != "text/html" || response.Filter == null) return;

            response.Filter = new SpaceCleaner(response.Filter);
        }

        private class SpaceCleaner : Stream
        {
            private readonly Stream outputStream;
            StringBuilder _s = new StringBuilder();

            public SpaceCleaner(Stream filterStream)
            {
                if (filterStream == null)
                    throw new ArgumentNullException("filterStream is not determined");
                outputStream = filterStream;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                var html = Encoding.UTF8.GetString(buffer, offset, count);

                var reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
                html = reg.Replace(html, string.Empty);
                buffer = Encoding.UTF8.GetBytes(html);
                outputStream.Write(buffer, 0, buffer.Length);
            }

            #region Other
            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override bool CanRead { get { return false; } }
            public override bool CanSeek { get { return false; } }
            public override bool CanWrite { get { return true; } }
            public override long Length { get { throw new NotSupportedException(); } }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
            public override void Flush()
            {
                outputStream.Flush();
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
        }
        #endregion
    }

    #endregion
}