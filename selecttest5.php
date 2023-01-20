<?php

require_once('mysql_connect2.php');
  $db = connectDB();

$sql = "INSERT INTO bestposition_table SELECT * FROM position_table";
  
  $result = mysqli_query($db, $sql);


  $db = mysqli_close($db);

  ?>
