<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnimateHead2.aspx.cs" Inherits="AnimateHead2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> 
    <link rel="stylesheet" href="animate/css/iview.css"  type="text/css"/>
    <link rel="stylesheet" href="animate/css/skin 5/style.css" type="text/css" /> 
    <script src="animate/scripts/jquery-1.7.1.min.js"  type="text/javascript"></script> 
    <script type="text/javascript" src="animate/scripts/jquery.easing.js"></script>
    <script src="animate/scripts/iview.js"  type="text/javascript"></script> 
      <style media="screen" type="text/css">   
     .DivRadius
        {        	        	
        	position:relative;
        	background:#ceddc0;
        	-moz-border-radius: 2px;
        	border-radius: 5px;        	
        	padding: .2em .2em; 
        	color: rgba(0,0,0, .8);
        	/*text-shadow: 0 1px 0 green;*/
        	line-height: 1;
        	margin: 0px auto;
        	box-shadow: 1px 1px 15px rgba(10,150,0,0.7);           
        	         	        	     
        }     
        </style>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#iview').iView({
                strips: 20,
                blockCols: 20,
                blockRows: 3,
                pauseTime: 7000,
                pauseOnHover: true,
                directionNavHoverOpacity: 0,
                timer: "Bar",
                timerDiameter: 120,
                timerPadding: 3,
                timerStroke: 4,
                timerBarStroke: 0,
                timerColor: "#0F0",
                timerPosition: "bottom-right"
            });
        });
</script> 
</head>
<body>
    <form id="form1" runat="server">
      <div class="DivRadius" style="width:805px; text-align:center" >
    <div class="container" style="width:805px">
    <div id="iview" class="iview" style="margin:0; padding:0; ">
    <%=strImates%>
    </div> 
    </div> 
    </div>
    </form>
</body>
</html>
