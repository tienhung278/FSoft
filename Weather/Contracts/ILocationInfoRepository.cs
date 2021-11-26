using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Contracts
{
    interface ILocationInfoRepository
    {
        public LocationInfo GetLocationInfoByZipCode(string zipCode);
    }
}
