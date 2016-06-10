using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TodoList.API.Models;

namespace TodoList.API.Controllers
{
    // TODO Enable CORS only for desired locations. 
    // Use of wildcards for all of the parameters with the EnableCors attribute is intended only 
    // for demonstration purposes, and will open your API up to all origins and all HTTP requests. 
    // Please use this attribute with caution and understand the implications.
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TodoItemsController : ApiController
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemsController(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TodoItems
        public IQueryable<TodoItem> GetTodoItems()
        {
            return _repository.GetAllTodoItems();
        }

        // GET: api/TodoItems/5
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult GetTodoItem(string id)
        {
            var todoItem = _repository.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]
        public IHttpActionResult CloseItem(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _repository.GetTodoItem(id);

            item.Complete = true;
            _repository.Save(item);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TodoItems
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult PostTodoItem(TodoItem todoItem)
        {
            todoItem.Id = Guid.NewGuid().ToString();
            todoItem.CreatedAt = DateTimeOffset.UtcNow;
            todoItem.UpdatedAt = DateTimeOffset.UtcNow;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(todoItem);
            
            return CreatedAtRoute("DefaultApi", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult DeleteTodoItem(string id)
        {
            var todoItem = _repository.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            todoItem.Deleted = true;
            _repository.Save(todoItem);

            return Ok(todoItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}