using Lab2_TuThiHongDiep_CSE422.Models;

namespace Lab2_TuThiHongDiep_CSE422.Database
{
    public static class VirtualDatabase
    {
        public static List<Device> Devices = new List<Device>
        {
            new Device
                {
                    Id = "328a56f9-88c3-4767-a8bb-b865c121c2b7",
                    Name = "Temperature Sensor",
                    Code = "TS-001",
                    CategoryID = "CAT-001",
                    Status = DeviceStatus.InUse,
                    DateOfEntry = new DateTime(2025, 1, 1),
                    UserId="328a56f9-88c3-4767-a8bb-b865c121c2b7"
                },
            new Device
                {
                    Id = "328a56f9-88c3-4767-a8bb-b865c121c2b8",
                    Name = "Washing Machine",
                    Code = "MS-001",
                    CategoryID = "DOG-001",
                    Status = DeviceStatus.UnderMaintenance,
                    DateOfEntry = new DateTime(2025, 1, 1),
                    UserId= "328a56f9-88c3-4767-a8bb-b865c121c2b7"
                },
                new Device
                {
                    Id = "dc409eb4-a6a0-40c9-adb2-bcee9dffb9b0",
                    Name = "Humidity Sensor",
                    Code = "HS-002",
                    CategoryID = "CAT-002",
                    Status = DeviceStatus.Broken,
                    DateOfEntry = new DateTime(2024, 12, 20),
                    UserId="dc409eb4-a6a0-40c9-adb2-bcee9dffb9b0"
                },
                new Device
                {
                    Id = "0edcbe7e-6955-4d78-9643-f2a32b129840",
                    Name = "Camera Module",
                    Code = "CAM-003",
                    CategoryID = "CAT-003",
                    Status = DeviceStatus.UnderMaintenance,
                    DateOfEntry = new DateTime(2023, 11, 15),
                    UserId="0edcbe7e-6955-4d78-9643-f2a32b129840"
                },
                new Device
                {
                    Id = "7b06794e-39ac-40f8-bc6a-0cf8e2e2d371",
                    Name = "Pressure Gauge",
                    Code = "PG-004",
                    CategoryID = "CAT-004",
                    Status = DeviceStatus.Broken,
                    DateOfEntry = new DateTime(2024, 1, 25),
                    UserId="7b06794e-39ac-40f8-bc6a-0cf8e2e2d371"
                }
            };

        public static List<Category> Categories = new List<Category> {
        new Category
                {
                    Id = "CAT-001",
                    Name = "Electronics",
                    Description = "Devices and gadgets such as phones, laptops, and tablets."
                },
                new Category
                {
                    Id = "CAT-002",
                    Name = "Home Appliances",
                    Description = "Appliances for home use, including washing machines, refrigerators, and microwaves."
                },
                new Category
                {
                    Id = "CAT-003",
                    Name = "Furniture",
                    Description = "Tables, chairs, sofas, and other furniture items."
                },
                new Category
                {
                    Id = "CAT-004",
                    Name = "Books",
                    Description = "Various genres of books, from fiction to non-fiction and academic."
                },
                new Category
                {
                    Id = "CAT-005",
                    Name = "Clothing",
                    Description = "Fashionable and comfortable clothing for men, women, and kids."
                },
                new Category
                {
                    Id="DOG-001",
                    Name="Household",
                    Description="Washing machine helper"
                }
            };
        public static List<User> Users = new List<User> {
        new User
                {
                    Id = "328a56f9-88c3-4767-a8bb-b865c121c2b7",
                    FullName = "Tu Thi Hong Diep",
                    Email = "hongdiep@gmail.com",
                    PhoneNumber = "0123456789"
                },
                new User
                {
                    Id = "dc409eb4-a6a0-40c9-adb2-bcee9dffb9b0",
                    FullName = "Nguyen Van A",
                    Email = "nguyenvana@example.com",
                    PhoneNumber = "0987654321"
                },
                new User
                {
                    Id = "0edcbe7e-6955-4d78-9643-f2a32b129840",
                    FullName = "Tran Thi B",
                    Email = "tranthib@example.com",
                    PhoneNumber = "0345678901"
                },
                new User
                {
                    Id = "7b06794e-39ac-40f8-bc6a-0cf8e2e2d371",
                    FullName = "Le Hoang C",
                    Email = "lehoangc@example.com",
                    PhoneNumber = "0765432109"
                }

            };
    }
}
