<?php

require_once('mysql_connect2.php');
  $db = connectDB();

 $sql = " DELETE FROM  bestposition_table  ";

  
  mysqli_query($db, $sql);

  $sql = "INSERT INTO bestposition_table SELECT * FROM position_table";

  mysqli_query($db, $sql);


  $db = mysqli_close($db);

  ?>
