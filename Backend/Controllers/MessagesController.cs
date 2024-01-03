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
using System.ComponentModel.DataAnnotations;

namespace TP_SlackMVC.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ILogger<MessagesController> _logger;
	    private readonly DbSlackContext _context;

        public MessagesController(ILogger<MessagesController> logger, DbSlackContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("messages")]
        public IActionResult GetMessages([FromQuery] string? threadId)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Récupération des messages");
            Console.WriteLine("----------------------------------------------");

            // Si un threadId est fourni, filtrez par threadId
            if (!string.IsNullOrEmpty(threadId))
            {
                if (!int.TryParse(threadId, out int monId)){ return BadRequest("threadId doit être un entier !"); }

                var messagesByThreadId = _context.Messages.Where(m => m.ThreadId == monId).ToList();

                return Json(messagesByThreadId);
            }

            var mesMessages = _context.Messages.ToList();
            return Json(mesMessages);
        }

        [HttpGet]
        [Route("messages/{id:int}")]
        public IActionResult GetMessage(int? id)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans le choix d'un des messages");
            Console.WriteLine("----------------------------------------------");
            if(id == null) { return BadRequest("Pas d'id fourni !");}
            var monMessage = _context.Messages.Find(id);
            if (monMessage == null) {return BadRequest("Message non trouvé !");}
            return Json(monMessage);
            
        }
        
        public class MessageDto
        {
            public string Content { get; set; }
            public int AuthorId { get; set; }
            public int ThreadId { get; set; }

            public DateTime Date {get; set;}
        }

        public class MessageResponseDto
        {
            public int Id { get; set; }
            public string Content { get; set; }
            public int AuthorId { get; set; }
            public int ThreadId { get; set; }
            public DateTime Date { get; set; }
        }

        [HttpPost]
        [Route("messages")]
        public IActionResult CreateMessage([FromBody] MessageDto messageDto)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans la fonction create Messages");
            Console.WriteLine("----------------------------------------------");

            var author = _context.Users.Find(messageDto.AuthorId);
            var thread = _context.Threads.Find(messageDto.ThreadId);

            if (author == null || thread == null)
            {
                return BadRequest("Auteur ou Thread non trouvé !");
            }

            var message = new Message
            {
                Author = author,
                Thread = thread,
                Content = messageDto.Content,
                Date = messageDto.Date
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            var responseDto = new MessageResponseDto
            {
                Id = message.Id,
                Content = message.Content,
                AuthorId = message.Author.Id,
                ThreadId = message.Thread.Id,
                Date = message.Date
            };

            return Ok(responseDto);
        }

        [HttpPut]
        [Route("/messages/{id}")]
        public IActionResult UpdateMessage(int id, [FromBody] Message message)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans la fonction d'updateMessage");
            Console.WriteLine("----------------------------------------------");
            // Teste si le message existe par l'id
            var messageToUpdate = _context.Messages.Find(id);
            if(messageToUpdate == null) {return BadRequest("Message non trouvé !");}

            // test si la requete contient un contenu
            if(!ModelState.IsValid){ return BadRequest(ModelState);}
            messageToUpdate.Content = message.Content;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("/messages/{id}")]
        public IActionResult DeleteMessage(string id)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Je suis dans la fonction delete");
            Console.WriteLine("----------------------------------------------");

            if (!int.TryParse(id, out int myIntId)){return BadRequest("Mauvais ID !");}
            var messageToDelete = _context.Messages.Find(myIntId);
            if(messageToDelete == null) {return BadRequest("Message non trouvé !");}

            _context.Messages.Remove(messageToDelete);
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