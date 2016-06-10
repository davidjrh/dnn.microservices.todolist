var mytemplate = {};

mytemplate["index.html"] = "<div id=\"TodoList\" class=\"todolist-container\" data-bind=\"with: dnnservices.todoList\">\n" +
   "  <h1>\n" +
   "    <span class=\"glyphicon glyphicon-list-alt\"></span> To Do List\n" +
   "  </h1>\n" +
   "  <div class=\"spinner\" data-bind=\"visible: loading()\" ></div>\n" +
   "  <div class=\"check-list-container\">\n" +
   "      <div class=\"check-list-item-container\">\n" +
   "          <ul class=\"check-list\">\n" +
   "              <!-- ko foreach: items -->\n" +
   "              <li class=\"check-list-item\" data-bind=\"visible: !Complete(), click: completeTask\">\n" +
   "                  <span class=\"glyphicon glyphicon-check\" aria-hidden=\"false\"></span>\n" +
   "                  <span data-bind=\"text: Text\"></span>\n" +
   "              </li>\n" +
   "              <!-- /ko -->\n" +
   "          </ul>\n" +
   "      </div>\n" +
   "  </div>\n" +
   "\n" +
   "  <hr class=\"\" />\n" +
   "  <div class=\"controls-container\">\n" +
   "    <div class=\"form-group\">\n" +
   "      <input id=\"Text\" type=\"text\" class=\"form-control\" placeholder=\"Task\"/>\n" +
   "      <button class=\"dnnPrimaryAction\" data-bind=\"click: addItem\">Add Item</button>\n" +
   "    </div>\n" +
   "  </div>\n" +
   "</div>\n" +
   "";
