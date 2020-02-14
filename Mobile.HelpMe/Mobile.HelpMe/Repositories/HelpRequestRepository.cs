using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.HelpMe.Interfaces.Repository;
using Mobile.HelpMe.Models;
using Newtonsoft.Json;

namespace Mobile.HelpMe.Repositories
{
    public class HelpRequestRepository : BaseRepository, IHelpRequestRepository
    {

        string _baseUrl;
        protected override TimeSpan Timeout => TimeSpan.FromSeconds(20);
        protected override string BaseUrl => base.BaseUrl;

        public HelpRequestRepository()
        {
            _baseUrl = AppConstants.BaseUrl;
        }

        public async Task CreateHelpRequest(string helpReqJson)
        {
            var path = "/helprequests";
            var resp = await PostAsync(_baseUrl, path, helpReqJson);
        }

        public Task<HelpRequest> GetCurrentRequest(string username)
        {
            throw new NotImplementedException();
        }



        public Task ResolveHelpRequest(string resolveRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HelpRequest>> GetRequests()
        {
            var path = "/api/helpRequests";
            var resp = await Get(_baseUrl, path);
            var requests = JsonConvert.DeserializeObject<IEnumerable<HelpRequest>>(resp.Content.ToString());
            return requests;
        }
    }
}
