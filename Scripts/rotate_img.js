
var myImg= new Array()
  myImg[0]= "OkadaImages/1.gif";
  myImg[1]= "OkadaImages/2.gif";
  myImg[2]= "OkadaImages/3.jpg";
  myImg[3]= "OkadaImages/4.gif";
  myImg[4]= "OkadaImages/5.gif";
  myImg[5]= "OkadaImages/6.gif";
  myImg[6]= "OkadaImages/7.gif";
  myImg[7]= "OkadaImages/8.gif";
  myImg[7]= "OkadaImages/9.gif";



var pixPos = 0;
var timeDelay = 2; // change delay time in seconds

function startPix() 
{
document.getElementById('ImgSrc').src = myImg[pixPos];

delay = timeDelay*1000;
setInterval("next()", delay);
}

function prev(){

	if(pixPos<=0){
		pixPos=myImg.length-1;
	}
   document.getElementById('ImgSrc').src =  myImg[pixPos];
   
   pixPos--;
}

// Create link function to switch image forward
function next(){
	if(pixPos>=myImg.length){
		pixPos=0;
	}
	
   document.getElementById('ImgSrc').src = myImg[pixPos];
   
   pixPos++;
}

// Load function after page loads

