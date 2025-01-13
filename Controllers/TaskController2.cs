using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo_webapi.Models;
using ToDo_webapi.Services;

namespace ToDo_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController2 : ControllerBase
    {
        [HttpPost("/CreateTask")]
        public IActionResult CreateTask(ToDoTask task)
        {
            ToDoTaskServices.AddToDoTask(task);
            return Created();
        }

        [HttpDelete("/DeleteTask")]
        public IActionResult DeleteTask(ToDoTask task)
        {
            bool result = ToDoTaskServices.DeleteToDoTask(task);
            if (result)
                return Ok();
            return NotFound();
        }
        
        [HttpDelete("/DeleteTask/{id}")]
        public IActionResult DeleteTaskById(int id)
        {
            bool result = ToDoTaskServices.DeleteToDoTask(id);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpPut("/UpdateTask/{id}")]
        public IActionResult UpdateTask(int id, ToDoTask task)
        {
            bool result = ToDoTaskServices.UpdateToDoTask(id, task);
            if (result)
                return Ok();
            return NotFound();
        }
        
        [HttpGet("/GetAllTasks")]
        public ActionResult<List<ToDoTask>> GetAllTasks()
        {
            return ToDoTaskServices.GetAllToDoTasks();
        }
        
        [HttpGet("/GetAllTasksByCreationDate")]
        public ActionResult<List<ToDoTask>> GetAllTasksByCreationDate(DateOnly date)
        {
            return ToDoTaskServices.GetToDoTasksByCreationDate(date);
        }
        
        [HttpGet("/GetAllTasksByPeoples")]
        public ActionResult<List<ToDoTask>> GetAllTasksByPeoples()
        {
            return ToDoTaskServices.GetToDoTasksByPeoples();
        }
        
        [HttpGet("/GetAllTasksByPriority")]
        public ActionResult<List<ToDoTask>> GetToDoTasksByPriority(ushort priority)
        {
            return ToDoTaskServices.GetToDoTasksByPriority(priority);
        }
        
        [HttpGet("/GetAllTasksByCategory")]
        public ActionResult<List<ToDoTask>> GetAllTasks(string category)
        {
            return ToDoTaskServices.GetToDoTasksByCategory(category);
        }
        
        [HttpGet("/GetAllTasksByComplite")]
        public ActionResult<List<ToDoTask>> GetAllTasks(bool isComplite)
        {
            return ToDoTaskServices.GetToDoTasksByComplite(isComplite);
        }

        [HttpPut("/MarkAsDone")]
        public IActionResult MarkAsDone(ToDoTask task)
        {
            var result = ToDoTaskServices.MarkAsDone(task);
            if (result)
                return Ok();
            return NotFound();
        }

        [HttpPut("/MarkAsDone{id}")]
        public IActionResult MarkAsDone(int id)
        {
            var result = ToDoTaskServices.MarkAsDone(id);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}