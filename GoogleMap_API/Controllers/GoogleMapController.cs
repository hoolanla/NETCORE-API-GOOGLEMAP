using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleApi.Entities.Places;
using GoogleApi.Entities.Places.Search.NearBy.Request;


namespace GoogleMap_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GoogleMapController : ControllerBase


    {
        static Dictionary<string, GoogleApi.Entities.Places.BasePlacesResponse> cacheData = new Dictionary<string, BasePlacesResponse>();

        // GET: api/GoogleMap
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GoogleMap/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/GoogleMap
        [HttpPost]
        public async Task<ActionResult<GoogleApi.Entities.Places.BasePlacesResponse>> ResultDataRestaurant(String keySearch)
        {
            if (keySearch == null)
            {
                keySearch = "";
            }

            //  Make cache data 
            if (cacheData.ContainsKey(keySearch) == false)
            {
                PlacesNearBySearchRequest r = new PlacesNearBySearchRequest();
                r.Key = "AIzaSyBIZbXFcjf_Bqt5rYoud1mBuoYf3HpBVTo";
                r.Type = GoogleApi.Entities.Places.Search.Common.Enums.SearchPlaceType.Restaurant;
                r.Radius = 5000;
                r.Name = keySearch;
                r.Location = new GoogleApi.Entities.Places.Search.NearBy.Request.Location(13.800, 100.5081204);
                var _response = GoogleApi.GooglePlaces.NearBySearch.Query(r);
                cacheData.Add(keySearch, _response);
                return _response;
            }
            else
            {
                return cacheData[keySearch];
            }
        }

    }
}
