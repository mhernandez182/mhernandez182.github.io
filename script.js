menuElement = document.getElementById("menu");
console.log("got the menu element");
menuElement.innerHTML = "New Text";
    
function HandleMenuClick(){
    $("#menu").html("Even Newer Text");
}
