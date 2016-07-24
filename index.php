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
        if (isset($_SESSION['error'])){
            echo "<script type='text/javascript'>".'alert("'.$_SESSION['error'].'")'.";</script>";
            $_SESSION['error'] = null;
        }
        if ($_SERVER['REQUEST_METHOD'] == 'GET'
         && isset($_GET['userId'])){   
            // ECHO "<br>Get contact ",$_GET['contactId'];
            selectUser($_GET['userId']);             
        }
        
        if ($_SERVER['REQUEST_METHOD'] == 'POST'){
            newUser();
        }
        
        ?>
        
        <br>
         <form action ="index.php" method="POST">
         <div class ="grp">
             <?php
             inputField("Last Name :","text","lName");
             inputField("First Name :","text","fName");
             ?>             
         </div>
         <br><br>
         <div class ="grp">
            <?php
            inputField("Birth Date :","date","bDate");
            inputField("License Expiration Date :","date","licenseExpiration");
            ?>                                      
         </div>
         <br>  
         <div class ="grp">
         <?php userButtons(); ?>
         <br>
         </div>
         </form>
          
         <br><br>   
         <div class ="areaHdr">
              <span>Last Name</span>     
              <span>First Name</span> 
              <span>Birth Date</span> 
              <span>License Expiration</span>           
         </div>
            
            <?php displayUsers(); ?>
            
        <?php
        include './include/footer.html';
        ?>
                 
    </body>

</html>
