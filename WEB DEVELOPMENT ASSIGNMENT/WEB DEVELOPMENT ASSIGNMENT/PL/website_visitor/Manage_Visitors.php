<h1 class="page_title"> [MANAGE WORKS PAGE] </h1> 
<h3> WORK LIST </h3>
<div>
<?php include("Visitor_list.php");
if (isset($_SESSION['outcome'])) {
    if ($_SESSION['outcome'] == 1) {
        echo '<h3 class="error_message"> Operation reported an error: Could not create a website visitor </h3>';
    }
    if ($_SESSION['outcome'] == 2) {
        echo '<h3 class="error_message"> Operation reported an error: Visitor ID not found, could not update a non existent record </h3>';
    }
    if ($_SESSION['outcome'] == 3) {
        echo '<h3 class="error_message"> Operation reported an error: Visitor ID not found, could not delete a non existent record </h3>';
    } 
    if ($_SESSION['outcome'] == 4) {
        echo '<h3 class="error_message"> Operation reported an error: Invalid form, one or more fields are empty </h3>';
    }
    $_SESSION['outcome']=0;
}
?>
</div>
<h3> INSERT NEW VISITOR </h3>
<div>
 <form class="user_data_form" action="index.php?category=website_visitor&page=Manage_Visitors.php" method="POST">
     <input type="number" name="new_visitor_visited_page" class="input_text" placeholder="Enter new visit visited pages" required> <br/>
     <input type="datetime" name="new_visitor_visit_start" class="input_text" placeholder="Enter new visit start (yyyy-mm-dd hh:mm)" required> <br/>
     <input type="datetime" name="new_visitor_visit_end" class="input_text" placeholder="Enter new visit end (yyyy-mm-dd hh:mm)" > <br/>
     <input type="submit" value="Create New Visitor" name="create_visit"> <br/>
 </form>
</div>
<h3> UPDATE VISITOR </h3>
<div>
 <form class="user_data_form" action="index.php?category=website_visitor&page=Manage_Visitors.php" method="POST">
     <input type="number" name="update_visitor_id" class="input_text" placeholder="Enter update visitID" required> <br/>
     <input type="number" name="update_visitor_visited_page" class="input_text" placeholder="Enter updated visit visited pages" required> <br/>
     <input type="datetime" name="update_visitor_visit_start" class="input_text" placeholder="Enter updated visit start (yyyy-mm-dd hh:mm)" required> <br/>
     <input type="datetime" name="update_visitor_visit_end" class="input_text" placeholder="Enter updated visit end (yyyy-mm-dd hh:mm)" > <br/>
     <input type="submit" value="Update Visitor" name="update_visit"> <br/>
 </form>
</div>
<h3> DELETE VISITOR </h3>
<div>
 <form class="user_data_form" action="index.php?category=website_visitor&page=Manage_Visitors.php" method="POST">
     <input type="number" name="delete_visitor_id"  class="input_text" placeholder="Enter delete visitor ID" required> <br/>  
     <input type="submit" value="Delete Visitor" name="delete_visit"> <br/>
 </form>
</div>



