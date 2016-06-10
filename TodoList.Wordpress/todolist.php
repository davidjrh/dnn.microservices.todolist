<?php
/*
Plugin Name: DNN ToDo list
Description: This is a todolist plugin to test the microservices system
Version: 1.0
Author: César Abreu
*/

/*** Globals ***/
$GLOBALS['todolistMainJs'] = "http://localhost:21345/dist/js/todolist.min.js";

/*** Options ***/

/*** plugin ***/
function dnn_todolist_scripts_important()
{
    wp_register_script("todolist", $GLOBALS['todolistMainJs'], __FILE__);
    wp_enqueue_script("todolist");
}
add_action('wp_enqueue_scripts', 'dnn_todolist_scripts_important', 5 );

function get_todolist_form() {
?>
	<div style="border: 1px solid red" id="container"></div>
    <script language="javascript" src="http://localhost:21345/dist/lib/jquery/jquery.js"></script>
    <script language="javascript" src="http://localhost:21345/dist/lib/knockout/knockout.js"></script>
	<style type="text/css">
		.dnnPrimaryAction {
			background-color: lightgray;
			margin-top: 10px;
		}
	</style>
	
    <script type="text/javascript">
        var todoListMgr = new dnnservices.TodoListManager(
            {
                container: document.all["container"],
                loaddependencies: true
            });
        window.onload = function() {
            todoListMgr.init();
        }
    </script>       
<?php
}

function todolist_shortcode() {
    ob_start();
    get_todolist_form();
    
    return ob_get_clean();
}

add_shortcode('todolist_form', 'todolist_shortcode');
?>