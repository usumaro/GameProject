<?php


require_once('mysql_connect.php');
  $db = connectDB();


  $id = $_POST["time1"];
  $id1 = $_POST["name1"];
  

  $sql = "INSERT INTO time_table(name,time,time_date) VALUES ('".$id1."','".$id."',CURRENT_TIMESTAMP())" ;
 
  $result = mysqli_query($db, $sql);

  while ($data = $result ->fetch_assoc())
  {
     $res = $data['time_id'];
     $res .= ",".$data['time'];
     $res .= ",".$data['time_date'];
    
  }

  $db = mysqli_close($db);

  if(!$db)
  {

    exit('データベースとの接続を閉じられませんでした。');
  }

  echo $res;

?>