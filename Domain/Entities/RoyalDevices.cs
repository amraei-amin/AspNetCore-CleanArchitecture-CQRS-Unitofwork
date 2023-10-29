namespace RoyalDomain.Entities
{
    public class RoyalDevices
    {
        public int ID { get; set; }
        public string OfficialName { get; set; }
        public string FriendlyName { get; set; }
        public string Address { get; set; }
        public int? DeviceHardwareId { get; set; }
        public int? City_Id { get; set; }
        public string Owner_Id { get; set; }
        //public Geometry Location { get; set; }
        public DateTime? LastEmployeesUpdateDate { get; set; }
        public bool ConsiderShowingOrder { get; set; }
        public int? PartId { get; set; }

    }

}
