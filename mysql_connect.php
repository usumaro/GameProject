<?php

    function connectDB(){

         $db = new mysqli('localhost','root','','time');

         if($db ->connect_error){

        exit ($db -> connect_error);
         }

         return $db;
    }

    ?>