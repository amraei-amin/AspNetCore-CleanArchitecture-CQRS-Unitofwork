using RoyalDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalDomain.ViewModels
{
    public class DeviceGroupViewModel
    {
        public int Id { get; set; }
        public DeviceGroupMemberships DeviceGroupMemberships { get; set; }
    }
}
