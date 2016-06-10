if (typeof dnnservices === 'undefined') dnnservices = {};
dnnservices.filesloaded = "";
dnnservices.todoList = null;

dnnservices.loadcss = function (css) {
    if (dnnservices.filesloaded.indexOf("[" + css + "]") !== -1) return;
    var head = document.getElementsByTagName("head")[0];
    if (head === null || typeof head === 'undefined') return;
    var n = document.createElement("link");
    n.setAttribute("rel", "stylesheet");
    n.setAttribute("type", "text/css");
    n.setAttribute("href", css);
    head.appendChild(n);
    dnnservices.filesloaded += "[" + css + "]";
}

dnnservices.loadjs = function (js) {
    if (dnnservices.filesloaded.indexOf("[" + js + "]") !== -1) return;
    var head = document.getElementsByTagName("head")[0];
    if (head === null || typeof head === 'undefined') return;
    var n = document.createElement("script");
    n.setAttribute("type", "text/javascript");
    n.setAttribute("src", js);
    head.appendChild(n);
    dnnservices.filesloaded += "[" + js + "]";
}

dnnservices.TodoListManagerOptions = function(o) {
    return {
        container: o.container || document.body,
        loaddependencies: o.loaddependencies || false
    }
}

dnnservices.TodoListManager = function(o) {
    var that = this;
    this.options = new dnnservices.TodoListManagerOptions(o);
    if (that.options.loaddependencies) {
        dnnservices.loadcss(dnnservices.todoListUrl + 'lib/bootstrap/dist/css/bootstrap.min.css');
        dnnservices.loadcss(dnnservices.todoListUrl + 'lib/bootstrap/dist/css/bootstrap-theme.min.css');

        //dnnservices.loadjs(dnnservices.todoListUrl + "lib/jquery/dist/jquery.min.js");
        dnnservices.loadjs(dnnservices.todoListUrl + "lib/bootstrap/dist/js/bootstrap.min.js");
        //dnnservices.loadjs(dnnservices.todoListUrl + "lib/knockout/dist/knockout.js");
    }
    dnnservices.loadcss(dnnservices.todoListUrl + 'css/todolist.min.css');

    this.init = function (container) {
        var c = container || that.options.container;
        if (typeof c !== 'undefined') c.innerHTML = mytemplate["index.html"];
        dnnservices.todoList = new dnnservices.TodoList();        
        ko.applyBindings(dnnservices.todoList, c);
        dnnservices.todoList.init();
    };
}

dnnservices.TodoList = function() {
    var that = this;
    var apiPath = dnnservices.todoListApiUrl;

    this.ItemModel = function(id, text, complete, createdAt, updatedAt) {
        var thisObject = this;

        this.Id = ko.observable(id);
        this.Text = ko.observable(text);
        this.Complete = ko.observable(complete);
        this.CreatedAt = ko.observable(createdAt);
        this.UpdatedAt = ko.observable(updatedAt);

        this.completeTask = function() {
            thisObject.Complete(true);
            that.saveItem(thisObject);
        }
    }

    this.loading = ko.observable(false);

    this.items = ko.observableArray([]);

    this.init = function () {
        that.getItems();
    };

    this.getItems = function() {
        that.loading(true);
        jQuery.getJSON(apiPath,
            null,
            function(items) { // Success
                that.items.removeAll();
                items.forEach(function(item) {
                    that.items.push(new that.ItemModel(item.Id, item.Text, item.Complete, item.CreatedAt, item.UpdatedAt));
                });
                that.loading(false);
            });
    };

    this.addItem = function() {
        var item = new that.ItemModel("", jQuery("#Text").val(), false, "", "");

        jQuery.ajax({
            method: "POST",
            dataType: "json",
            url: apiPath,
            data: {
                "Id": item.Id(),
                "Text": item.Text()
            },
            success: function() {
                that.getItems();
            }
        });
    };

    this.saveItem = function(item) {
        jQuery.ajax({
            method: "POST",
            dataType: "json",
            url: apiPath + '/' + item.Id(),
            success: function() {
                that.getItems();
            }
        });
    }
}

