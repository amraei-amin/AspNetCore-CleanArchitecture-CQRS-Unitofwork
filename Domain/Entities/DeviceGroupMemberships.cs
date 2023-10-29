namespace RoyalDomain.Entities
{
    public class DeviceGroupMemberships
    {
        public int Id { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public int? DeviceGroup_Id { get; set; }

        public int? RoyalDevice_ID { get; set; }

        public bool GroupIsRemoved { get; set; }

    }

}