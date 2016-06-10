using System;
using System.Linq;

namespace TodoList.API.Models
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoListAPIContext _db = new TodoListAPIContext();

        public IQueryable<TodoItem> GetAllTodoItems()
        {
            return _db.TodoItems;
        }

        public TodoItem GetTodoItem(string id)
        {
            return _db.TodoItems.Find(id);
        }

        public void Save(TodoItem todoItem)
        {
            var item = GetTodoItem(todoItem.Id);
            if (item == null)
            {
                throw new Exception($"TodoItem not found. ID = {todoItem.Id}");
            }
            item.Complete = todoItem.Complete;
            item.CreatedAt = todoItem.CreatedAt;
            item.Deleted = todoItem.Deleted;
            item.Text = todoItem.Text;
            item.UpdatedAt = todoItem.UpdatedAt;

            _db.SaveChanges();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            _db.TodoItems.Add(todoItem);
            _db.SaveChanges();

            return todoItem;
        }

        public void Delete(string id)
        {
            var todoItem = _db.TodoItems.Find(id);
            if (todoItem == null)
            {
                throw new Exception($"TodoItem not found. ID = {id}");
            }

            _db.TodoItems.Remove(todoItem);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}