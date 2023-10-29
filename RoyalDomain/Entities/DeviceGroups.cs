namespace RoyalDomain.Entities
{
    public class DeviceGroups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public bool DefaultGroup { get; set; }
        public string Owner_Id { get; set; }
        public string Discriminator { get; set; }
        public bool? IsMaster { get; set; }
    }
}