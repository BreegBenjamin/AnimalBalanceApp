using AnimalBalanceApp.Core.QueryFilter;

namespace AnimalBalanceApp.Infrastructure.Interfaces
{
    public interface IUriService
    {
        string GetPostPaginatorUri(SocialQueryFilter filter, string actionUrl);
    }
}