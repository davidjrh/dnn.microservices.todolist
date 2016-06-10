using System.Linq;
using TodoList.API.Models;

namespace TodoList.API.Tests.Models
{
    public class TodoItemTestRepository : ITodoItemRepository
    {

        public IQueryable<TodoItem> GetAllTodoItems()
        {
            var result = Enumerable.Empty<TodoItem>().AsQueryable();
            return result;
        }

        public TodoItem GetTodoItem(string id)
        {
            return new TodoItem {Id = id};
        }

        public void Save(TodoItem todoItem)
        {
        }

        public TodoItem Add(TodoItem todoItem)
        {
            return todoItem;
        }

        public void Delete(string id)
        {
        }

        public void Dispose()
        {
        }
    }
}