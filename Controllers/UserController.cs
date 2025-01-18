using Lab2_TuThiHongDiep_CSE422.Database;
using Lab2_TuThiHongDiep_CSE422.Models;
using Lab2_TuThiHongDiep_CSE422.Models.WebModel;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_TuThiHongDiep_CSE422.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserManagement()
        {
            List<User> users = VirtualDatabase.Users;
            return View(users);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    FullName=request.FullName,
                    PhoneNumber=request.PhoneNumber,    
                    Email=request.Email
                };

                VirtualDatabase.Users.Add(newUser);

                return RedirectToAction("UserManagement");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            var deletedUser = VirtualDatabase.Users.FirstOrDefault(d => d.Id == id);
            if (deletedUser != null)
            {
                var devices = VirtualDatabase.Devices;
                var relatedDevices = devices.Where(d => d.UserId.Equals(id)).ToList();
                foreach (var relatedDevice in relatedDevices)
                {
                    relatedDevice.UserId = "";
                }
                VirtualDatabase.Users.Remove(deletedUser);
            }
            return RedirectToAction("UserManagement");
        }
        [HttpPost]
        public IActionResult EditUser(EditeUserRequesr request)
        {
            var editedUser = VirtualDatabase.Users.FirstOrDefault(d => d.Id.Equals(request.Id));
            editedUser.Id=request.Id;
            editedUser.PhoneNumber=request.PhoneNumber;
            editedUser.FullName=request.FullName;   
            editedUser.Email=request.Email;
            Console.WriteLine(editedUser);
            return RedirectToAction("UserManagement");
        }

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var editedUser = VirtualDatabase.Users.FirstOrDefault(d => d.Id == id);

            if (editedUser == null)
            {
                return NotFound();
            }
            return View(editedUser);
        }
    }
}
