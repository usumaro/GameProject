<?php

  require_once('mysql_connect2.php');
  $db = connectDB();


  $posx = $_POST["posx"];
  $posy = $_POST["posy"];
  $posz = $_POST["posz"];

  $sql = " DELETE FROM `position_table` ; INSERT INTO position_table(x,y,z) VALUES ('".$posx."','".$posy."','".$posz."');" ;
 
  $result = mysqli_query($db, $sql);

  while ($data = $result ->fetch_assoc())
  {
     $res = $data['x'];
     $res .= ",".$data['y'];
     $res .= ",".$data['z'];
    
  }

  $db = mysqli_close($db);

  if(!$db)
  {

    exit('データベースとの接続を閉じられませんでした。');
  }

  echo $res;

?>