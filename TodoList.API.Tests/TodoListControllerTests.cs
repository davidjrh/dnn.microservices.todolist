using System;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.API.Controllers;
using TodoList.API.Models;
using TodoList.API.Tests.Models;

namespace TodoList.API.Tests
{
    [TestClass]
    public class TodoListControllerTests
    {
        private readonly TodoItemsController _controller = new TodoItemsController(new TodoItemTestRepository());

        [TestMethod]
        public void GetItems()
        {
            var result = _controller.GetTodoItems();
            Assert.AreEqual(result != null, true, "There should be a valid result when querying the TodoItems list");
        }

        [TestMethod]
        public void AddItem()
        {
            var item = new TodoItem
            {
                Complete = false,
                Deleted = false,
                Text = "This is a test"
            };
            var result = (CreatedAtRouteNegotiatedContentResult<TodoItem>) _controller.PostTodoItem(item);

            Guid guidOutput;
            var isValid = Guid.TryParse(result.Content.Id, out guidOutput);
            Assert.AreEqual(true, isValid, "Id is not a valid GUID");
        }

        [TestMethod]
        public void CloseItem()
        {
            var item = (OkNegotiatedContentResult<TodoItem>) _controller.GetTodoItem(Guid.NewGuid().ToString());
            var result = (StatusCodeResult) _controller.CloseItem(item.Content.Id);
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode, "Wrong status code; NoContent expected");
        }

        [TestMethod]
        public void DeleteItem()
        {
            var item = (OkNegotiatedContentResult<TodoItem>)_controller.GetTodoItem(Guid.NewGuid().ToString());
            var result = (OkNegotiatedContentResult<TodoItem>) _controller.DeleteTodoItem(item.Content.Id);
            Assert.AreEqual(true, result.Content.Deleted, "The item was not marked as deleted");
        }

        [TestMethod]
        public void CrudOperations()
        {
            
            const string textToInsert = "This is from the testing tool";

            // Insert an item
            var result = (CreatedAtRouteNegotiatedContentResult<TodoItem>) _controller.PostTodoItem(new TodoItem {Complete = false, CreatedAt = DateTimeOffset.UtcNow, Deleted = false, Id = "", Text = textToInsert});
            Assert.AreEqual(result.Content.Text, textToInsert);

            // Get inserted item
            var item = (OkNegotiatedContentResult<TodoItem>) _controller.GetTodoItem(result.Content.Id);
            Assert.AreEqual(item.Content.Id, result.Content.Id);

            // Update inserted item
            var closeResult = (StatusCodeResult)_controller.CloseItem(item.Content.Id);
            Assert.AreEqual(closeResult.StatusCode, HttpStatusCode.NoContent, "Wrong status code; NoContent expected");

            // Delete item
            var deleteResult = (OkNegotiatedContentResult<TodoItem>)_controller.DeleteTodoItem(item.Content.Id);
            Assert.AreEqual(true, deleteResult.Content.Deleted, "The item was not marked as deleted");
        }
    }
}
