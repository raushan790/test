// JScript File
 
function getDParts(DateParts,VarParts)
{
    var varReturn = 0;
     var dArray = DateParts.split('/');
     if (dArray.length != 3) dArray = DateParts.split('-');
     if (dArray.length != 3) dArray=DateParts.split('.');
    if(VarParts=="date")
        varReturn=Number(dArray[0]);
    if(VarParts=="month")
        varReturn=Number(dArray[1]);
    if(VarParts=="year")
        varReturn=Number(dArray[2]);
    return varReturn;
}
function fChangeButtonColor(varForm,varColor)
{
    //if (GetBrowser()!='msie')
    //{
        
        /*var frmElements=document.getElementById(varForm).getElementsByTagName('input');
        
        for (var varForLoop=0;varForLoop<frmElements.length;varForLoop++)
        {
            if (frmElements[varForLoop].type.toLowerCase()=='submit' || frmElements[varForLoop].type.toLowerCase()=='button')
            {
                if (frmElements[varForLoop].disabled == true)
                    frmElements[varForLoop].style.color = '#999966';
                else
                    frmElements[varForLoop].style.color = 'Blue';// varColor;
            }
        }*/


    //}
}
function inStr(varString,varSearchString)
{
    if (varString.length==0) return false;
    for(var intForLoop=0;intForLoop<varString.length;intForLoop++)
    {
        if (varString.charAt(intForLoop)==varSearchString)
        {
            return true;
        }
    }
     return false;
}
 function fAllowNumeric(e)
    {
        var varKey;
        if(window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        var event=e || window.event;
        var target=event.target || event.srcElement;  
        if (inStr(target.value,'.') && (varKey==46)) return false;
        if (inStr(target.value,'-') && (varKey==45)) return false;
        if (varKey==45 || varKey==46 || (varKey>=48 && varKey<=57) || varKey==8 || varKey==127) 
            return true;
        else
            return false;
        
    }
function Restrict_MoneyWithPercentage(e)
{
     var varKey;
        if(window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        var event=e || window.event;
        var target=event.target || event.srcElement;  
        if (inStr(target.value,'.') && (varKey==46)) return false;
        if (inStr(target.value,'%') && (varKey==37)) return false;
        if (varKey==46 || varKey==37 || (varKey>=48 && varKey<=57) || varKey==8 || varKey==127) 
            return true;
        else
            return false;
        
}

function stripBlanks(fld) 
{
 var result = "";
 var c=0;
 for (i=0; i<fld.length; i++)
  {
   if (fld.charAt(i) != " " || c > 0) 
    {
     result += fld.charAt(i);
     if (fld.charAt(i) != " ") c = result.length;
    }
  }
 return result.substr(0,c);
}

var numb = '0123456789';
function isValid(parm,val)
{
 if (parm=="") return false;
 for (i=0;i<parm.length;i++)
  {
   if (val.indexOf(parm.charAt(i),0) == -1)
      return false;
  }
 return true;
}

function isNum(parm){return isValid(parm,numb);}


var mth = new Array(' ','january','february','march','april','may','june','july','august','september','october','november','december');
var day = new Array(31,28,31,30,31,30,31,31,30,31,30,31);

function validateDate(fld)
{
 var dd, mm, yy;
 var today = new Date;
 var t = new Date;
 fld = stripBlanks(fld);
 if (fld == '') return false;
 if(fld.length < 10) return false;
 var d1 = fld.split('/');
 if (d1.length != 3) d1 = fld.split('-');
 if (d1.length != 3) d1=fld.split('.');
 if (d1.length != 3) return false;
 dd = d1[0]; mm = d1[1]; yy = d1[2];
 if (!isNum(dd)) return false;
 if (!isNum(yy)) return false;
 if (!isNum(mm)) return false;
 if (dd.length>2) return false;
 if (mm.length>2) return false;
 if (yy.length>4) return false;
 dd = parseFloat(dd);
 mm = parseFloat(mm);
 yy = parseFloat(yy);
 if (yy < 100) yy += 2000;
 if (yy < 1582 || yy > 2099) return false;
 if (mm == 2 && (yy%400 == 0 || (yy%4 == 0 && yy%100 != 0))) day[mm-1]++;
 if (mm < 1 || mm > 12) return false;
 if (dd < 1 || dd > day[mm-1]) return false;
 t.setDate(dd); t.setMonth(mm-1); t.setFullYear(yy);
 //if (t > today) return false;
 return true;
}

function Check_For_Enter(e)
    {
     var key;
     if(window.event)
        key=window.event.keyCode;
     else
        key=e.which;   
     if(key==13)
      return false;
     else
      return true; 
    }


//new
function Allow_Numeric(e)
{
    var whichCode = (window.event) ? window.event.keyCode : e.which;
   //alert(Code);
    if((whichCode>=48 && whichCode<=57) || whichCode==46 || whichCode==8 || whichCode==0)
        return true;
    else
        return false;
}


function Allow_MonthNumeric(e)
{
    var whichCode = (window.event) ? window.event.keyCode : e.which;
   //alert(Code);
    if((whichCode>=48 && whichCode<=57) || whichCode==127 || whichCode==8 || whichCode==0)
        return true;
    else
        return false;
}



function Allow_Character(e)
{
   var whichCode = (window.event) ? window.event.keyCode : e.which;
    //alert(whichCode);
    if((whichCode >=97 && whichCode<=122) || (whichCode>=65 && whichCode<=90) || whichCode==32 || whichCode==46|| whichCode==8 || whichCode==127 || whichCode==0)
        return true;
    else
        return false;    
}

function Allow_Date(e)
    {
       var whichCode = (window.event) ? window.event.keyCode : e.which;
        //alert(Code);
        if((whichCode>=45 && whichCode<=57) || whichCode==127 || whichCode==8 || whichCode==0)
            return true;
        else
            return false;
    }
    
function Allow_PhoneNo(e)
    {
       var whichCode = (window.event) ? window.event.keyCode : e.which;
        if(whichCode==32 || (whichCode>=43 && whichCode<=57) || whichCode==127 || whichCode==8 || whichCode==0)
            return true;
        else
            return false;            
    }    
    

function validateMoney(Amount)
{
 var varDecimalCount=0;
 for (i=0; i<Amount.length; i++)
   if (Amount.charAt(i) == '.')
     varDecimalCount=varDecimalCount+1;
 if(varDecimalCount>1) return false;
 else if(varDecimalCount==1)
 {
  var strArray=Amount.split('.');
  if(strArray[1]=='')
   return false;
 }
 return true;
}

function validateEmail(Email)
{
    var checkmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if(!checkmail.test(Email))
        return false;
    else
        return true;
//    var varMailID=Email.split(',');
//    for(var i=0;i<varMailID.length;i++)
//    {
//        var varAtArray=varMailID[i].split('@');
//        if(varAtArray.length!=2) return false;
//        else
//         {
//          var varDotArray=varAtArray[1].split('.');
//          if(varDotArray.length==0) return false;
//          if(varDotArray.length>3) return false;
//         }
//    }
}

//function Restrict_FeeNo(e)
//{
// var varKey;
//     if(window.event)
//        varKey=window.event.keyCode;
//     else
//        varKey=e.which;   
//     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==95 || varKey==46 || varKey>=38 && varKey<=43 || varKey>=45 && varKey<=57 || varKey==8 || varKey==127 || varKey==32 || varKey==0)
//      return true;
//     else
//      return false; 
//}
function Restrict_FeeNo(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     //if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==95 || varKey==46 || varKey>=38 && varKey<=43 || varKey>=45 && varKey<=57 || varKey==8 || varKey==127 || varKey==32 || varKey==0)
     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey>=48 && varKey<=57 || varKey==8  || varKey==95 || varKey==45 || varKey==32 || varKey==9 || varKey==13) // || varKey>=38 && varKey<=43  || varKey==127 || varKey==0)s
      return true;
     else
      return false; 
}

function Restrict_Name(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==95 || varKey==46 || varKey>=38 && varKey<=43 || varKey>=45 && varKey<=57 || varKey==127 || varKey==8 || varKey==32|| varKey==0)
      return true;
     else
      return false; 
}
function Restrict_Date(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=45 && varKey<=57 || varKey==127 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function Restrict_Priority(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=48 && varKey<=57 || varKey==8 || varKey==127 || varKey==0)
      return true;
     else
      return false; 
}

