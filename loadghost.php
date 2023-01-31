<?php

  require_once('mysql_connect.php');
  $db = connectDB();


  $sql = "SELECT xb FROM bestposition_table order by id  ";
 
  $result = mysqli_query($db, $sql);

$data = array();
$i = 1;
foreach($result as $value){

  echo $value;
}




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