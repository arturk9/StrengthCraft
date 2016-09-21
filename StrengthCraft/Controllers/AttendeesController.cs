using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using StrengthCraft.Models;
using StrengthCraft.ViewModels;

namespace StrengthCraft.Controllers
{
    public class AttendeesController : Controller
    {
        private ApplicationDbContext _context;

        public AttendeesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Attendees
        public ActionResult Create()
        {
            var viewModel = new AttendanceFormViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateAttendance(AttendanceFormViewModel viewModel)
        {
            var category = _context.Categories.Single(g => g.Id == viewModel.Category);

            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }
            

            var attendance = new Attendee
            {
                AttendeeLastName = viewModel.AttendeeLastName,
                AttendeeName = viewModel.AttendeeName,
                Weight = viewModel.Weight,
                EmailAddress = viewModel.EmailAddress,
                YoutubeMovieUrl = viewModel.YoutubeMovieUrl,
                WorkoutDurationTime = viewModel.WorkoutDurationTime,
                Category = category,
                IsVerified = false,
                RegistrationDate = DateTime.Now
                
            };

            _context.Attendees.Add(attendance);
            _context.SaveChanges();

            return View("~/Views/Attendees/ThankYou.cshtml");

        }

        public ActionResult AwaitingAttendances()
        {

            var awaitingAttendances = _context.Attendees
                .Where(t => t.IsVerified == false)
                .Include(t=>t.Category)
                .ToList();

            return View(awaitingAttendances);
        }

        public ActionResult AcceptedAttendances()
        {
            var acceptedAttendances = _context.Attendees
                .Where(t => t.IsVerified == true)
                .Include(t => t.Category)
                .ToList();

            return View(acceptedAttendances);
        }

        public ActionResult AcceptAttendance(int id)
        {
            _context.Attendees.Single(m => m.AttendeeId == id).IsVerified = true;

            _context.SaveChanges();
            return RedirectToAction("AwaitingAttendances", "Attendees");
        }

        public ActionResult DeleteAttendance(int id)
        {
            var attendanceToRemove = _context.Attendees.Single(m => m.AttendeeId == id);
            _context.Attendees.Remove(attendanceToRemove);
            _context.SaveChanges();
            return RedirectToAction("AwaitingAttendances", "Attendees");
        }
    }
}