function Restrict_Phone(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=44 && varKey<=57 || varKey==32 || varKey==127 || varKey>=40 && varKey<=41 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function Restrict_Address(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=32 && varKey<=93 || varKey>=97 && varKey<=122 || varKey==127 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function Restrict_Pincode(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=48 && varKey<=57 || varKey==127 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function Restrict_Money(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=48 && varKey<=57 || varKey==127 || varKey==46 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function Restrict_Email(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=48 && varKey<=57 || varKey==46 || varKey>=64 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==127 || varKey==95 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function Allow_AlphaNumeric(e)
{
    var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=48 && varKey<=57 || varKey==46 || varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==127 || varKey==32 || varKey==38 || varKey==45 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}

function Restrict_SkillName(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey == 43 || varKey == 35 ||varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==32 || varKey==46 || varKey>=38 && varKey<=41 ||varKey>=48 && varKey<=57 || varKey==127 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}


function Restrict_NameNo(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==95 || varKey==46 || varKey>=38 && varKey<=43 || varKey>=45 && varKey<=57 || varKey==127 || varKey==8 || varKey==32 || varKey==0)
      return true;
     else
      return false; 
}



function AllowTime(e) // Santhosh
{

var whichCode = (window.event) ? window.event.keyCode : e.which;
   
 if((whichCode>=48 && whichCode<=57) || whichCode == 58 || whichCode == 65 || whichCode == 77 || whichCode == 80 || whichCode == 32 || whichCode ==127 || whichCode==8 || whichCode==0)
        return true;
    else
        return false;


}

function round_decimals(original_number, decimals) {
    var result1 = original_number * Math.pow(10, decimals)
    var result2 = Math.round(result1)
    var result3 = result2 / Math.pow(10, decimals)
    return pad_with_zeros(result3, decimals)
}

function pad_with_zeros(rounded_value, decimal_places) {

    // Convert the number to a string
    var value_string = rounded_value.toString()
    
    // Locate the decimal point
    var decimal_location = value_string.indexOf(".")

    // Is there a decimal point?
    if (decimal_location == -1) {
        
        // If no, then all decimal places will be padded with 0s
        decimal_part_length = 0
        
        // If decimal_places is greater than zero, tack on a decimal point
        value_string += decimal_places > 0 ? "." : ""
    }
    else {

        // If yes, then only the extra decimal places will be padded with 0s
        decimal_part_length = value_string.length - decimal_location - 1
    }
    
    // Calculate the number of decimal places that need to be padded with 0s
    var pad_total = decimal_places - decimal_part_length
    
    if (pad_total > 0) {
        
        // Pad the string with 0s
        for (var counter = 1; counter <= pad_total; counter++) 
            value_string += "0"
        }
    return value_string
}

function GetBrowser()
{
    var browserName = ""; 

    var ua = navigator.userAgent.toLowerCase(); 
    if ( ua.indexOf( "opera" ) != -1 ) 
    { 
        browserName = "opera"; 
    } 
    else if ( ua.indexOf( "msie" ) != -1 ) 
    { 
        browserName = "msie"; 
    } 
    else if ( ua.indexOf( "safari" ) != -1 ) 
    { 
        browserName = "safari"; 
    }
    else if ( ua.indexOf( "mozilla" ) != -1 ) 
    { 
        if ( ua.indexOf( "firefox" ) != -1 ) 
        { 
            browserName = "firefox"; 
        } 
        else 
        { 
            browserName = "mozilla"; 
        } 
    } 

    return browserName; 
} 

function Restrict_ReceiptNo(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==32 || varKey==46 || varKey>=38 && varKey<=41 || varKey>=48 && varKey<=57 || varKey==8 || varKey== 45 || varKey==47)
      return true;
     else
      return false; 
}



function Restrict_Mark(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;
     var event=e || window.event;
     var target=event.target || event.srcElement;
     var strMark=new Array();      
     if(varKey>=48 && varKey<=57 || varKey==46 || varKey==8)
     {
      if(varKey==46)
      {
        strMark=document.getElementById(target.id).value.split('.');
        if(strMark[1]!=null)
            return false;
      }
      else if(varKey>=48 && varKey<=57)
      {
        strMark=document.getElementById(target.id).value.split('.');
        if(strMark[1]!=null)
        if(strMark[1].length>1)
            return false;
      }
      return true;
     } 
     else
      return false; 
}


function Restrict_EnrollmentNo(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey==95 || varKey==46 || varKey>=38 && varKey<=43 || varKey>=45 && varKey<=57 || varKey==127 || varKey==8 || varKey==0)
      return true;
     else if(varKey==13)
     {
     
     return true;
     
     
     }
     else
      return false; 
}

//function Restrict_Multiline(e,intMax)
//{
//    
//     var varKey;
//     var event=e || window.event;
//     var target=event.target || event.srcElement     
//     if(window.event)
//        varKey=window.event.keyCode;
//     else
//        varKey=e.which;   
//      if(varKey>=32 && varKey<=93 || varKey>=97 && varKey<=122 || varKey==127 || varKey==8 || varKey==0)
//     {       
//        if(document.getElementById(target.id).value.length<intMax)
//             return true;
//        else
//            return false;
//     }
//     else
//      return false;         
//}


function Restrict_Multiline(e,intMax)
{
   // alert('a');
     var varKey;
     var event=e || window.event;
     var target=event.target || event.srcElement     
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;
     
     if(varKey==8 || varKey==0)
        return true;
        
     if(varKey>=32 && varKey<=93 || varKey>=97 && varKey<=122 || varKey==127 )
     {       
        if(document.getElementById(target.id).value.length<intMax)
             return true;
        else
            return false;
     }
     else
      return false;         
}

function FreezeGridViewHeader(gridID,Panel) 
    {
        /// <summary>
        ///   Used to create a fixed GridView header and allow scrolling
        
        fColumnResize(gridID);
        
        if(!(document.getElementById(Panel).style.height==null || document.getElementById(Panel).style.height==''))
        {
            //alert(Panel+' in');
            var wrapperDivCssClass="WrapperDiv";
            var grid = document.getElementById(gridID);
            if (grid != null && grid != 'undefined')
            {
                grid.style.visibility = 'hidden';
                var div = null;
                var div1=null;
                if (grid.parentNode != 'undefined' && grid.parentNode !=null) 
                {
    //                //Find wrapper div output by GridView
                    div1 = grid.parentNode;
                    div=document.getElementById(Panel);
                    if (div.tagName == "DIV")
                    {
                        div.className = wrapperDivCssClass;  
                        div.style.overflow = "auto";
                        //div.style.zIndex=-1;                   
                    }
                }                
                
                var tags = grid.getElementsByTagName('TBODY');
                if (tags != 'undefined' && tags !=null)
                {
                    var tbody = tags[0];
                    var trs = tbody.getElementsByTagName('TR');
                    var headerHeight = 8;
                    if (trs != 'undefined' && trs!=null) 
                    {
                        headerHeight += trs[0].offsetHeight;
                        var headTR = tbody.removeChild(trs[0]);
                        var head = document.createElement('THEAD');
                        head.appendChild(headTR);
                        
                        grid.insertBefore(head, grid.firstChild);
                    }
                    //Needed for Firefox
                   
                    tbody.style.height = (div.offsetHeight -  headerHeight) + 'px';
                    
                    tbody.style.overflowX = "hidden";
                    tbody.overflow = 'auto';
                    tbody.overflowX = 'hidden';
                    //tbody.class='MyGridViewRow';
                }
                grid.style.visibility = 'visible';
                
            }
        }
       
}
            
function CompareDate(Date1,Date2)
{
//returns 1 when Date1 is lesser
//returns 2 when Date2 is lesser
//returns 0 when Both dates are equal
 var dd1, mm1, yy1, dd2, mm2, yy2;
 Date1 = stripBlanks(Date1);
 Date2 = stripBlanks(Date2);
 
 var d1 = Date1.split('/');
 if (d1.length != 3) d1 = Date1.split('-');
 if (d1.length != 3) d1=Date1.split('.');
 var d2 = Date2.split('/');
 if (d2.length != 3) d2 = Date2.split('-');
 if (d2.length != 3) d2=Date2.split('.');

 dd1 = parseFloat(d1[0]);
 mm1 = parseFloat(d1[1]);
 yy1 = parseFloat(d1[2]);
 dd2 = parseFloat(d2[0]);
 mm2 = parseFloat(d2[1]);
 yy2 = parseFloat(d2[2]);
 
 if(yy1<yy2) return 1;
 if(yy1>yy2) return 2;
 if(mm1<mm2) return 1;
 if(mm1>mm2) return 2;
 if(dd1<dd2) return 1;
 if(dd1>dd2) return 2;
 return 0;
}

function checkEvent(e) 
   {
   //var targ;
   var event=e || window.event;
    var targ=event.target || event.srcElement
//        if (!e)
//             e = window.event;
//        if (e.target)
//            targ = e.target;
//        else if(e.srcElement)
//             targ = e.srcElement;
        if(targ.options.selectedIndex!=-1)
            showHideToolTip(targ, event, event.type)
   }
   
function showHideToolTip (theDropDown, e, eType)
    {
        var toolTipObj = new Object();
        var iframeObj = new Object();
        
        //var event=e || window.event;
        toolTipObj = document.getElementById("tooltip");
        iframeObj=document.getElementById("iframeTop");
        //toolTipObj.style.zIndex=99999;
        toolTipObj.innerHTML = theDropDown.options[theDropDown.selectedIndex].text;
        if(eType == "mouseout")
        {
            toolTipObj.style.display = "none";
            iframeObj.style.display = "none";
        }
        else
        {
            if(stripBlanks(theDropDown.options[theDropDown.selectedIndex].text)!="")
            {
                var xPosition=getPosition(e).x+15;
                var yPosition=getPosition(e).y+10;
                toolTipObj.style.display = "inline";
                
                toolTipObj.style.top = yPosition;
                toolTipObj.style.left = xPosition;
                iframeObj.style.display = "inline";
                
                iframeObj.style.top = yPosition;
                iframeObj.style.left = xPosition;
                
                iframeObj.style.width=toolTipObj.offsetWidth;
                iframeObj.style.height=toolTipObj.offsetHeight;
                
            }
        }
     }
     
function DisableLoadMsg()
{
    try{   
        var divLoadingMessage =  document.getElementById("divLoadingMsg")   
        if (divLoadingMessage != null && typeof(divLoadingMessage) != 'undefined')   
        {   
        divLoadingMessage.style.display="none";   
        divLoadingMessage.parentNode.removeChild(divLoadingMessage);   
        }   
       }
    catch(e){}
}

function getPosition(e) 
{
    e = e || window.event;
    var cursor = {x:0, y:0};
    if (e.pageX || e.pageY) 
    {
        cursor.x = e.pageX;
        cursor.y = e.pageY;
    } 
    else 
    {
        var de = document.documentElement;
        var b = document.body;
        cursor.x = e.clientX + 
            (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
        cursor.y = e.clientY + 
            (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
    }
    return cursor;
}


//  true when a header is currently being resized
var _isResizing;
//  a reference to the header column that is being resized
var _element;
//  an array of all of the tables header cells
var _ths;

function fColumnResize(args)
{
    //  get all of the th elements from the gridview
    if($get(args)!=null)
    {
    _ths =$get(args).getElementsByTagName('TH');
    
    //  if the grid has at least one th element
        if(_ths.length > 1)
        {
        
            for(i = 0; i < _ths.length; i++)
            {
                //  determine the widths
                _ths[i].style.width = Sys.UI.DomElement.getBounds(_ths[i]).width + 'px';
            
                //  attach the mousemove and mousedown events
                if(i < _ths.length - 1)
                {
                    $addHandler(_ths[i], 'mousemove', _onMouseMove);
                    $addHandler(_ths[i], 'mousedown', _onMouseDown);
                }
            }

            //  add a global mouseup handler            
            $addHandler(document, 'mouseup', _onMouseUp);
            //  add a global selectstart handler
            $addHandler(document, 'selectstart', _onSelectStart);
        } 
     }     
}

function _onMouseMove(args)
{    
    if(_isResizing)
    {
        
        //  determine the new width of the header
        var bounds = Sys.UI.DomElement.getBounds(_element); 
        var width = args.clientX - bounds.x;
        
        //  we set the minimum width to 1 px, so make
        //  sure it is at least this before bothering to
        //  calculate the new width
        if(width > 1)
            {
        
            //  get the next th element so we can adjust its size as well
            var nextColumn = _element.nextSibling;
            var nextColumnWidth;
            
            if(width < ConvertToNum(_element.style.width))
            {
                //  make the next column bigger
                nextColumnWidth = ConvertToNum(nextColumn.style.width) + ConvertToNum(_element.style.width) - width;
            }
            else if(width > ConvertToNum(_element.style.width))
            {
                //  make the next column smaller
                nextColumnWidth = ConvertToNum(nextColumn.style.width) - (width - ConvertToNum(_element.style.width));
            }   
            
            //  we also don't want to shrink this width to less than one pixel,
            //  so make sure of this before resizing ...
            if(nextColumnWidth > 1)
            {
                _element.style.width = width + 'px';
                nextColumn.style.width = nextColumnWidth + 'px';
            }
        }
    }   
    else
        {
        //  get the bounds of the element.  If the mouse cursor is within
        //  2px of the border, display the e-cursor -> cursor:e-resize
        var bounds = Sys.UI.DomElement.getBounds(args.target);
        if(Math.abs((bounds.x + bounds.width) - (args.clientX)) <= 2) {
            args.target.style.cursor = 'e-resize';
        }  
        else
        {
            args.target.style.cursor = '';
        }          
    }         
}

function _onMouseDown(args)
{
    //  if the user clicks the mouse button while
    //  the cursor is in the resize position, it means
    //  they want to start resizing.  Set _isResizing to true
    //  and grab the th element that is being resized
    if(args.target.style.cursor == 'e-resize') 
    {
        _isResizing = true;
        _element = args.target;               
    }                    
} 

function _onMouseUp(args)
{
    //  the user let go of the mouse - so
    //  they are done resizing the header.  Reset
    //  everything back
    if(_isResizing)
    {
        
        //  set back to default values
        _isResizing = false;
        _element = null;
        
        //  make sure the cursor is set back to default
        for(i = 0; i < _ths.length; i++)
        {   
            _ths[i].style.cursor = '';
        }
    }
}

function _onSelectStart(args)
{
    // Don't allow selection during drag
    if(_isResizing)
    {
        args.preventDefault();
        return false;
    }
}
    
function ConvertToNum(parm)
{
 var retParm="";
 for (i=0;i<parm.length;i++)
  {
   if (numb.indexOf(parm.charAt(i),0) != -1)
      retParm=retParm+parm.charAt(i);
  }
 if (retParm=="") return 0; 
 return Number(retParm);
}

function addLoadEvent(func) 
{
    var oldonload = window.onload;
    if (typeof window.onload != 'function')
    {
        window.onload = func;
    } 
    else 
    {
        window.onload = function() 
        {
            if (oldonload) 
            {
                oldonload();
            }
            func();
        }
    }
    document.onkeydown=pRestrictBackSpace;
   // document.oncontextmenu=function(){return false;};
 }  

//**************************Httprequest Start
        
var XmlHttp;
//Creating and setting the instance of appropriate XMLHTTP Request object to a “XmlHttp” variable  
function CreateXmlHttp()
{
    //Creating object of XMLHTTP in IE
    try
    {
        XmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch(e)
    {
        try
        {
	        XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        } 
        catch(oc)
        {
	        XmlHttp = null;
        }
    }
    //Creating object of XMLHTTP in Mozilla and Safari 
    if(!XmlHttp && typeof XMLHttpRequest != "undefined") 
    {
        XmlHttp = new XMLHttpRequest();
    }
}  


var varSearchString='';
var intGRow=0;
var txtSearch=document.createElement('INPUT',true);
function searchName(e,GridName,intRow)
{
    if (intGRow!=0) 
    {
        varDiff=document.getElementById(GridName).rows[0].cells.length-document.getElementById(GridName).rows[intGRow].cells.length;
        document.getElementById(GridName).rows[intGRow].cells[intRow-varDiff].innerHTML=document.getElementById(GridName).rows[intGRow].cells[intRow-varDiff].innerText;
    }
    var varKey;   
    if(window.event)
        varKey=window.event.keyCode;
    else
        varKey=e.which;
    txtSearch.id='txtSearch';
    txtSearch.className="MyDynamicText";
    txtSearch.readOnly=true;
    txtSearch.style.display='none';
    varSearchString=varSearchString + String.fromCharCode(varKey);
    if (varSearchString!='')
    {
        for (var intForLoop=1;intForLoop<document.getElementById(GridName).rows.length;intForLoop++)
        {
            varDiff=document.getElementById(GridName).rows[0].cells.length-document.getElementById(GridName).rows[intForLoop].cells.length;
            if ((Number(intRow)-Number(varDiff))>0)
            {
                if ((document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText).substring(0,varSearchString.length).toLowerCase()==varSearchString.toLowerCase() && intForLoop>=intGRow)
                {
                    txtSearch.value=document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText;
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerHTML="<span style=\"background-color: #0066FF\"><font color=\"#FFFFFF\">"+txtSearch.value.substring(0,varSearchString.length)+"</font></span>"+txtSearch.value.substring(varSearchString.length,txtSearch.length)+"";
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].appendChild(txtSearch);
                    txtSearch.style.display='block';
                    txtSearch.focus();
                    txtSearch.style.display='none';
                    intGRow=intForLoop;
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].removeChild(txtSearch);
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].firstChild.nodeValue=txtSearch.value;
                    return false;
                }
            }
        }
        for (var intForLoop=1;intForLoop<document.getElementById(GridName).rows.length;intForLoop++)
        {
            varDiff=document.getElementById(GridName).rows[0].cells.length-document.getElementById(GridName).rows[intForLoop].cells.length;
            if ((Number(intRow)-Number(varDiff))>0)
            {
                if ((document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText).substring(0,varSearchString.length).toLowerCase()==varSearchString.toLowerCase())
                {
                    txtSearch.value=document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText;
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerHTML="<span style=\"background-color: #0066FF\"><font color=\"#FFFFFF\">"+txtSearch.value.substring(0,varSearchString.length)+"</font></span>"+txtSearch.value.substring(varSearchString.length,txtSearch.length)+"";
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].appendChild(txtSearch);
                    txtSearch.style.display='block';
                    txtSearch.focus();
                    txtSearch.style.display='none';
                    intGRow=intForLoop;
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].removeChild(txtSearch);
                    document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].firstChild.nodeValue=txtSearch.value;
                    return false;
                }
            }
        }
    }
    varSearchString=String.fromCharCode(varKey);
    for (var intForLoop=1;intForLoop<document.getElementById(GridName).rows.length;intForLoop++)
    {
        varDiff=document.getElementById(GridName).rows[0].cells.length-document.getElementById(GridName).rows[intForLoop].cells.length;
        if ((Number(intRow)-Number(varDiff))>0)
        {
            if ((document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText).substring(0,varSearchString.length).toLowerCase()==varSearchString.toLowerCase() && intForLoop>intGRow)
            {
                txtSearch.value=document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText;
                 document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerHTML="<span style=\"background-color: #0066FF\"><font color=\"#FFFFFF\">"+txtSearch.value.substring(0,varSearchString.length)+"</font></span>"+txtSearch.value.substring(varSearchString.length,txtSearch.length)+"";
                document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].appendChild(txtSearch);
                txtSearch.style.display='block';
                txtSearch.focus();
                txtSearch.style.display='none';
                intGRow=intForLoop;
                document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].removeChild(txtSearch);
                document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].firstChild.nodeValue=txtSearch.value;
                return false;
            }
        }
    }
    for (var intForLoop=1;intForLoop<document.getElementById(GridName).rows.length;intForLoop++)
    {
        varDiff=document.getElementById(GridName).rows[0].cells.length-document.getElementById(GridName).rows[intForLoop].cells.length;
        if ((Number(intRow)-Number(varDiff))>0)
        {
            if ((document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText).substring(0,varSearchString.length).toLowerCase()==varSearchString.toLowerCase())
            {
                txtSearch.value=document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerText;
                 document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].innerHTML="<span style=\"background-color: #0066FF\"><font color=\"#FFFFFF\">"+txtSearch.value.substring(0,varSearchString.length)+"</font></span>"+txtSearch.value.substring(varSearchString.length,txtSearch.length)+"";
                document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].appendChild(txtSearch);
                txtSearch.style.display='block';
                txtSearch.focus();
                txtSearch.style.display='none';
                intGRow=intForLoop;
                document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].removeChild(txtSearch);
                document.getElementById(GridName).rows[intForLoop].cells[intRow-varDiff].firstChild.nodeValue=txtSearch.value;
                return false;
            }
        }
    }
    varSearchString='';
    if (intGRow>0) 
    {
        document.getElementById(GridName).rows[intGRow].cells[intRow-varDiff].appendChild(txtSearch);
        txtSearch.style.display='block';
        txtSearch.focus();
        intGRow=0;
        txtSearch.style.display='none'; 
    }
    return false;
}


