using AnimalBalanceApp.Core.QueryFilter;
using AnimalBalanceApp.Infrastructure.Interfaces;

namespace AnimalBalanceApp.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public string GetPostPaginatorUri(SocialQueryFilter filter, string actionUrl) 
        {
            return $"{_baseUri}{actionUrl}";
        }
    }
}