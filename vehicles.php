<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml">
    <head> 
        <title>The Wanderer</title> 
        <meta http-equiv="content-type" content="text/html;charset=utf-8" /> 
        
   <link rel="stylesheet" src="//normalize-css.googlecode.com/svn/trunk/normalize.css" />
   <link rel="stylesheet" href="./css/main.css"

    </head>
    
    <body>
        <?php
        include './include/header.html';
        if ($_SERVER['REQUEST_METHOD'] == 'GET'
         && isset($_GET['vehicleId'])){   
            // ECHO "<br>Get contact ",$_GET['contactId'];
            selectVehicle($_GET['vehicleId']);             
        }     
        if ($_SERVER['REQUEST_METHOD'] == 'POST'){
            newVehicle();
        }
        
        ?>
        
        <br>
         <form action ="vehicles.php" method="POST">
         <div class ="grp">
             <?php
             inputField("Year :","text","year");
             inputField("Manufacturer :","text","manufacturer");
             inputField("Model :","text","model");
             ?>             
         </div>
         <br><br> 
         <div class ="grp">
         <?php vehicleButtons(); ?>
         <br>
         </div>
         </form>
          
         <br><br>   
         <div class ="areaHdr">
              <span>Year</span>     
              <span>Manufacturer</span> 
              <span>Model</span>        
         </div>
            
            <?php displayVehicles(); ?>
            
        <?php
        include './include/footer.html';
        ?>
                 
    </body>

</html>