function f_BindDDL(ResponseData,ddl,strVal,strText)
{
    
     var ddlBind=document.getElementById(ddl);                      
     ddlBind.length = 0;                   
    var ValueNodes = ResponseData.getElementsByTagName(strVal);
    var TextNodes = ResponseData.getElementsByTagName(strText);
    var optionItem;
    var txt;
    var val;
    for(var i = 0;i<ValueNodes.length;i++)
    {
     txt =  GetInnerText(TextNodes[i]);
     val = GetInnerText(ValueNodes[i]);
     optionItem = new Option( txt, val,  false, false);
                         
     ddlBind.options.add(optionItem);
     }
}

function GetInnerText (node)
{
	 return (node.textContent || node.innerText || node.text || node.innerHTML) ;
}

var SearchString='';
function AutoCompleteDDL(ddl,e)
{
    var SlIndx=document.getElementById(ddl).selectedIndex;
    if (SlIndx>-1) document.getElementById(ddl).options.selected=false;
    var varKey;
    if (window.event)
        varKey=window.event.keyCode;
    else
        varKey=e.which;
    if (varKey==13 && SlIndx>-1)
    {
       document.getElementById(ddl).value=document.getElementById(ddl).options[document.getElementById(ddl).selectedIndex].value; 
       varKey='';
       return true;
    }
    else if (varKey==13)
    {
        varKey='';
        return true;
    }
    else if (varKey==40)
    {
        varKey='';
        return true;
    }
    var target=event.target || event.srcElement; 
    SearchString=SearchString+String.fromCharCode(varKey);
    for (var varForLoop=(SlIndx==-1 ? 0:SlIndx) ;varForLoop<document.getElementById(ddl).options.length;varForLoop++)
    {
        if (document.getElementById(ddl).options[varForLoop].text.substring(0,SearchString.length).toLowerCase()==SearchString.toLowerCase())
        {
            if (SlIndx>-1) document.getElementById(ddl).options[SlIndx].selected=false;
            document.getElementById(ddl).options[varForLoop].selected=true;
            return false;
        }
    }
    if (SlIndx>-1)   
    { 
        for (var varForLoop=0 ;varForLoop<document.getElementById(ddl).options.length;varForLoop++)
        {
            if (document.getElementById(ddl).options[varForLoop].text.substring(0,SearchString.length).toLowerCase()==SearchString.toLowerCase())
            {
                document.getElementById(ddl).options[SlIndx].selected=false;
                document.getElementById(ddl).options[varForLoop].selected=true;
                return false;
            }
        }
    }
    SearchString=String.fromCharCode(varKey);
     for (var varForLoop=(SlIndx==-1 ? 0:SlIndx+1) ;varForLoop<document.getElementById(ddl).options.length;varForLoop++)
    {
        if (document.getElementById(ddl).options[varForLoop].text.substring(0,SearchString.length).toLowerCase()==SearchString.toLowerCase())
        {
            if (SlIndx>-1) document.getElementById(ddl).options[SlIndx].selected=false;
            document.getElementById(ddl).options[varForLoop].selected=true;
            return false;
        }
    }
    if (SlIndx>-1)   
    { 
        for (var varForLoop=0 ;varForLoop<document.getElementById(ddl).options.length;varForLoop++)
        {
            if (document.getElementById(ddl).options[varForLoop].text.substring(0,SearchString.length).toLowerCase()==SearchString.toLowerCase())
            {
                document.getElementById(ddl).options[SlIndx].selected=false;
                document.getElementById(ddl).options[varForLoop].selected=true;
                return false;
            }
        }
    }
    SearchString='';
    return false;
}
 function pLockControls(Parent)
    {
        var varElements=document.getElementById(Parent).getElementsByTagName('INPUT');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='textarea')  
                varElements[varForLoop].readOnly=true;
            else if (varElements[varForLoop].type.toLowerCase()=='radio' || varElements[varForLoop].type.toLowerCase()=='checkbox')
                varElements[varForLoop].disabled=true;
        }
        var varElements=document.getElementById(Parent).getElementsByTagName('SELECT');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
          if (varElements[varForLoop].id!='lstCDisplay') varElements[varForLoop].disabled=true;
        }
        var varElements=document.getElementById(Parent).getElementsByTagName('textarea');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            varElements[varForLoop].readOnly=true;
        }
    }
    function pUnLockControls(Parent)
    {
        var varElements=document.getElementById(Parent).getElementsByTagName('INPUT');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='textarea')  
                varElements[varForLoop].readOnly=false;
            else if (varElements[varForLoop].type.toLowerCase()=='radio' || varElements[varForLoop].type.toLowerCase()=='checkbox')
                varElements[varForLoop].disabled=false;
        }
        var varElements=document.getElementById(Parent).getElementsByTagName('SELECT');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            varElements[varForLoop].disabled=false;
        }
        var varElements=document.getElementById(Parent).getElementsByTagName('textarea');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            varElements[varForLoop].readOnly=false;
        }
    }
    function pClearFields(Parent)
    {
        var varElements=document.getElementById(Parent).getElementsByTagName('INPUT');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='textarea') varElements[varForLoop].value='';
            else if (varElements[varForLoop].type.toLowerCase()=='checkbox') varElements[varForLoop].checked=false;
        }
        var varElements=document.getElementById(Parent).getElementsByTagName('SELECT');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            varElements[varForLoop].selectedIndex=-1;
        }
        var varElements=document.getElementById(Parent).getElementsByTagName('textarea');
        for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
        {
            varElements[varForLoop].value='';
        }
    }
