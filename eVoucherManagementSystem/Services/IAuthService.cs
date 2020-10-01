using eVoucherManagementSystem.Messages.Request.User;
using eVoucherManagementSystem.Messages.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<LogInResponse> LogInAsync(LogInRequest request, CancellationToken cancellationToken = default);    
    }
}
