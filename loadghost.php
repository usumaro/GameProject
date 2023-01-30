<?php

  require_once('mysql_connect.php');
  $db = connectDB();


  $sql = "SELECT * FROM bestposition_table order by id  ";
 
  $result = mysqli_query($db, $sql);

  while ($data = $result ->fetch_assoc())
  {
     $res = $data['xb'];
     $res .= "/".$data['zb'];
    
  }

  $db = mysqli_close($db);

  if(!$db)
  {

    exit('データベースとの接続を閉じられませんでした。');
  }

  echo $res;

?>