function ddlClear(ddl)
 {
    if(document.getElementById(ddl)!=null)
        document.getElementById(ddl).options.length=0;
 }
function RemoveEnter(e)
{
     var varKey;
    if (window.event)
        varKey=window.event.keyCode;
    else
        varKey=e.which;
    if (varKey==13)
        return false;
    else 
        return true;
}
/* Daison's scripts */
String.prototype.inStr=function (varString,varSearchString)
{
    if (varString.length==0) return false;
    for(var intForLoop=0;intForLoop<varString.length;intForLoop++)
    {
        if (varString.charAt(intForLoop)==varSearchString)
        {
            return true;
        }
    }
     return false;
}
 String.prototype.dateValue=function(varFormat) {
    try
    {
        var varSep='';
        var dtCheck=new Array('','','');
        var mth = new Array('january','february','march','april','may','june','july','august','september','october','november','december');
        if (varFormat==null) varFormat="dd/MM/yyyy";
        if (this.split('/').length==3)  varSep='/';
        if (this.split('-').length==3)  varSep='-';
        if (this.split('.').length==3)  varSep='.';
        if (this.split(' ').length==3)  varSep=' ';
        var dtFormat=varFormat.split(varSep);
        var dtTempDate=new Date();
        for (i=0;i<dtFormat.length;i++)
        {
            if(dtFormat[i].substr(0,1).toLowerCase()=='d')
            {
               dtTempDate.setDate(this.split(varSep)[i]);
               dtCheck[0]=this.split(varSep)[i];
            }
            else if(dtFormat[i].substr(0,1).toLowerCase()=='m')
            {
                if (Number(this.split(varSep)[i])>0)
                {
                    dtTempDate.setMonth(Number(this.split(varSep)[i])-1)
                    dtCheck[1]=Number(this.split(varSep)[i]);
                }
                else
                {
                    for (j=0;j<mth.length;j++)
                    {
                        if (mth[j].substr(0,dtFormat[i].length).toLowerCase()==this.split(varSep)[i].substr(0,dtFormat[i].length).toLowerCase())
                        {
                            dtTempDate.setMonth(j);
                            dtCheck[1]=j+1;
                            break;
                        }
                    }
                }
            }
            else if(dtFormat[i].substr(0,1).toLowerCase()=='y')
            {
                dtCheck[2]=this.split(varSep)[i];
                if (String(dtCheck[2]).length<4)
                { 
                    if (Number(dtCheck[2])<20)
                        dtCheck[2]=2000+Number(dtCheck[2]);
                    else
                        dtCheck[2]=1900+Number(dtCheck[2]);
                }
                dtTempDate.setFullYear(dtCheck[2]);
            }
        }
        if (String(dtCheck[0]).length<2) dtCheck[0]='0'+String(dtCheck[0]);
        if (String(dtCheck[1]).length<2) dtCheck[1]='0'+String(dtCheck[1]);
        if (validateDate(dtCheck.join('/'))==false) 
            return null;
        else
            return dtTempDate;
    }
    catch(ex)
    {
        return false;
    }
} 

