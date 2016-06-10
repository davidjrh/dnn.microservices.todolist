using System;
using System.Linq;

namespace TodoList.API.Models
{
    public interface ITodoItemRepository : IDisposable
    {
        IQueryable<TodoItem> GetAllTodoItems();
        TodoItem GetTodoItem(string id);
        void Save(TodoItem todoItem);
        TodoItem Add(TodoItem todoItem);
        void Delete(string id);
    }
}