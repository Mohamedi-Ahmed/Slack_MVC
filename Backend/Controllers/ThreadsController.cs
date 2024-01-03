using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP_SlackMVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using SQLitePCL;

namespace TP_SlackMVC.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly ILogger<ThreadsController> _logger;
	    private readonly DbSlackContext _context;

        public ThreadsController(ILogger<ThreadsController> logger, DbSlackContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("threads")]
        public IActionResult GetThreads()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans mes THEADS");
            Console.WriteLine("----------------------------------------------");

            var mesThreads = _context.Threads;
            return Json(mesThreads);
        }

        [HttpGet]
        [Route("/threads/{id?}")]
        public IActionResult GetThread(int? id)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans le choix d'un des threads");
            Console.WriteLine("----------------------------------------------");
            if(id == null) { return BadRequest("Pas d'id fourni !");}
            var monThread = _context.Threads.Find(id);
            if (monThread == null) {return BadRequest("Thread non trouvé !");}
            return Json(monThread);
            
        }
        
        [HttpPost]
        [Route("threads")]
        public IActionResult CreateThread([FromBody] Models.Thread thread)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans la fonction create thread");
            Console.WriteLine("----------------------------------------------");
            if (ModelState.IsValid)
            {
                //thread.Id = _context.Threads.Count();
                _context.Threads.Add(thread);
                _context.SaveChanges();

                return Ok(thread);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("/threads/{id}")]
        public IActionResult UpdateThread(int id, [FromBody] Models.Thread thread)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans la fonction d'updatedethread");
            Console.WriteLine("----------------------------------------------");
            // Teste si le thread existe par l'id
            var threadToUpdate = _context.Threads.Find(id);
            if(threadToUpdate == null) {return BadRequest("Thread non trouvé !");}

            // test si la requete contient un label
            if(!ModelState.IsValid){ return BadRequest(ModelState);}
            threadToUpdate.Label = thread.Label;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("/threads/{id}")]
        public IActionResult DeleteThread(string id)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans la fonction delete");
            Console.WriteLine("----------------------------------------------");
                        
            int myIntId = int.Parse(id);
            var threadToDelete = _context.Threads.Find(myIntId);
            if(threadToDelete == null) {return BadRequest("Thread non trouvé !");}

            _context.Threads.Remove(threadToDelete);
            _context.SaveChanges();
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}