String.prototype.trim = function() { return this.replace(/^\s+|\s+$/g, ""); };  
function pRestrictBackSpace(e)
{
    var varKey;
    if(window.event)
        varKey=window.event.keyCode;
    else
        varKey=e.which;   
    if (varKey!=8) return true;
    var event=e || window.event;
    var target=event.target || event.srcElement; 
    if (target.type=='text' || target.type=='textarea' || target.type=='password')
    {
        if (target.readOnly==false)
            return true;
    }
    return false;
}
//Added By Ushas
function Restrict_NameArabic(e)
{  
   var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;  
        if (varKey ==95  || varKey ==38 || varKey ==59 ||  varKey>=40 && varKey<=43 ||  varKey==60 ||  varKey==45  || varKey>=62 && varKey<=63 || varKey>=65 && varKey<=93 || varKey>=96 || varKey<=32 || varKey>=48 && varKey<=57||varKey==36)         
       return true;
     else
      return false; 
}
//Added by Tinu
function Restrict_MultilineArabic(e,intMax)
{  
     var varKey;
     var event=e || window.event;
     var target=event.target || event.srcElement     
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
      if (varKey ==95  || varKey ==38 || varKey ==59 ||  varKey>=40 && varKey<=43 ||  varKey==60 ||  varKey==45  || varKey>=62 && varKey<=63 || varKey>=65 && varKey<=93 || varKey>=96 || varKey<=32 || varKey>=48 && varKey<=57||varKey==36)         
     {       
        if(document.getElementById(target.id).value.length<intMax)
             return true;
        else
            return false;
     }
     else
      return false;         
}
function Allow_Integer(e)
{
    var whichCode = (window.event) ? window.event.keyCode : e.which;
    if((whichCode>=48 && whichCode<=57)   || whichCode==8 || whichCode==0)
        return true;
    else
        return false;
}

