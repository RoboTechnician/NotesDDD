using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Web.Models;
using Domain.Models;
using Domain.Repositories;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly UserManager<User> _userManager;

        public HomeController(INoteRepository noteRepository, UserManager<User> userManager)
        {
            _noteRepository = noteRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string search = null)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            return View(await _noteRepository.GetNotes(_userManager.GetUserId(User), search));
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNoteViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                var note = new Note { Id = 0, Text = model.Text, Title = model.Title, User = await _userManager.GetUserAsync(User) };
                await _noteRepository.AddNote(note);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var note = await _noteRepository.GetNote(id);

            if (note != null)
            {
                if (note.User.Id == _userManager.GetUserId(User))
                {
                    await _noteRepository.DeleteNote(id);
                    return RedirectToAction("Index");
                }
            }

            return Forbid();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
