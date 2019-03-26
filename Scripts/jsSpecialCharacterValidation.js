// JScript File


function RelaceSpecialcharater(TextBox)
{
//        var a = document.getElementById(TextBox).value;
//        var strArray=a.split("<");
//        a =  strArray.join("&lt;");
//        document.getElementById(TextBox).value=a;  
            var a=document.getElementById(TextBox).value.split('&');
            var str=a.join('&amp;');
            var b=str.split('<');
            str=b.join('&lt;');
            document.getElementById(TextBox).value=str;          
}


function ReplaceSpecialcharacter(frmName)
{

    var varElements=document.getElementById(frmName).getElementsByTagName('INPUT');
    for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
    {
        if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='hidden' || varElements[varForLoop].type.toLowerCase()=='textarea')  
        {
                var a=varElements[varForLoop].value.split('&');
                var str=a.join('&amp;');
                var b=str.split('<');
                str=b.join('&lt;');
                varElements[varForLoop].value=str;
        
//            var a=varElements[varForLoop].value;
//             var strArray=a.split("<");
//             a =  strArray.join("&lt;");
//             varElements[varForLoop].value=a;  
        }
    }
    var varElements=document.getElementById(frmName).getElementsByTagName('TEXTAREA');
    for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
    {
        if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='textarea' || varElements[varForLoop].type.toLowerCase()=='hidden')  
        {
                 var a=varElements[varForLoop].value.split('&');
                var str=a.join('&amp;');
                var b=str.split('<');
                str=b.join('&lt;');
                varElements[varForLoop].value=str;
//            var a=varElements[varForLoop].value;
//            var strArray=a.split("<");
//            a =  strArray.join("&lt;");
//            varElements[varForLoop].value=a;  
        }
    }
}

function ReplaceSpecialcharacterToNormal(frmName)
{
    var varElements=document.getElementById(frmName).getElementsByTagName('INPUT');
    for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
    {
        if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='hidden' || varElements[varForLoop].type.toLowerCase()=='textarea')  
        {
//            var a=varElements[varForLoop].value;
//             var strArray=a.split("&lt;");
//             a =  strArray.join("<");
//             varElements[varForLoop].value=a; 
                 var a=varElements[varForLoop].value.split('&amp;');
                var str=a.join('&');
                var b=str.split('&lt;');
                str=b.join('<');
                varElements[varForLoop].value=str; 
        }
    }
    var varElements=document.getElementById(frmName).getElementsByTagName('TEXTAREA');
    for (var varForLoop=0;varForLoop<varElements.length;varForLoop++)
    {
        if (varElements[varForLoop].type.toLowerCase()=='text' || varElements[varForLoop].type.toLowerCase()=='textarea' || varElements[varForLoop].type.toLowerCase()=='hidden')  
        {
//            var a=varElements[varForLoop].value;
//              var strArray=a.split("&lt;");
//                 a =  strArray.join("<");
//             varElements[varForLoop].value=a;  

                  var a=varElements[varForLoop].value.split('&amp;');
                var str=a.join('&');
                var b=str.split('&lt;');
                str=b.join('<');
                varElements[varForLoop].value=str; 
        }
    }
}


