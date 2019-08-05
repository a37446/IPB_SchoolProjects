<h1 class="page_title"> [WORKS AND ROOMS PAGE] </h1> 
<?php
$work_array= WorkController::retrieve_works_for_rooms();
$output='<table class="work_table"> <tr> <th> Room Name </th> <th> Work Name </th> <th> Work Material </th> <th> Work type </th> <th> Realization date </th> <th> Work Description </th> <th> Artist Name </th> <th> Work Picture </th> </tr>';
for ($i=0;$i<count($work_array);$i++) {
            $output = $output . '<tr>';
            $output = $output . '<td>' . $work_array[$i]->getRoom_name() . "</td>";
            $output = $output . '<td>' . $work_array[$i]->getWork_name() . "</td>";
            $output = $output . '<td>' . $work_array[$i]->getMaterial() . "</td>";
            $output = $output . '<td>' . $work_array[$i]->getType() . "</td>";
            $output = $output . '<td>' . $work_array[$i]->getDate() . "</td>";
            $output = $output . '<td>' . $work_array[$i]->getWork_description() . "</td>";
            $output = $output . '<td>' . $work_array[$i]->getArtist_name() . "</td>";
            $output = $output . "<td>" . '<img class="work_image" src="'. $work_array[$i]->getWork_image() .'"> </td>';
            $output = $output . '</tr>';
}
$output= $output . "</table>";
echo $output;
?>
