﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using TodoList.API.Client.Models;

namespace TodoList.API.Client.Models
{
    public static partial class TodoItemCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<TodoItem> DeserializeJson(JToken inputObject)
        {
            IList<TodoItem> deserializedObject = new List<TodoItem>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                TodoItem todoItem = new TodoItem();
                todoItem.DeserializeJson(iListValue);
                deserializedObject.Add(todoItem);
            }
            return deserializedObject;
        }
    }
}