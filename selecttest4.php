<?php

require_once('mysql_connect.php');
  $db = connectDB();

$sql = "DELETE FROM position_table ";

  
  $result = mysqli_query($db, $sql);



  $sql =" ALTER TABLE position_table auto_increment = 1 ";


  $result = mysqli_query($db, $sql);


  $db = mysqli_close($db);

  ?>
