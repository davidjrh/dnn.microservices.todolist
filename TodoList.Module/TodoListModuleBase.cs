/*
' Copyright (c) 2015 DNN Corp
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Configuration;
using DotNetNuke.Entities.Modules;

namespace TodoList
{
    public class TodoListModuleBase : PortalModuleBase
    {
        // TODO Change the constant for builds build
        public const string DefaultServicesUrl = "http://localhost:21345/";
        
        public TodoListModuleBase()
        {
            ServicesUrl =
                ConfigurationManager.AppSettings[
                    $"{nameof(TodoList)}.{nameof(TodoListModuleBase)}.ServicesUrl"];
            if (string.IsNullOrEmpty(ServicesUrl))
            {
                ServicesUrl = string.Format(DefaultServicesUrl, nameof(TodoList).ToLowerInvariant());
            }
        }

        public string ServicesUrl { get; set; }

        public string InitJs => $"{ServicesUrl}dist/js/todolist.min.js";
    }
}