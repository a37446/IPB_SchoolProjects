<!DOCTYPE html>
<!--
PHP TEST FILE
-->

<?php
define('__ROOT__', dirname(dirname(__FILE__))); 
require_once(".\bl\class_WebsiteVisitor.php");
require_once(".\bl\class_WebsiteUser.php");
require_once(".\bl\class_WebsiteAdministrator.php");
require_once(".\bl\class_Museum.php");
require_once(".\bl\class_Ticket.php");
require_once(".\bl\class_Event.php");
require_once(".\bl\class_Room.php");
require_once(".\bl\class_Work.php");
require_once(".\bl\class_Artist.php");
require_once(".\bl\class_Event_Artist.php");
require_once(".\bl\class_Artist_Work.php");
require_once(".\DB\DB_class.php");
require_once("./DAL/DAL_WebsiteVisitor.php");
require_once ("./controllers/MasterController.php");

include("./PL/visitor/login-form.php");
include("./PL/visitor/register-form.php");
include("./PL/visitor/forgotpass-form.php");

session_start();
MasterController::process();
if(!isset($_SESSION['access'])) {$_SESSION['access']=0;}
echo 'Access_Level:' . $_SESSION['access'];
?>
<html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" type="text/css" href="./css/main_style.css">
        <link rel="stylesheet" type="text/css" href="./css/lightbox_style.css">
        <link rel="stylesheet" type="text/css" href="./css/genericpage_style.css">
        <link rel="stylesheet" type="text/css" href="./css/userAdmin_style.css">
        <link rel="stylesheet" type="text/css" href="./css/buyticket_style.css">
        <link rel="stylesheet" type="text/css" href="./css/data_table_style.css">
        <script type="text/javascript">
function get_timestamp() {
    return new Date().toISOString().slice(0, 19).replace('T', ' ');
}

function saveSessionComplete(){
if(this.readyState==4 && this.status==200){
var res=this.responseText;
var json=JSON.parse(res);
 alert(json.outcome);
 }
} 

window.onload = function () {
    visit_start=sessionStorage.getItem("visit_start");
    if(visit_start == null) {
        sessionStorage.setItem("visit_start",get_timestamp()); 
    }
    else {
        page=window.location.href;
        sessionStorage.setItem("visited_page",page.substring(page.indexOf('&')+6,page.length-4));    
        visit_start=sessionStorage.getItem("visit_start");
        visited_page=sessionStorage.getItem("visited_page");  
        visit_end=get_timestamp();
        //alert("session-start: " + visit_start + " session-end: " + visit_end + " visited_page: " + visited_page);
        var json_upload = JSON.stringify({visited_page: visited_page, visit_start: visit_start, visit_end: visit_end});
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "control/Ajax.php", true);
        xhr.setRequestHeader("Content-type", "application/x-www-formurlencoded"); 
        xhr.onreadystatechange = saveSessionComplete;
        xhr.send(json_upload);
    }
        };

function saveSessionComplete(){
if(this.readyState==4 && this.status==200){
var res=this.responseText;
var json=JSON.parse(res);
//alert(json.outcome); 
}
}    

        </script>
        <title>Home Page</title>
    </head>
    <body>
        <header>
        <div class="name_header"> OurMuseum </div>
        <img class="header_image" src="./resources/header_image.jpg" alt="Image not supported by web browser">
        </header>
        <div class="main_bar" >
            <nav class="navigation_bar"> 
                    <a class="nav_link" href="index.php?category=visitor&page=home.php">Home </a> 
                    <a class="nav_link" href="index.php?category=visitor&page=FAQ.php">FAQs </a> 
                    <a class="nav_link" href="index.php?category=visitor&page=Site_Map.php">Site Map </a> 
                    <a class="nav_link" href="index.php?category=visitor&page=Museum_Map.php">Museum Map </a> 
                    <a class="nav_link" href="index.php?category=visitor&page=Terms_Use.php">Terms of Use </a>
            </nav>
         <?php
         if($_SESSION['access']==1) {include('./PL/user/user_bar.php');} 
         else if($_SESSION['access']==2) {include('./PL/administrator/administrator_bar.php');} 
         else {include('./PL/visitor/visitor_bar.php');} 
         ?>
        </div>
        <div class="container">
            <aside class="sidebar_menu"> 
                         <?php
                        if($_SESSION['access']==1) {include('./PL/user/user_buy_tickets.php');} 
                        else if($_SESSION['access']==2) {include('./PL/administrator/administrator_buy_tickets.php');} 
                        else {include('./PL/visitor/visitor_buy_tickets.php');} 
                        ?>
                <nav class="option_menu">
                    <ul class="option_list">
                        <li> <a class="side_link" href="index.php?category=museum&page=Museums.php"> Museums </a> </li>
                        <li> <a class="side_link" href="index.php?category=room&page=Rooms_Museums.php"> Rooms for Museums </a> </li>
                        <li> <a class="side_link" href="index.php?category=artist&page=Artists.php"> Artists </a> </li>
                        <li> <a class="side_link" href="index.php?category=event&page=Events.php"> Events </a> </li>
                        <li> <a class="side_link" href="index.php?category=event_artist&page=Event_Artists.php"> Participations </a> </li>
                        <li> <a class="side_link" href="index.php?category=artist_work&page=Artist_Works.php"> Work contributions </a> </li>
                        <li> <a class="side_link" href="index.php?category=work&page=Works_Artists.php"> Works for Artists </a> </li>
                        <li> <a class="side_link" href="index.php?category=work&page=Works_Rooms.php"> Works for Rooms </a> </li>
                        <li> <a class="side_link" href="index.php?category=visitor&page=Reach_Museum.php"> How to reach us </a> </li>
                        <li> <a class="side_link" href="index.php?category=visitor&page=Opening_Hours.php"> Opening Hours </a> </li>
                    </ul>
                </nav>
                <?php
                if($_SESSION['access']==1) {include('./PL/user/user_menu.php');} 
                if($_SESSION['access']==2) {include('./PL/administrator/administrator_menu.php');} 
                ?>
            </aside>
             <main> 
                 <?php
                    	$url = './PL/';
	if (isset($_GET['category'])) {
		$url .= $_GET['category'] . '/';
	}
	if (isset($_GET['page'])) {
		$url .= $_GET['page'];
	}
        if (!isset($_GET['page'])) {
		$url .= "./visitor/home.php";
	}

	include $url;
                    ?>
             </main>
            
            <aside class="sidebar_newsfeed"> 
                <h2 class="newsfeed_title"> News and Events </h2>
                <ul class="events_feed">
                    <?php include('./PL/event/browse_events_bar.php'); ?>
                </ul>
            </aside>
        </div>         
        <footer class="footer_container">
                <nav class="footer_nav">
                    <a class="footer_link" href="index.php?category=visitor&page=Contacts.php">Contacts </a> 
                    <a class="footer_link" href="index.php?category=visitor&page=About_Us.php">About us </a> 
                    <a class="footer_link" href="index.php?category=visitor&page=Related_Links.php">Related Links </a> 
                </nav>
        </footer>
    </body>
</html>
