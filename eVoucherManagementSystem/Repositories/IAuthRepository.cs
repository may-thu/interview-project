using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using eVoucherManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace eVoucherManagementSystem.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterAsync(User user, string password, CancellationToken cancellationToken = default);
        Task<bool> LogInAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<User> FindAsync(string request, CancellationToken cancellationToken);
        Task<IList<string>> FindUserRolesAsync(string email, CancellationToken cancellationToken);
    }
}