function RestrictEnterDate(e)
    {   var varKey;
        var event=e || window.event;
        if (window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        var target=event.target || event.srcElement;        
        
            if ((target.value.length==2 || target.value.length==5)) target.value=target.value+'/'; 
            if (varKey==47 || varKey==45 || varKey==46 ) return false;
            return Restrict_Date(e);      
      
    }       
    
    
    
    
 function pforAllowNumeric(e)
    {
        var varKey;
        if(window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        var event=e || window.event;
        var target=event.target || event.srcElement;  
        if (inStr(target.value,'.') && (varKey==46)) return false;      
        if (varKey==46 || (varKey>=48 && varKey<=57) || varKey==8 || varKey==127) 
            return true;
        else
            return false;
        
    }   
    
    function fAllowVersion(e)
    {
        var varKey;
        if(window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        var event=e || window.event;
        var target=event.target || event.srcElement;  
        //alert("Value: " + target.value + "- Length: " + target.value.length + 
        //    "- Last: " + target.value.substring(target.value,target.value.length-1));
        //alert(target.value.charAt(target.value.length-1)); 
        if(target.value.charAt(target.value.length-1) == '.' && varKey == 46) return false;
        if (varKey==46 || (varKey>=48 && varKey<=57) || varKey==8 || varKey==127) 
            return true;
        else
            return false;
        
    }  
    
        
Math.Round=function(varNumber,varDecimal)
{
    try
    {
        if (varDecimal==null) varDecimal=0;
        if (varDecimal==0)
            return String(Math.round(varNumber));
        var arrZero=new Array("0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0");
        if (!isNaN(varNumber))
        {
            if (String(varNumber).split('.').length==2)
            {
                var varNumberToRound=String(varNumber).split('.')[1];
                var varRounded="0."+varNumberToRound;
                arrZero.length=varNumberToRound.length;
                if (Number(varNumberToRound)>0)
                {
                    for (var varForLoop=varNumberToRound.length-1;varForLoop>=varDecimal;varForLoop--)
                    {
                        if (Number(varNumberToRound.charAt(varForLoop))>5 && Number(varNumberToRound.charAt(varForLoop))!=0)
                        {
                            arrZero[varForLoop]=1;
                            varRounded=Number(varRounded)+Number("0."+arrZero.join(""));
                            //varNumberToRound=varRounded;
                            if (String(varRounded).length-2<=varDecimal)
                                break;
                            arrZero.length=arrZero.length-1;
                        }
                    }
                }
                else
                {
                    arrZero.length=varDecimal;
                    return String(varNumber).split('.')[0]+"."+arrZero.join("");
                }
            }
            else
            {
                arrZero.length=varDecimal;
                return String(varNumber)+"."+arrZero.join("");
            }
            varNumber=Math.floor(varNumber)+ Number(String(varRounded).split('.')[0]);
            if (String(varRounded).split('.').length>1)
                varNumber=String(varNumber) +"."+String(varRounded.toString().split('.')[1]+"0000").substr(0,varDecimal);
            else
                varNumber=String(varNumber) +".0000000".substr(0,varDecimal+1);
            return varNumber;
        }
        else
        {
            return null;
        }
    }
    catch(ex)
    {
        return null;
    }
}

    
function fAllowNumberNonNegative(e)
{
    var varKey;
    if(window.event)
        varKey=window.event.keyCode;
    else
        varKey=e.which;
    var event=e || window.event;
    var target=event.target || event.srcElement;  
    if (inStr(target.value,'.') && (varKey==46)) return false;
    if (inStr(target.value,'-') && (varKey==45)) return false;
    if (varKey==46 || (varKey>=48 && varKey<=57) || varKey==8 || varKey==127) 
        return true;
    else
        return false;
}
function validateIqamaDate(fld)
{
     var dd, mm, yy;
     var today = new Date;
     var t = new Date;
     fld = stripBlanks(fld);
     if (fld == '') return false;
     if(fld.length < 10) return false;
     var d1 = fld.split('/');
     if (d1.length != 3) d1 = fld.split('-');
     if (d1.length != 3) d1=fld.split('.');
     if (d1.length != 3) return false;
     dd = d1[0]; mm = d1[1]; yy = d1[2];
     if (!isNum(dd)) return false;
     if (!isNum(yy)) return false;
     if (!isNum(mm)) return false;
     if (dd.length>2) return false;
     if (mm.length>2) return false;
     if (yy.length>4) return false;
     dd = parseFloat(dd);
     mm = parseFloat(mm);
     yy = parseFloat(yy);
     if (yy < 100) yy += 2000;
     if (yy < 1100 || yy > 2099) return false;
     if (mm == 2 && (yy%400 == 0 || (yy%4 == 0 && yy%100 != 0))) day[mm-1]++;
     if (mm < 1 || mm > 12) return false;
     if (dd < 1 || dd > day[mm-1]) return false;
     t.setDate(dd); t.setMonth(mm-1); t.setFullYear(yy);
     //if (t > today) return false;
     return true;
}
var ALERT_TITLE = "CampusCare";
var ALERT_BUTTON_TEXT = "Ok";
function pAlertBox(txt) 
{           
    // shortcut reference to the document object document.getElementById(Parent)	    
    d = document;	            
    // if the modalContainer object already exists in the DOM, bail out.
    if(d.getElementById("modalContainer")) return;
    
    // create the modalContainer div as a child of the BODY element
    mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
    mObj.id = "modalContainer";
     // make sure its as tall as it needs to be to overlay all the content on the page
    mObj.style.height = document.documentElement.scrollHeight + "px";	    
    mObj.style.width = document.documentElement.scrollWidth + "px";
    mObj.style.left ="0px";
    mObj.style.top ="0px";        
    mObj.style.display="block";
    mObj.style.position="absolute";
    mObj.style.backgroundColor="#EBF0FF";          
    mObj.style.filter="Alpha(opacity=50)";
    mObj.style.opacity=".9";

    // create the DIV that will be the alert 
    alertObj = mObj.appendChild(d.createElement("div"));
    alertObj.id = "alertBox";
    
    alertObj.style.display="block";
    alertObj.style.position="absolute";
    alertObj.style.backgroundColor="#C2D1FF";	    
    alertObj.style.width="300px";
    alertObj.style.height="120px";
    alertObj.style.border="1px solid #85A3FF";	    
    
    // MSIE doesnt treat position:fixed correctly, so this compensates for positioning the alert
    //if(d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
    // center the alert box
    //alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth)/2 + "px";
    alertObj.style.top = "250px"; //(d.documentElement.height - alertObj.offsetHeight)/2 + "px";
    alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth)/2 + "px";
    alertObj.style.textAlign="Center";
    //alertObj.style.color="blue";

//Creating the title bar

    tit=alertObj.appendChild(d.createElement("div"));
    tit.id="tbar";
    tit.style.width="300px";
    tit.style.height="20px";        
    tit.style.backgroundColor="#85A3FF";
    tit.style.textAlign="left";

    // create an H1 element as the title bar
    h1 = tit.appendChild(d.createElement("h7"));
    
    //h1 = alertObj.appendChild(d.createElement("h7"));
    
    tit.appendChild(d.createTextNode(ALERT_TITLE));


    dclose=tit.appendChild(d.createElement("div"));
    dclose.id="dclo";
    
    dclose.style.display="inline";
    dclose.style.position="absolute";
    
    dclose.style.width="210px";
    dclose.style.height="20px";        
    dclose.style.backgroundColor="#85A3FF";
    dclose.style.textAlign="right";
    
    bnclose=dclose.appendChild(d.createElement('a'));
    bnclose.id="closebtn";                 
    bnclose.style.textDecoration="none";          
    bnclose.appendChild(d.createTextNode("x"));
    bnclose.href="#";
    bnclose.onclick=function() { premoveCustomAlert();return false; }

    // create a paragraph element to contain the txt argument
    msg = alertObj.appendChild(d.createElement("p"));
    msg.innerHTML = txt;
	
    // create an anchor element to use as the confirmation button.
    btnok = alertObj.appendChild(d.createElement("button"));
    btnok.id = "okBtn";
    btnok.style.minWidth="50px";
    btnok.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
    //btn.href = "#";
    // set up the onclick event to remove the alert when the anchor is clicked
    btnok.onclick = function() { premoveCustomAlert(); return false; }	    
    
    
    //Cancel button
//        btncanc = alertObj.appendChild(d.createElement("button"));
//	    btncanc.id = "canBtn";
//	    btncanc.style.minWidth="50px";
//	    btncanc.appendChild(d.createTextNode("Cancel"));	    
//	    btncanc.onclick = function() { premoveCustomAlert();return false; }    	
	
}

// removes the custom alert from the DOM
function premoveCustomAlert() 
{
    document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
}      
function sleep()
{
    document.getElementById("modalContainer").focus();
    document.getElementById("okBtn").focus();
//        var start=new Date().getTime();
//        while (new Date().getTime() < start);
//        //+ delay)
}
function Restrict_MultiLineSpecialChars(e,intMax)
{
    
     var varKey;
     var event=e || window.event;
     var target=event.target || event.srcElement     
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   

        if(varKey!=94 && varKey!=96 && varKey!=124 && varKey!=126 )
        {      
            if(document.getElementById(target.id).value.length<intMax)
                 return true;
            else
                return false;
        }
         else
          return false;               

}
function Restrict_SpecialChars(e)
{
  
     var varKey;
     var event=e || window.event;
     var target=event.target || event.srcElement     
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   

           if(varKey!=94 && varKey!=96 && varKey!=124 && varKey!=126 )
             {       
                 return true;
             }
             else
              return false;               

}
function Restrict_MultiLineSpecialChars(e,intMax)
{
    
     var varKey;
     var event=e || window.event;
     var target=event.target || event.srcElement     
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   

        if(varKey!=94 && varKey!=96 && varKey!=124 && varKey!=126 )
        {      
            if(document.getElementById(target.id).value.length<intMax)
                 return true;
            else
                return false;
        }
         else
          return false;               

}
function Restrict_SpecialChars(e)
{
  
     var varKey;
     var event=e || window.event;
     var target=event.target || event.srcElement     
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   

           if(varKey!=94 && varKey!=96 && varKey!=124 && varKey!=126 )
             {       
                 return true;
             }
             else
              return false;               

}

//For Salted Hashing Added By Honey on assistance of Jeetender Sir on 28.01.2011
    
    /*
 * A JavaScript implementation of the Secure Hash Algorithm, SHA-1, as defined
 * in FIPS PUB 180-1
 * Copyright (C) Paul Johnston 2000.
 * See http://pajhome.org.uk/site/legal.html for details.
 */

/*
 * Convert a 32-bit number to a hex string with ms-byte first
 */
var hex_chr = "0123456789abcdef";
function hex(num)
{
  var str = "";
  for(var j = 7; j >= 0; j--)
    str += hex_chr.charAt((num >> (j * 4)) & 0x0F);
  return str;
}

/*
 * Convert a string to a sequence of 16-word blocks, stored as an array.
 * Append padding bits and the length, as described in the SHA1 standard.
 */
function str2blks_SHA1(str)
{
  var nblk = ((str.length + 8) >> 6) + 1;
  var blks = new Array(nblk * 16);
  for(var i = 0; i < nblk * 16; i++) blks[i] = 0;
  for(i = 0; i < str.length; i++)
    blks[i >> 2] |= str.charCodeAt(i) << (24 - (i % 4) * 8);
  blks[i >> 2] |= 0x80 << (24 - (i % 4) * 8);
  blks[nblk * 16 - 1] = str.length * 8;
  return blks;
}

/*
 * Add integers, wrapping at 2^32. This uses 16-bit operations internally 
 * to work around bugs in some JS interpreters.
 */
function add(x, y)
{
  var lsw = (x & 0xFFFF) + (y & 0xFFFF);
  var msw = (x >> 16) + (y >> 16) + (lsw >> 16);
  return (msw << 16) | (lsw & 0xFFFF);
}

/*
 * Bitwise rotate a 32-bit number to the left
 */
function rol(num, cnt)
{
  return (num << cnt) | (num >>> (32 - cnt));
}

/*
 * Perform the appropriate triplet combination function for the current
 * iteration
 */
function ft(t, b, c, d)
{
  if(t < 20) return (b & c) | ((~b) & d);
  if(t < 40) return b ^ c ^ d;
  if(t < 60) return (b & c) | (b & d) | (c & d);
  return b ^ c ^ d;
}

/*
 * Determine the appropriate additive constant for the current iteration
 */
function kt(t)
{
  return (t < 20) ?  1518500249 : (t < 40) ?  1859775393 :
         (t < 60) ? -1894007588 : -899497514;
}

/*
 * Take a string and return the hex representation of its SHA-1.
 */
 function Restrict_NameNoOnly(e)
{
 var varKey;
     if(window.event)
        varKey=window.event.keyCode;
     else
        varKey=e.which;   
     if(varKey>=65 && varKey<=90 || varKey>=97 && varKey<=122 || varKey>=48 && varKey<=57 || varKey==127 || varKey==8 || varKey==0)
      return true;
     else
      return false; 
}
function calcSHA1(str)
{
  var x = str2blks_SHA1(str);
  var w = new Array(80);

  var a =  1732584193;
  var b = -271733879;
  var c = -1732584194;
  var d =  271733878;
  var e = -1009589776;

  for(var i = 0; i < x.length; i += 16)
  {
    var olda = a;
    var oldb = b;
    var oldc = c;
    var oldd = d;
    var olde = e;

    for(var j = 0; j < 80; j++)
    {
      if(j < 16) w[j] = x[i + j];
      else w[j] = rol(w[j-3] ^ w[j-8] ^ w[j-14] ^ w[j-16], 1);
      t = add(add(rol(a, 5), ft(j, b, c, d)), add(add(e, w[j]), kt(j)));
      e = d;
      d = c;
      c = rol(b, 30);
      b = a;
      a = t;
    }

    a = add(a, olda);
    b = add(b, oldb);
    c = add(c, oldc);
    d = add(d, oldd);
    e = add(e, olde);
  }
  return hex(a) + hex(b) + hex(c) + hex(d) + hex(e);
}
////End///////////////

