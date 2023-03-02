<?php


require_once('mysql_connect.php');
  $db = connectDB();

  $sql = " SELECT * FROM time_table ORDER BY `time_table`.`time_date` DESC LIMIT 10" ;
 
  $result = mysqli_query($db, $sql);

  while ($data = $result ->fetch_assoc())
  {
     $res = $data['name'];
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