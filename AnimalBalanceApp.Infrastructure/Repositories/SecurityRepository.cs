using AnimalBalanceApp.Core.Entities;
using AnimalBalanceApp.Core.Interfaces;
using AnimalBalanceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Repositories
{
    public class SecurityRepository : BaseSocialRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(AnimalBalanceAppContext context) : base(context){}
        public async Task<Security> GetLoginByCredentials(UserLogin login) 
        {
            return await _entitis.FirstOrDefaultAsync(x => x.SecurityUser == login.User);
        }
    }
}