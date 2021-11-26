using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Contracts;
using Weather.Models;

namespace Weather.Repositories
{
    class LocationInfoRepository : RepositoryBase<LocationInfo>, ILocationInfoRepository
    {
        public LocationInfoRepository(RepositoryContext context) : base(context)
        {

        }

        public LocationInfo GetLocationInfoByZipCode(string zipCode)
        {
            return FindByCondition(zipCode).FirstOrDefault();
        }
    }
}
