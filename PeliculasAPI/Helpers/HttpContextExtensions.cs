namespace PeliculasAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public static void InsertPaginationParams(this HttpContext httpContext, int totalItems, int rowsQty)
        {
            int pages = totalItems / rowsQty;
            httpContext.Response.Headers.Add("Pages", pages.ToString());
        }
    }
}
