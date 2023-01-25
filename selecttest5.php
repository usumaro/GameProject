<?php

require_once('mysql_connect2.php');
  $db = connectDB();

$sql = " DELETE FROM  bestposition_table  ";
$sql2 = "INSERT INTO bestposition_table SELECT * FROM position_table";
  
  mysqli_query($db, $sql,$sql2);


  $db = mysqli_close($db);

  ?>
