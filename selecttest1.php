<?php

  require_once('mysql_connect.php');
  $db = connectDB();


  $id = $_POST["time1"];
  $id1 = $_POST["name1;"];
  

  $sql = "INSERT INTO time_table(name,time,time_date) VALUES ('".$id1."','".$id."',CURRENT_TIMESTAMP())" ;
 
  $result = mysqli_query($db, $sql);

  

  $db = mysqli_close($db);

  if(!$db)
  {

    exit('データベースとの接続を閉じられませんでした。');
  }

?>