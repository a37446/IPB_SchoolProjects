<h1 class="page_title"> [CHANGE DESCRIPTION PAGE] </h1> 
<div>
    <h3> USER DESCRIPTION </h3>
 <?php echo $_SESSION['user_description'];
            if (isset($_SESSION['outcome'])) {
    if ($_SESSION['outcome'] == 1) {
        echo '<h3 class="error_message"> Operation reported an error: Login Must be unique </h3>';
    }
    if ($_SESSION['outcome'] == 2) {
        echo '<h3 class="error_message"> Operation reported an error: ID not found, could not update a non existent record </h3>';
    }
    if ($_SESSION['outcome'] == 3) {
        echo '<h3 class="error_message"> Operation reported an error: ID not found, could not delete a non existent record </h3>';
    }
    if ($_SESSION['outcome'] == 4) {
        echo '<h3 class="error_message"> Operation reported an error: Invalid form, one or more fields are empty </h3>';
    }
    $_SESSION['outcome']=0; 
}?>
</div>
 <form class="user_data_form" action="index.php?category=user&page=Change_Description.php" method="POST">
     <input type="text" name="new_description" id="description_input" class="input_text" placeholder="Enter new description" required> <br/>
     <input id="change_description_button" type="submit" value="Change Description" name="change_description"> <br/>
 </form>
<div> NB: Changes will be performed at the Logout </div>




