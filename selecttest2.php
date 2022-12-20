<?php

  require_once('mysql_connect.php');
  $db = connectDB();


  $sql = "SELECT time FROM time_table ORDER BY TIME LIMIT 1 " ;
 
  $result = mysqli_query($db, $sql);

  while ($data = $result ->fetch_assoc())
  {
     $res = $data['time'];
     
    
  }

  $db = mysqli_close($db);

  if(!$db)
  {

    exit('データベースとの接続を閉じられませんでした。');
  }

  echo $res;

?>