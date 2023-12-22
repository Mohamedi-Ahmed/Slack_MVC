using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP_SlackMVC.Models;

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
        [Route("/threads/{id?}")]
        public IActionResult Index(int? id)
        {
            if(id == null)
            {
                var mesThreads = _context.Threads;
                return Json(mesThreads);
            }else
            {
            var monThread = _context.Threads.Find(id);
            return Json(monThread);
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}