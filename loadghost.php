<?php

  require_once('mysql_connect.php');
  $db = connectDB();

  $sql = "SELECT * FROM bestposition_table ";
 
  $result = mysqli_query($db, $sql);

  $timedata = array();

  while ($data = $result ->fetch_assoc())
  {
     $timedata[] = array(
     'id' => $data['id'] ,
     'x' => $data['xb'] ,
     'y' => $data['yb'] ,
     'z' => $data['zb'] 
     );  
  }

  $db = mysqli_close($db);

  if(!$db)
  {

    exit('データベースとの接続を閉じられませんでした。');
  }

  echo json_encode($timedata);
 

?>