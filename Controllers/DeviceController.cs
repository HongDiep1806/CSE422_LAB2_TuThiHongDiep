using Lab2_TuThiHongDiep_CSE422.Database;
using Lab2_TuThiHongDiep_CSE422.Models;
using Microsoft.AspNetCore.Mvc;
using Lab2_TuThiHongDiep_CSE422.Models.WebModel;

namespace Lab2_TuThiHongDiep_CSE422.Controllers
{
    public class DeviceController : Controller
    {
        [HttpGet]
        public IActionResult DeviceManagement()
        {
            var devices = VirtualDatabase.Devices;
            var users = VirtualDatabase.Users;
            var categories = VirtualDatabase.Categories;

            var results = devices.Select(d => new GetAllDeviceResponse
            {
                Id = d.Id.ToString(),
                Name = d.Name,
                CategoryName = categories.FirstOrDefault(c => c.Id.Equals(d.CategoryID.ToString()))?.Name ?? "Unknown",
                Code = d.Code,
                DateOfEntry = d.DateOfEntry,
                Status = d.Status,
                UserUsingName = users.FirstOrDefault(u => u.Id.Equals(d.UserId.ToString()))?.FullName ?? "Unassigned"
            }).ToList();

            return View(results);
        }

        [HttpGet]
        public IActionResult CreateDevice()
        {
            var categories = VirtualDatabase.Categories.ToList();
            var users = VirtualDatabase.Users.ToList();
            ViewData["Categories"] = categories;
            ViewData["Users"] = users;

            return View();
        }
        [HttpPost]
        public IActionResult CreateDevice(CreateDeviceRequest request)
        {
            if (ModelState.IsValid)
            {
                var status = DeviceStatus.Broken;
                if (request.Status.Equals("1"))
                {
                    status = DeviceStatus.InUse;
                }
                else if (request.Status.Equals("2"))
                {
                    status = DeviceStatus.Broken;
                }
                else
                {
                    status = DeviceStatus.UnderMaintenance;
                }
                var newDevice = new Device
                {
                    Name = request.Name,
                    Code = request.Code,
                    CategoryID = request.CategoryID,
                    Status = status,
                    DateOfEntry = request.DateOfEntry,
                    UserId = request.UserId ?? ""
                };

                VirtualDatabase.Devices.Add(newDevice);

                return RedirectToAction("DeviceManagement");
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditDevice(EditDeviceRequest request)
        {
            var editedDevice = VirtualDatabase.Devices.FirstOrDefault(d => d.Id.Equals(request.Id));
            editedDevice.Status=request.Status;
            editedDevice.DateOfEntry=request.DateOfEntry;
            editedDevice.CategoryID=request.CategoryID;
            editedDevice.Code=request.Code;
            editedDevice.Name=request.Name;
            editedDevice.UserId=request.UserId;
            Console.WriteLine(editedDevice);
            return RedirectToAction("DeviceManagement");
        }

        [HttpGet]
        public IActionResult EditDevice(string id)
        {
            var editedDevice = VirtualDatabase.Devices.FirstOrDefault(d => d.Id == id);

            if (editedDevice == null)
            {
                return NotFound(); // Handle cases where the device does not exist
            }

            var categories = VirtualDatabase.Categories;
            var users = VirtualDatabase.Users;

            ViewData["Categories"] = categories;
            ViewData["Users"] = users;
            Console.WriteLine(editedDevice.UserId);
            return View(editedDevice);
        }


        
        [HttpPost]
        public IActionResult DeleteDevice(string id)
        {
            var deletedDevice = VirtualDatabase.Devices.FirstOrDefault(d => d.Id == id);
            if (deletedDevice != null)
            {
                var devices = VirtualDatabase.Devices;
                var relatedDevices = devices.Where(d => d.CategoryID.Equals(id)).ToList();
                foreach (var relatedDevice in relatedDevices) 
                {
                    relatedDevice.CategoryID = "";
                }
                VirtualDatabase.Devices.Remove(deletedDevice);
            }
            return RedirectToAction("DeviceManagement");
        }


    }
}
