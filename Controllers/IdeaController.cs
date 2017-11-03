using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using blueSwash.Models;

namespace blueSwash.Controllers
{
    public class IdeaController : Controller
    {
        private IdeaContext _context;
        public IdeaController(IdeaContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("bright_ideas")]
        public IActionResult List()
        {
            if (HttpContext.Session.GetInt32("currentUserId") == null)
            {
                return RedirectToAction("Main");
            }
            int currentId = (int)HttpContext.Session.GetInt32("currentUserId");
            ViewBag.alias = _context.users
                .FirstOrDefault(item => item.usersId == currentId)
                .alias;
            ViewBag.id = currentId;
            ListViewModel showIdeas = new ListViewModel
            {
                ideas = _context.ideas.Include(item => item.creator).Include(item => item.liked).ToList()
            };
            return View(showIdeas);
        }
        [HttpPost]
        [Route("bright_ideas/add")]
        public IActionResult AddIdea(IdeaViewModel incoming)
        {
            if (ModelState.IsValid)
            {
                Ideas newIdea = new Ideas();
                newIdea.usersId = (int)HttpContext.Session.GetInt32("currentUserId");
                newIdea.creator = _context.users.FirstOrDefault(item => item.usersId == HttpContext.Session.GetInt32("currentUserId"));
                newIdea.text = incoming.text;
                _context.Add(newIdea);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        [Route("bright_ideas/delete/{id}")]
        public IActionResult Delete(int id)
        {
            Ideas toDelete = _context.ideas.SingleOrDefault(item => item.ideasId == id);
            _context.ideas.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        [Route("bright_ideas/{id}")]
        public IActionResult Detail(int id)
        {
            IdeaDetail ideaData = new IdeaDetail
            {
                idea = _context.ideas.Include(item => item.liked).ThenInclude(item => item.user).FirstOrDefault(item => item.ideasId == id)
            };
            return View(ideaData);
        }
        // [HttpPost]
        // [Route("like")]
        // public IActionResult Like(int id)
        // {
        //     Users thisuser = _context.users.FirstOrDefault(item => item.usersId == HttpContext.Session.GetInt32("currentUserId"));
        //     thisuser.likes.Add(id);
        //     Ideas thisidea = _context.ideas.FirstOrDefault(item => item.ideasId == id);
        //     LikedIdeas newlike = new LikedIdeas
        //     {
        //         usersId = thisuser.usersId,
        //         user = thisuser,
        //         ideasId = thisidea.ideasId,
        //         idea = thisidea,
        //     };
        //     thisidea.liked.Add(newlike);
        //     _context.SaveChanges();
        //     return RedirectToAction("List");
        // }

    }
}