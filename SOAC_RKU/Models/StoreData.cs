using Microsoft.AspNetCore.Http;

namespace SOAC_RKU.Models

{
    public class StoreData
    {
        private readonly HttpContext _http;
        
        public StoreData(HttpContext httpContext)
        {
            this._http = httpContext;
        }
        public void btncrick()
        {
            _http.Session.SetString("SportName", "Cricket");
        }
    }
}
