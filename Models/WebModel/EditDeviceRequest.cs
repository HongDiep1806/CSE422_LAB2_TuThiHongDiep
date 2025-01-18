namespace Lab2_TuThiHongDiep_CSE422.Models.WebModel
{
    public class EditDeviceRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CategoryID { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string? UserId { get; set; }
    }
}
