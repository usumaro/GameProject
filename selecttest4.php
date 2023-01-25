<?php

require_once('mysql_connect2.php');
  $db = connectDB();

$sql = "DELETE FROM position_table ";
$sql2 =" ALTER TABLE position_table auto_increment = 1 ";
  
  $result = mysqli_query($db, $sql,$sql2);


  $db = mysqli_close($db);

  ?>
