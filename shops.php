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
         && isset($_GET['shopId'])){   
            // ECHO "<br>Get contact ",$_GET['contactId'];
            selectShop($_GET['shopId']);             
        }     
        if ($_SERVER['REQUEST_METHOD'] == 'POST'){
            newShop();
        }
        
        ?>
        
        <br>
         <form action ="shops.php" method="POST">
         <div class ="grp">
             <?php
             inputField("Shop :","text","shopName");
             inputField("Address :","text","shopAddress");
             ?>             
         </div>
         <br><br>
         <div class ="grp">
             <?php
             inputField("Phone :","text","shopPhoneNo");
             inputField("Website :","text","shopWebsite");
             inputField("Contact :","text","contactName");
             ?>             
         </div>
         <br><br>
         <div class ="grp">
         <?php shopButtons(); ?>
         <br>
         </div>
         </form>
          
         <br><br>   
         <div class ="areaHdr">
              <span>Shop</span>     
              <span>Address</span> 
              <span>Phone</span>
              <span>Website</span>
              <span>Contact</span>
         </div>
            
            <?php displayShops(); ?>
            
        <?php
        include './include/footer.html';
        ?>
                 
    </body>

</html>