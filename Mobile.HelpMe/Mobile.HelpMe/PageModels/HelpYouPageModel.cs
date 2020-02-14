using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FreshMvvm;
using Mobile.HelpMe.Interfaces.Repository;
using Mobile.HelpMe.Interfaces.Services;
using Mobile.HelpMe.Models;
using Xamarin.Essentials;

namespace Mobile.HelpMe.PageModels
{
    public class HelpYouPageModel : FreshBasePageModel
    {
        private double userLat = 33.447130;
        private double userLong = -112.075545;

        #region IoC Members
        private IGeolocationCalculations _geoCalculations;
        private IHelpRequestRepository _requestRepository;
        #endregion

        #region Public Properties
        public ObservableCollection<HelpRequest> HelpRequests { get; private set; }
        #endregion

        public HelpYouPageModel(IGeolocationCalculations geoCalculations, IHelpRequestRepository reqRepo)
        {
            _geoCalculations = geoCalculations;
            _requestRepository = reqRepo;
        }


        public async override void Init(object initData)
        {
            base.Init(initData);
            HelpRequests = new ObservableCollection<HelpRequest>(await _requestRepository.GetRequests());
            //HelpRequests = new ObservableCollection<HelpRequest>
            //{
            //    new HelpRequest
            //    {
            //        Username = "jcanode",
            //        Problem = "FlatTire",
            //        Latitude = 34.13234,
            //        Longitude = -110.83745,
            //        UserphoneNumber = "2197767123"

            //    },
            //    new HelpRequest
            //    {
            //        Username = "jcanode",
            //        Problem = "FlatTire",
            //        Latitude = 34.13234,
            //        Longitude = -110.83745,
            //        UserphoneNumber = "2197767123"

            //    },
            //    new HelpRequest
            //    {
            //        Username = "jcanode",
            //        Problem = "FlatTire",
            //        Latitude = 34.13234,
            //        Longitude = -110.83745,
            //        UserphoneNumber = "2197767123"

            //    },
            //    new HelpRequest
            //    {
            //        Username = "jcanode",
            //        Problem = "FlatTire",
            //        Latitude = 34.13234,
            //        Longitude = -110.83745,
            //        UserphoneNumber = "2197767123"

            //    },
            //    new HelpRequest
            //    {
            //        Username = "jcanode",
            //        Problem = "FlatTire",
            //        Latitude = 34.13234,
            //        Longitude = -110.83745,
            //        UserphoneNumber = "2197767123"

            //    },
            //    new HelpRequest
            //    {
            //        Username = "jcanode",
            //        Problem = "FlatTire",
            //        Latitude = 34.13234,
            //        Longitude = -110.83745,
            //        UserphoneNumber = "2197767123"
            //    },
            //};

            CalculateDistance();
        }

        private async void CalculateDistance()
        {
            foreach (var item in HelpRequests)
            {
                var location = await Geolocation.GetLocationAsync();
                item.Distance = _geoCalculations.CalculateDistance(location.Latitude, location.Longitude, item.Latitude, item.Longitude).ToString() + " mi";
            }
        }
    }
}
