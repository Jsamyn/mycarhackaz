using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.HelpMe.Models;

namespace Mobile.HelpMe.Interfaces.Repository
{
    public interface IHelpRequestRepository
    {
        Task CreateHelpRequest(string request);
        Task<HelpRequest> GetCurrentRequest(string username);
        Task ResolveHelpRequest(string resolveRequest);
        Task<IEnumerable<HelpRequest>> GetRequests();
    }
}
