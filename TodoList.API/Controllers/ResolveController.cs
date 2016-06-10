using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using TodoList.API.Models;

namespace TodoList.API.Controllers
{
    public class ResolveController: IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return serviceType == typeof(TodoItemsController) ? new TodoItemsController(new TodoItemRepository()) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
        }

    }
}