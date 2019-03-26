/*
    Copyright               :   Entab Infotech Pvt. Ltd.
    Year                    :   2009
    Codes                   :   Daison
    Testing & Modification  :   Shiju
    Remarks                 :   Don't do any Modifications with out Consult to Daison
                                Last Modified On 28th December 2009  
*/
            
var XmlHttp;
var RequestArray=new Array();
//Creating and setting the instance of appropriate XMLHTTP Request object to a “XmlHttp” variable  
function CreateHTTP()
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
/*--------------------------------------------------------------------*/
function XML_HTTP_class()
{
	var ns=!document.all;
	var ax=null;
	do_init();

	function do_init()
	{
		function err(e)
		{
			program_abort("foundation_download_class: Cannot create XMLHTTP: ",e);
		}
		if(ns)
		{
			try
			{
				ax=new XMLHttpRequest()
			}
			catch(e)
			{
				err(e)
			}
		}
		else if (window.ActiveXObject)
		{
			try
			{
				ax=new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch(e)
			{
				err(e)
			}
		}
		else
		{
			program_abort("Your browser does not support XMLHTTP");
		}
	}
	
	this.getResponseText=function()
	{
		return ax.responseText;
	}
	
	this.getResponse=function()
	{
		return ax.responseText;
	}
	
	this.GET=function(url)
	{
		ax.open("get",url,false);
		if(ns)
			ax.send(null);
		else
			ax.send();
	}
	
	this.postForm=function(url,sss)
	{
		ax.open("post",url,false);
		ax.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
		ax.send(sss);
	}
	
	this.postXML=function(url,sss)
	{
		ax.open("post",url,false);
		ax.setRequestHeader("Content-Type","text/xml");
		ax.send(sss);
	}
} 

var httpRequest=new XML_HTTP_class();

function getAjaxInfo(url)
{
	httpRequest.GET(url);
	return httpRequest.getResponseText();
}
  
 
/*----------------------------------------------------------------------*/   
    function clearGrid(gridName)
    {
        try
        {
             for (var intforLoop=1;intforLoop<document.getElementById(gridName).rows.length;intforLoop++)
             {
                for (var intForCol=0;intForCol<document.getElementById(gridName).rows[intforLoop].cells.length;intForCol++)
                {
                         for (var varNodes=0;varNodes<document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes.length;varNodes++)
                        {
                            try
                            {
                                //document.getElementById('gvVoucherEntry').rows[intforLoop].cells[intForCol].getElementsByTagName('INPUT')[0].readOnly=false;
                                if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].type.toLowerCase()=='text')
                                { 
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].value='';
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].readOnly=false;
                                }
                                else if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].type.toLowerCase()=='select-one')
                                {
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].disabled=false;
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].selectedIndex=0;
                                }
                                else if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].type.toLowerCase()=='checkbox')
                                {
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].disabled=false;
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[varNodes].checked=false;
                                }
                                else
                                {
                                    document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes[0].value='';
                                }
                            }
                            catch(ex)
                            {

                            }
                        }
                }
                document.getElementById(gridName).rows[intforLoop].style.display='none';
             }
             if (intforLoop>0) document.getElementById(gridName).rows[1].style.display='';
        }
        catch (ex)
        {
        }
    }   
function selectLst(e)
{
    try
    {
        var varKey;
        if(window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        if (varKey==40)
        {
            if (ListBox!='null' && IFrame.style.display!='none') 
            {
                ListBox.disabled=false;
                ListBox.focus();
                
            }

        }
        else if (varKey==9)
        {
            document.getElementById(ParentObject).focus();
            hideLstBox();

        }
        return true;
    }
    catch (ex)
    {
    }
}
function addRow(gridName,blnSlNo)
{
    try
    {
        for (var intforLoop=1;intforLoop<document.getElementById(gridName).rows.length;intforLoop++)
        {
            if (document.getElementById(gridName).rows[intforLoop].style.display=='none')
            {
                document.getElementById(gridName).rows[intforLoop].style.display='';
                for (var intForCol=0;intForCol<document.getElementById(gridName).rows[intforLoop].cells.length;intForCol++)
                    if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].style.display!='none' && document.getElementById(gridName).rows[intforLoop].cells[intForCol].childNodes.length>0)
                    {
                        if (blnSlNo==true)
                        {
                            try
                            {
                                document.getElementById(gridName).rows[intforLoop].cells[0].childNodes[1].value=intforLoop;
                            }
                            catch (ex)
                            {
                                document.getElementById(gridName).rows[intforLoop].cells[0].firstChild.nodeValue=intforLoop;
                            }
                                
                        }
                        if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('INPUT').length>0)
                        {
                            document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('INPUT')[0].focus();
                        }
                        else if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('SELECT').length>0)
                        {
                            document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('SELECT')[0].focus();
                        }
                        else if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('TEXTAREA').length>0)
                        {
                            document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('TEXTAREA')[0].focus();
                        }
                        else if (document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('PASSWORD').length>0)
                        {
                            document.getElementById(gridName).rows[intforLoop].cells[intForCol].getElementsByTagName('PASSWORD')[0].focus();
                        }
                        else
                        {
                            document.getElementById(gridName).rows[intforLoop].cells[intForCol].firstChild.focus();
                        }
                        return;
                    }
                return;
            }
        }
    }
    catch (ex)
    {
    }
}
var ParentObject;
var ListBox;//=document.createElement('SELECT',true);
var IFrame=document.createElement('iframe',true);
var varGridRow;
var varAction;
document.onclick=hideLstBox;
function pFillListBox(ParentObject1,strQry,varMinLength,varDesitination)
{
    try
    {
        RequestArray.length=0;
        if (document.getElementById(ParentObject1).value.length<varMinLength) 
        {
            hideLstBox();
            return;
        }
        ListBox=document.getElementById(varDesitination);
        ListBox.length=10;
        ListBox.length=0;
        ListBox.disabled=false;
        ParentObject=ParentObject1;
        if (navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
        {
            document.getElementById(ParentObject).onkeydown=function() {selectLst(event);};
            ListBox.onkeydown=function(){ selectLst(event);};
            ListBox.onkeyup=function(){displayValueKeyPress(event);};
       
        }
        else
        {
        
            ListBox.setAttribute("onkeydown","selectLst(event);");
            ListBox.setAttribute("onkeyup","displayValueKeyPress(event);");
            document.getElementById(ParentObject).setAttribute("onkeydown","selectLst(event)");
        }
        IFrame.id="IFrame";
        IFrame.style.zIndex=999;
        IFrame.style.width=String(parseInt(document.getElementById(ParentObject).style.width))+"px";
        IFrame.style.height="";
        IFrame.style.display='none';
        var varTable=document.getElementsByTagName("TBODY")[0];
       // ListBox.id='lstCDisplay';
        ListBox.multiple='multiple';
        ListBox.style.height="";
        ListBox.style.width=String(parseInt(document.getElementById(ParentObject).style.width))+"px";
        ListBox.style.display='none';
        ListBox.onclick=function(){ displayValue('onclick');};
        ListBox.onchange=function(){ displayValue('onchange');};
        ListBox.style.fontFamily=document.getElementById(ParentObject).style.fontFamily;
        ListBox.style.fontSize=document.getElementById(ParentObject).style.fontSize;
        ListBox.style.backgroundColor=document.getElementById(ParentObject).style.backgroundColor;
        ListBox.style.color=document.getElementById(ParentObject).style.color;
        ListBox.className=document.getElementById(ParentObject).className;
        ListBox.onfocusout=function() {hideLstBox();};
        ListBox.style.zIndex=1000;
        if (document.getElementById('IFrame')==null) varTable.appendChild(IFrame);
        setLoadingPicPosition(ParentObject,'');
        varAction='FillListBox';
        var varClTime=new Date();
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&pAction=FillListBox&DtTime="+varClTime+"&TypeID=FillListBox";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        var ddlBind=ListBox.id;
        ListBox.length=0;
        ddlBind.length=0;
        var arrData=data.split('~');
        var LstWidth=0;
        if (arrData.length>=0 && data!="")
        {
            var optionItem;
            var txt;
            for(var i = 0;i<arrData.length;i++)
            {
                txt =  arrData[i].split('^');
                if (LstWidth<txt[0].length) LstWidth=txt[0].length;
                optionItem = new Option( txt[0], txt[1],  false, false);
                ListBox.options.add(optionItem);
            }
            setPanelPosition(ParentObject, IFrame);
            setPanelPosition(ParentObject, ListBox);
            IFrame.style.display='inline';
            if (arrData.length>9) 
            {
                LstWidth=LstWidth+15;
                ListBox.style.height="150px";
                IFrame.style.height="140px";
                ListBox.rows=10;
            }
            else
            {
                ListBox.style.height=String(i*17)+"px";
                IFrame.style.height=String(i*16)+"px";
                if (i==1)  
                {
                    ListBox.style.height="25px";
                    IFrame.style.height="5px";
                }
                else if (i==2)  
                {
                    ListBox.style.height="45px";
                    IFrame.style.height="30px";
                }
             }
            if (document.getElementById('img')!=null) document.getElementById('img').style.display="none";
            return false;
        }
        else
        {
            IFrame.style.display='none'
            ListBox.style.display='none';
            if (document.getElementById('img')!=null) document.getElementById('img').style.display="none";
            return false;
        }
        return false;
    }
    catch (ex)
    {
        return false;
    }
}
function pFillCheckListBox(chkListBox,strQry,varStyle)
{
    try
    {
        RequestArray.length=0;
        RequestArray.push("pFillCheckListBox('" + chkListBox + "',\"" + strQry + "\",'" + varStyle + "')");
        chkListBox=document.getElementById(chkListBox);
        varAction='FillDDL';
        var varClTime=new Date();
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&pAction=FillCheckBox&DtTime="+varClTime+"&TypeID=FillCheckBox";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        for (var intForLoop=chkListBox.rows.length-1;intForLoop>=0;intForLoop--)
        {
            chkListBox.deleteRow(intForLoop);
        }
        var arrData=data.split('~');
        if (arrData.length>=0 && data!="")
        {
            var txt;
            if (varStyle.toLowerCase()=="horizontal")
            {
                var varTR=document.createElement('TR');
                 for(var i = 0;i<arrData.length;i++)
                {
                    txt =  arrData[i].split('^');
                    var varTD=document.createElement('TD');
                    if (txt.length>2)
                    {
                        if (txt[2].toLowerCase()=="true")
                            varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox CHECKED><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                        else
                            varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                    }
                    else
                    {
                         varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                    }
                    varTR.appendChild(varTD);
                    
                }
                chkListBox.getElementsByTagName('TBODY')[0].appendChild(varTR);
            }
            else
            {
                for(var i = 0;i<arrData.length;i++)
                {
                    txt =  arrData[i].split('^');
                    var varTR=document.createElement('TR');
                    var varTD=document.createElement('TD');
                    if (txt.length>2)
                    {
                        if (txt[2].toLowerCase()=="true")
                            varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox CHECKED><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                        else
                            varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                    }
                    else
                    {
                         varTD.innerHTML="<INPUT id=" + chkListBox.id+'_'+String(i) + " type=checkbox><LABEL class=MyLabel id=" + txt[0] + ">" + txt[1] + "</LABEL>"
                    }
                    varTR.appendChild(varTD);
                    chkListBox.getElementsByTagName('TBODY')[0].appendChild(varTR);
                }
            }
        }
        RequestArray.length=RequestArray.length-1;
        if (RequestArray.length>0)
        {
             eval(RequestArray.pop());
        }
    }
    catch (ex)
    {
        RequestArray.length=RequestArray.length-1;
        if (RequestArray.length>0)
        {
             eval(RequestArray.pop());
        }
    }
    return false;
}
var ddl;
function pFillDDL(ddlName,strQry)
{
    try
    {
        RequestArray.length=0;
        RequestArray.push("pFillDDL('" + ddlName + "',\"" + strQry + "\")");
        ddl=document.getElementById(ddlName);
        varAction='FillDDL';
        var varClTime=new Date();
        //strQry= strQry.replace(/\+/g,"\\");
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&pAction=FillListBox&DtTime="+varClTime+"&TypeID=FillListBox";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        var ddlValue=ddl.value;
        ddl.length=0;
        var arrData=data.split('~');
        if (arrData.length>=0 && data!="")
        {
            var optionItem;
            var txt;
            for(var i = 0;i<arrData.length;i++)
            {
                txt =  arrData[i].split('^');
                optionItem = new Option( txt[0], txt[1],  false, false);
                ddl.options.add(optionItem);
            }
            if (ddlValue!="") ddl.value=ddlValue;
            if (ddl.selectedIndex<0) ddl.selectedIndex=0;
        }
        RequestArray.length=RequestArray.length-1;
        if (RequestArray.length>0)
        {
             eval(RequestArray.pop());
        }
        return;
    }
    catch (ex)
    {
        return false;
    }
}
function pReturnSingleValue(strQry)
{
    try
    {
        RequestArray.length=0;
        RequestArray.push("pReturnSingleValue(\"" + strQry + "\")");
        varAction='ReturnSingleValue';
        var varClTime=new Date();
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&pAction=ReturnSingleValue&DtTime="+varClTime+"&TypeID=ReturnSingleValue";
        var responseStream=getAjaxInfo(requestUrl);
        var varAction=eval("(responseStream)");
        return varAction;
    }
    catch (ex)
    {
        return false;
    }
}
function pExecuteQuery(strQry)
{
    try
    {
        RequestArray.length=0;
        var varClTime=new Date();
        RequestArray.push("pExecuteQuery(\"" + strQry + "\")");
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&TypeID=ExecuteQuery&DtTime="+varClTime+"";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        if (data=="")
        {
            RequestArray.length=RequestArray.length-1;
            if (RequestArray.length>0)
            {
                eval(RequestArray.pop());
            }
            return "";
        }
        else
        {
            RequestArray.length=RequestArray.length-1;
            if (RequestArray.length>0)
            {
                eval(RequestArray.pop());
            }
            return data;
        }
    }
    catch (ex)
    {
        return false;
    }
}
var GridName
function fillGrid(varGridName,strQry)
{
    try
    {
        RequestArray.length=0;
        RequestArray.push("fillGrid('" + varGridName + "',\"" +strQry + "\")");
        GridName=document.getElementById(varGridName);
        //encodeURIComponent(document.getElementById(ParentObject).value)
        varAction='FillGrid';
        var varClTime=new Date();
        //strQry= strQry.replace(/\+/g,"\\");
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&TypeID=FillGrid&DtTime="+varClTime+"";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        pClearGrid();
        arrData=data.split('~');
        if (arrData.length>0 && data!="")
        {
            for(var i = 0;i<arrData.length;i++)
            {
                var varColValue=arrData[i].split('^');
                for (var j=0;j<varColValue.length;j++)
                {
                
                    if (GridName.rows[i+1].cells[j].childNodes.length>1)
                    {
                        if (GridName.rows[i+1].cells[j].getElementsByTagName('input').length>0)
                        {
                            if (GridName.rows[i+1].cells[j].getElementsByTagName('input')[0].type=='checkbox')
                            {
                                if (varColValue[j].toLowerCase()=="false")
                                    GridName.rows[i+1].cells[j].getElementsByTagName('input')[0].checked=false;
                                else
                                    GridName.rows[i+1].cells[j].getElementsByTagName('input')[0].checked=true;
                            }
                            else
                            {
                                GridName.rows[i+1].cells[j].getElementsByTagName('input')[0].value=varColValue[j]; 
                            }
                        }
                        else if (GridName.rows[i+1].cells[j].getElementsByTagName('select').length>0)
                        {
                            GridName.rows[i+1].cells[j].getElementsByTagName('select')[0].value=varColValue[j];
                        }
                       else if (GridName.rows[i+1].cells[j].getElementsByTagName('TEXTAREA').length>0)
                        {
                            GridName.rows[i+1].cells[j].getElementsByTagName('TEXTAREA')[0].value=varColValue[j];
                        }
                    }
                    else
                        GridName.rows[i+1].cells[j].childNodes[0].nodeValue=varColValue[j];
                }
                GridName.rows[i+1].style.display='';
               // return ;
            }
        }
        RequestArray.length=RequestArray.length-1;
        if (RequestArray.length>0)
        {
             eval(RequestArray.pop());
        }
    }
    catch (ex)
    {
        return false;
    }
}
function pAssignSingleValue(varObject,strQry)
{
    try
    {
        RequestArray.length=0;
        RequestArray.push("pAssignSingleValue('" + varObject + "',\"" +strQry + "\")");
        var varClTime=new Date();
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&pAction=ReturnSingleValue&DtTime="+varClTime+"&TypeID=ReturnSingleValue";
        var responseStream=getAjaxInfo(requestUrl);
        document.getElementById(varObject).value= eval("(responseStream)");
        RequestArray.length=RequestArray.length-1;
        if (RequestArray.length>0)
        {
             eval(RequestArray.pop());
        }
        return false;
    }
    catch (ex)
    {
        return false;
    }
}
var ClientGrid;
var varSlNo;

function FillClientGrid(varGridName,strQry,blnSlNo)
{
    
    try
    {
        RequestArray.length=0;
        RequestArray.push("FillClientGrid('" +varGridName + "',\"" + strQry + "\",'" + blnSlNo + "')");
        varSlNo=blnSlNo;
        ClientGrid=varGridName;
        //encodeURIComponent(document.getElementById(ParentObject).value)
        varAction='FillClientGrid';
        var varClTime=new Date();
        //strQry= strQry.replace(/\+/g,"\\");
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&TypeID=FillClientGrid&DtTime="+varClTime+"";
        var responseStream=getAjaxInfo(requestUrl);
        var data=eval("(responseStream)");
        
        var varClientTable
        var varParentTable;
        if (document.getElementById('gv'+ClientGrid)==null)
        {
            varParentTable=document.createElement('TABLE');
            varParentTable.id='gv'+ClientGrid;
            varParentTable.borderWidth="1px";
            varParentTable.bordercolor="black";
            var varParentTBody=document.createElement('TBODY');
            varParentTable.appendChild(varParentTBody);
            varClientTable=varParentTable.getElementsByTagName('TBODY')[0];
        }
        else
        {
            varParentTable=document.getElementById('gv'+ClientGrid);
            varClientTable=document.getElementById('gv'+ClientGrid).getElementsByTagName('TBODY')[0];
        }
        for (var intForLoop=varClientTable.rows.length-1;intForLoop>=1;intForLoop--)
        {
            //deleteRow(varClientTable,intForLoop);
            varClientTable.deleteRow(intForLoop);
        }
        // i = Rows ; j = Columns
        var varGridData=data.split('~');
        if (varGridData.length>0 && data!="")
        {
            if (varClientTable.rows.length>0) 
                varClientTable.deleteRow(0);
            for(var i = 0;i<varGridData.length;i++)
            {
                var row=document.createElement('TR');
                //if (i%2>0)
                    row.className='MyGridViewRow';
               // else
                    //row.Class='MyGridViewAlternate';
                var varColValue=varGridData[i].split('^');
                for (var j=0;j<varColValue.length;j++)
                {
                    if (i==0 && j==0 && varSlNo==true)
                    {
                        var cell=document.createElement('TH');
                        cell.align="right";
                        cell.appendChild(document.createTextNode('Sl.No.'));
                        row.className="MyGridViewHeader";
                        row.appendChild(cell);
                    }
                    else if (j==0 && varSlNo==true)
                    {
                        var cell=document.createElement('TD');
                        cell.align="right";
                        cell.appendChild(document.createTextNode(i));
                        row.appendChild(cell);
                    }
                    if (i==0)
                        var cell=document.createElement('TH');
                    else
                        var cell=document.createElement('TD');
                    cell.appendChild(document.createTextNode(varColValue[j]));
                    row.appendChild(cell);
                }
                varClientTable.appendChild(row);
            }
            //debugger;
            
            varParentTable.cellSpacing="0";
           // varParentTable.cellPadding="0";
          // varParentTable.borderWidth="1px";
            varParentTable.border="1";
            varParentTable.style.borderCollapse="collapse";
           // varParentTable.borderColor="#FFC1A4";
            varParentTable.borderColor="#FFFFFF";
           // document.getElementById(ClientGrid).innerHTML=varParentTable.outerHTML;
            document.getElementById(ClientGrid).appendChild(varParentTable);
            RequestArray.length=RequestArray.length-1;
            if (RequestArray.length>0)
            {
                 eval(RequestArray.pop());
            }
        }
        else
        {
            // NEW -----------------------------------------
            if (varClientTable.rows.length<2)
            {   
                // CREATE NO RECORD MESSAGE
                var row=document.createElement('TR');
                var cell=document.createElement('TH');
                // GET COL COUNT
                colCount = varParentTable.getElementsByTagName('TH').length;
                cell.colSpan = colCount;  
                cell.align="center"; // style="text-align:center"
                cell.appendChild(document.createTextNode('No Record Found'));
                row.className="EmptyDataStyle";
                row.appendChild(cell);
                varClientTable.appendChild(row);
            }
            // END NEW -------------------------------------
            
        }
    }
    catch (ex)
    {
        return false;
    }
}

function setPanelPosition(oTextBox, oCalendar) 
{
    try
    {
        var curleft = curtop = 0;
        var textBox = document.getElementById(oTextBox);
        var calendar = oCalendar;
        if (textBox.offsetParent) {
            curleft = textBox.offsetLeft
            curtop = textBox.offsetTop

            while (textBox = textBox.offsetParent) 
            {
                curleft += textBox.offsetLeft
                curtop += textBox.offsetTop
            }
        }
        calendar.style.position="static";
        calendar.style.position="absolute";
        calendar.style.top = String(curtop+20)+"px";
        calendar.style.left = String(curleft)+"px";
        calendar.style.width=String(parseInt(document.getElementById(oTextBox).style.width))+"px";
        calendar.style.display = "inline";
    }
    catch (ex)
    {
        return false;
    }
}
var img=document.createElement('img',true);
function setLoadingPicPosition(oTextBox,picture) 
{
    try
    {
        img.id="img";
        img.zIndex=1000;
        img.style.height="14px";//String(parseInt(document.getElementById(oTextBox).style.height-1))+"px";
        img.onError=function(){img.src='Images/loading.gif';};
        if (picture!='')
            img.src=picture;
        else
            img.src='Images/spinner.gif';//"Images/remembermilk_orange.gif";//Images/loading.gif
      //  img.style.display="inline";
        oCalendar=img;
        var varTable=document.getElementsByTagName("TBODY")[0];
        if (document.getElementById('img')==null) varTable.appendChild(img);
        var curleft = curtop = 0;
        var textBox = document.getElementById(oTextBox);
        var calendar = oCalendar;
        if (textBox.offsetParent) {
            curleft = textBox.offsetLeft
            curtop = textBox.offsetTop

            while (textBox = textBox.offsetParent) 
            {
                curleft += textBox.offsetLeft
                curtop += textBox.offsetTop
            }
        }
        calendar.style.position="static";
        calendar.style.position="absolute";
        calendar.style.top = String(curtop+4)+"px";
        calendar.style.left = String(curleft+parseInt(document.getElementById(oTextBox).style.width)-11.0)+"px";
        calendar.style.width="14px";
        calendar.style.display = "inline";
    }
    catch (ex)
    {
        return false;
    }
}
function setHideLoadingPicture()
{
    if (document.getElementById('img')!=null) document.getElementById('img').style.display='none'; 
}
function displayValue(action)
{
    try
    {
        if (ParentObject!=null && ListBox!=null)
        {
            if (ListBox.selectedIndex<0) return;
            document.getElementById(ParentObject).value= ListBox[ListBox.selectedIndex].text;
            document.getElementById('hdn'+ParentObject).value= ListBox[ListBox.selectedIndex].value
            if (action!='onclick') return;
            document.getElementById(ParentObject).focus();
            IFrame.style.display='none'; 
            ListBox.style.display='none';
        }
    }
    catch (ex)
    {
        return false;
    }
}
function displayValueKeyPress(e)
{
    try
    {
        var varKey;
        if(window.event)
            varKey=window.event.keyCode;
        else
            varKey=e.which;
        if (varKey!=13) return true;
        if (ParentObject!=null && ListBox!=null)
        {
            if (ListBox.selectedIndex<0) return;
            document.getElementById(ParentObject).value= ListBox[ListBox.selectedIndex].text;
            document.getElementById('hdn'+ParentObject).value= ListBox[ListBox.selectedIndex].value;
            document.getElementById(ParentObject).focus();
            IFrame.style.display='none'; 
            ListBox.style.display='none';
        }
    }
    catch (ex)
    {
        return false;
    }
}
//function hideLstBox()
//{
//    if (IFrame!=null) IFrame.style.display='none'; 
//    if (ListBox!=null) ListBox.style.display='none';
//    if (document.getElementById(ParentObject)!=null && event.type=="click" && event.srcElement.id==ListBox.id) document.getElementById(ParentObject).focus();
//}

function hideLstBox()
{  
    if (IFrame!=null) IFrame.style.display='none'; 
    if (ListBox!=null) ListBox.style.display='none';
  if(ListBox!=null)
  {
    if (document.getElementById(ParentObject)!=null && event.type=="click" && event.srcElement.id==ListBox.id) document.getElementById(ParentObject).focus();
  }
}


function AddGridAttributes(varForm)
{
    try
    {
        var frmElements=document.getElementById(varForm).getElementsByTagName("TABLE");
        for (var varForLoop=0;varForLoop<frmElements.length;varForLoop++)
        {
            if (frmElements[varForLoop].className.toLowerCase()=="forentry")
            {
                for (var intForLoop=1;intForLoop<frmElements[varForLoop].rows.length;intForLoop++)
                {
                    if (intForLoop<frmElements[varForLoop].rows.length-1) frmElements[varForLoop].rows[intForLoop+1].style.display='none';
                }
                GridName=frmElements[varForLoop];
                pClearGrid();
            }
        }
    }
    catch (ex)
    {
        return false;
    }
}
function pClearGrid()
{
    try
    {
        for (var intForLoop=1;intForLoop<GridName.rows.length;intForLoop++)
        {
            for (var varForColLoop=0;varForColLoop<GridName.rows[intForLoop].cells.length;varForColLoop++)
            {
                if (GridName.rows[intForLoop].cells[varForColLoop].firstChild.value!=null)
                {
                    if (GridName.rows[intForLoop].cells[varForColLoop].firstChild.type=="checkbox")
                        GridName.rows[intForLoop].cells[varForColLoop].firstChild.checked==false;
                    else
                        GridName.rows[intForLoop].cells[varForColLoop].firstChild.value='';
                }
                else
                {
                    GridName.rows[intForLoop].cells[varForColLoop].firstChild.nodeValue=' ';
                    if (GridName.rows[0].cells[0].firstChild.nodeValue.toLowerCase()=='sl. no.' || GridName.rows[0].cells[0].firstChild.nodeValue.toLowerCase()=='sl.no.')
                    {
                       GridName.rows[intForLoop].cells[0].firstChild.nodeValue=intForLoop;
                    }
                }
            }
           if (intForLoop<GridName.rows.length-1) GridName.rows[intForLoop+1].style.display='none';
        }
    }
    catch (ex)
    {
        return false;
    }
}
var SearchString='';
function pSelectValueFromDDL(ddl,e)
{
    try
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
        else if (varKey==40 || varKey==9)
        {
            varKey='';
            return true;
        }
        var event=e || window.event;
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
     catch (ex)
    {
        return false;
    }
}
//For Month control
 var varObject='Month';
 var vartxtFinMonth;
 var vartxtYear;
 var varbtnUpMonth;
 var varbtnDownMonth;
 var varbtnUpYear;
 var varbtnDownYear;
 var strhdnDate;
function pSetMonthControlDate(MonthControl,varMonth,varYear)
{
    document.getElementById(MonthControl+'_txtYear').value=varYear;
    document.getElementById(MonthControl+'_txtFinMonth').value=varMonth;
    validateValue('Month',MonthControl+'_txtYear');
    validateValue('Year',MonthControl+'_txtYear');
}

function pSetControlName(ctlName)
{
    var artemp=ctlName.split('_');
    artemp.length=artemp.length-1;
    ctlName=artemp.join('_');
    vartxtFinMonth=ctlName+'_txtFinMonth';
    vartxtYear=ctlName+'_txtYear';
    varbtnUpMonth=ctlName+'_btnUpMonth';
    varbtnDownMonth=ctlName+'_btnDownMonth';
    varbtnUpYear=ctlName+'_btnUpYear';
    varbtnDownYear=ctlName+'_btnDownYear';
    strhdnDate=ctlName+'_Date';
}
function pAdjust(varObject,ctlName)
{
    pSetControlName(ctlName);
    if (varObject=='Year')
    {
        document.getElementById(vartxtYear).select();
        document.getElementById(varbtnUpMonth).style.display='none';
        document.getElementById(varbtnDownMonth).style.display='none';
        document.getElementById(varbtnUpYear).style.display='block';
        document.getElementById(varbtnDownYear).style.display='block';
    }
    else
    {
        document.getElementById(vartxtFinMonth).select();
        document.getElementById(varbtnUpMonth).style.display='block';
        document.getElementById(varbtnDownMonth).style.display='block';
        document.getElementById(varbtnUpYear).style.display='none';
        document.getElementById(varbtnDownYear).style.display='none';
    }
}
function validateValue(varValue,ctlName)
{
    var varDate=new Date();
    pSetControlName(ctlName);
    var arrMonth=new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
    document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
    if (varValue=='Month')
    {
        if (isNaN(document.getElementById(vartxtFinMonth).value)==false)
        {
            if (Number(document.getElementById(vartxtFinMonth).value)<=12 && Number(document.getElementById(vartxtFinMonth).value)>=1)
            {
                document.getElementById(vartxtFinMonth).value=arrMonth[Number(document.getElementById(vartxtFinMonth).value)-1];
            }
            else
            {
                document.getElementById(vartxtFinMonth).value=arrMonth[varDate.getMonth()];
            }
        }
    }
    else
    {
        if (isNaN(document.getElementById(vartxtYear).value)==false)
        {
            if (Number(document.getElementById(vartxtYear).value)<=2099 && Number(document.getElementById(vartxtYear).value)>=1900)
                return true;
            else if (Number(document.getElementById(vartxtYear).value)<=99 && Number(document.getElementById(vartxtYear).value)>=0)
                document.getElementById(vartxtYear).value=2000 + Number(document.getElementById(vartxtYear).value);
            else
                document.getElementById(vartxtYear).value=varDate.getFullYear();
        }
    }
    document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
}
function fClick(e)
{
    var varkey;
     if(window.event)
        varkey=window.event.keyCode;
     else
        varkey=e.which;  
    var event=e || window.event;
    var ctlName=event.target || event.srcElement;
    pSetControlName(ctlName.id);
    if (varkey==40)
    {
        document.getElementById(varbtnDownMonth).click();
        return false;
    }
    else if(varkey==38)
    {
        document.getElementById(varbtnUpMonth).click();
        return false;
    }
    else if ((varkey>=96 && varkey<=105) || (varkey>=48 && varkey<=57) || varkey==8 || varkey==46)
    {
        if (isNaN(document.getElementById(vartxtFinMonth).value)==true) document.getElementById(vartxtFinMonth).value='';
        //alert(isNaN(document.getElementById(vartxtFinMonth).value));
        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
        return true;
    }
    else if (varkey==9)
    {
        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
        return true;
    }
    else
        return false;
}
function fYearClick(e)
{
    var varkey;
     if(window.event)
        varkey=window.event.keyCode;
     else
        varkey=e.which;   
    var event=e || window.event;
    var ctlName=event.target || event.srcElement;
    pSetControlName(ctlName.id);
    if (varkey==40)
    {
        document.getElementById(varbtnUpYear).click();
        return false;
    }
    else if(varkey==38)
    {
        document.getElementById(varbtnDownYear).click();
        return false;
    }
     else if ((varkey>=96 && varkey<=105 ) || (varkey>=48 && varkey<=57) || varkey==8 || varkey==46 || varkey==9)
        return true;
    else
        return false;
}
function ChangeYearValue(varPm,varType,varTargetID)
{
    var varDate=new Date();
    pSetControlName(varTargetID);
     var arrMonth=new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
    if (varPm=='DOWN')
    {
        if (varType=='Month')
        {
            for (var varForLoop=0;varForLoop<=arrMonth.length-1;varForLoop++)
            {
                if (arrMonth[varForLoop]==document.getElementById(varTargetID).value)
                {
                    if (varForLoop==0) 
                    {
                        document.getElementById(varTargetID).value=arrMonth[arrMonth.length-1];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                    else
                    {
                        document.getElementById(varTargetID).value=arrMonth[varForLoop-1];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                }
            }
            document.getElementById(varTargetID).value=arrMonth[varDate.getMonth()];
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
            return false
        }
        else if (varType=='Year')
        {
            if (document.getElementById(varTargetID).value=='')  document.getElementById(varTargetID).value=varDate.getFullYear()-1;
            document.getElementById(varTargetID).value=Number(document.getElementById(varTargetID).value)+1;
            if (document.getElementById(varTargetID).value>2099)
                document.getElementById(varTargetID).value=1900;
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
            return false;
        }
    }
    else
    {
       if (varType=='Month')
       {
            for (var varForLoop=0;varForLoop<=arrMonth.length-1;varForLoop++)
            {
                if (arrMonth[varForLoop]==document.getElementById(varTargetID).value)
                {
                   if (varForLoop==arrMonth.length-1)
                    {
                        document.getElementById(varTargetID).value=arrMonth[0];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                    else
                    {
                        document.getElementById(varTargetID).value=arrMonth[varForLoop+1];
                        document.getElementById(varTargetID).select();
                        document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
                        return false
                    }
                }
            }
            document.getElementById(varTargetID).value=arrMonth[varDate.getMonth()];
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
            return false
       }
       else if (varType=='Year')
       { 
            if (document.getElementById(varTargetID).value=='')  document.getElementById(varTargetID).value=varDate.getFullYear()+1;
            document.getElementById(varTargetID).value=Number(document.getElementById(varTargetID).value)-1;
            if (document.getElementById(varTargetID).value<1900)
                document.getElementById(varTargetID).value=2099;
            document.getElementById(varTargetID).select();
            document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
             return false;
        }
       
    }
    document.getElementById(strhdnDate).value='15 ' + document.getElementById(vartxtFinMonth).value +' '+document.getElementById(vartxtYear).value;
    return false;
}
//End Month Control Script
function fixGridViewHeader(gvName)
{
    try
    {
        if (gvName!=null)
        {
            if (gvName.rows.length>1)
            {
                var varTable=document.createElement('TABLE');
                varTable.id="MyTableID";
                var varTBody=document.createElement('TBODY');
                varTable.appendChild(varTBody);
                var varTR=gvName.getElementsByTagName('TR')[0].cloneNode(true);
                varTable.getElementsByTagName('TBODY')[0].appendChild(varTR);
                varTable.cellSpacing="0";
                varTable.border="1";
                varTable.borderColor=gvName.borderColor;
                varTable.style.borderCollapse="collapse";
                if (navigator.userAgent.toLowerCase().indexOf("firefox")!=-1)
                    varFactor=0;
                else
                    varFactor=8;
                for (var varForLoop=0;varForLoop<gvName.rows[0].cells.length;varForLoop++)
                {
                    if (gvName.rows[0].cells[varForLoop].style.display!='none' && gvName.rows[0].cells[varForLoop].offsetWidth>0) varTable.rows[0].cells[varForLoop].width=gvName.rows[0].cells[varForLoop].offsetWidth-varFactor;
                }
                document.getElementsByTagName('TBODY')[0].appendChild(varTable);
                vargvName=gvName;
                var curleft = curtop = 0;
                if (vargvName.offsetParent) 
                {
                    curleft = vargvName.offsetLeft;
                    curtop = vargvName.offsetTop;
                    while (vargvName = vargvName.offsetParent) 
                    {
                        curleft += vargvName.offsetLeft;
                        curtop += vargvName.offsetTop;
                    }
                }
                var varFactor=0;
//                if (navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
//                    varFactor=1;
//                else
//                    varFactor=-1;
                varTable.style.position="static";
                varTable.style.position="absolute";
                varTable.style.top = String(curtop+varFactor)+"px";
                varTable.style.left = String(curleft+varFactor)+"px";
                varTable.style.width=String(parseInt(gvName.style.width))+"px";
                varTable.style.display = "inline";
            }
        }
    }
    catch (ex)
    {
        return false;
    }
}
//ContextMenu
function pShowContextMenu(e,CheckBox)
{
    document.onclick=function(){pHideContextMenu();};
    if (CheckBox==false)
    {
        document.getElementById('mnuDeSelectAll').style.display='none';
        document.getElementById('mnuSelectAll').innerHTML='&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Apply To All';
    }
    else
    {
        document.getElementById('mnuDeSelectAll').style.display='';
        document.getElementById('mnuSelectAll').innerHTML='&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select All';
    }
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
    var SelectAllObj = new Object();
    SelectAllObj = document.getElementById("divSelectOptions");
    var frameObj=document.getElementById("iframeTop");
    var xPosition=cursor.x;
    var yPosition=cursor.y;
    SelectAllObj.style.position="absolute";
    SelectAllObj.style.top = String(yPosition)+"px";
    SelectAllObj.style.left = String(xPosition)+"px";
    SelectAllObj.style.display = "inline";
    frameObj.style.position="absolute";
    frameObj.style.top = String(yPosition)+"px";
    frameObj.style.left = String(xPosition)+"px";
    frameObj.style.display = "inline";
    frameObj.style.width=SelectAllObj.offsetWidth;
    frameObj.style.height=SelectAllObj.offsetHeight;
    return false;
}
function pHideContextMenu()
{
    document.getElementById('divSelectOptions').style.display='none';
    document.getElementById("iframeTop").style.display='none';
}
////****Senthil(09.08.2011)******///////////////
function pReturnSingleValueWin(strQry)
{
    try
    {
        RequestArray.length=0;
        RequestArray.push("pReturnSingleValue(\"" + strQry + "\")");
        varAction='ReturnSingleValue';
        var varClTime=new Date();
        var requestUrl = "GridServlet.aspx?StrQuery=" + encodeURIComponent(strQry) + "&pAction=ReturnSingleValue&DtTime="+varClTime+"&TypeID=ReturnSingleValueWin";
        var responseStream=getAjaxInfo(requestUrl);
        var varAction=eval("(responseStream)");
        return varAction;
    }
    catch (ex)
    {
        return false;
    }
}
////********************/////////////////////
function  pDisplayMessageclient(strType,strMessage,StrLabel)
  {  var varStr;
        if (strType == "1")
        {  if (StrLabel == "")
            {   if (strMessage == "1")
                {  alert("You Don't Have Permission To Create");
                   return false;   
                }
                if (strMessage == "2")
                {  alert("You Don't Have Permission To Edit");
                   return false;     
                }
                if (strMessage == "3")
                {   alert("You don't Have Permission To Delete");
                    return false;
                } 
                if (strMessage == "4")
                {    alert('Nothing to Save'); 
                    return false;
                }  
                if (strMessage == "5")
                { varStr='Do You Want To Delete?'
                  return varStr;
                }
                
                if (strMessage == "6")
                {    alert('Priority Should Be Greater Than Zero'); 
                    return false;
                } 
                if (strMessage == "18")
                { 
                  varStr='Do You Want To Save?'
                  return varStr;
                }
                if(strMessage=="12")
                {  alert("There was a problem retrieving data from the server.");
                    return false;
                }  
                if (strMessage == "16")
                { alert('Please Select JPG,GIF,JPEG Format Photos Only');
                   return;
                } 
                if (strMessage == "17")
                { alert('Invalid Number');
                   return false;
                } 
                if (strMessage == "22")
                { alert('Please Click Save Button For Save This Record');
                  return false;                   
                }  
                if (strMessage == "23")
                { alert('Enter Valid Date');
                return false;                   
                }  
                 if (strMessage == "24")
                {  alert("Saved Successfully");
                   return false;   
                }
                if (strMessage == "25")
                {  alert("Updated Successfully");
                   return false;   
                }  
                if (strMessage == "26")
                {  alert("Deleted Successfully");
                   return false;   
                }  
               if (strMessage == "27")
                {  alert("Data Is In Use");
                   return false;   
                }  
               if (strMessage == "28")
                {  alert("Please Enter Any Amount");
                   return false;   
                }  
                
               if (strMessage == "29")
                { varStr='Do You Want To Cancel This Record?'
                  return varStr;
                }
                
                if (strMessage == "30")
                { alert("You Cannot Cancel This Record");
                   return false;   
                }  
                if (strMessage == "31")
                { alert("You Cannot Modify This Record");
                   return false;   
                }  
            
               if (strMessage == "32")
                { alert("Please Enter Correct Amount");
                   return false;   
                } 
                
                   
             if (strMessage == "1015_1")
                { varStr='Fee Amount is Excess, Do You want To Save ?'
                  return varStr;
                } 
               if (strMessage == "1015_2")
                { alert("Please Enter Pack Date in Pack Date Form");
                   return false;   
                } 
               if (strMessage == "1015_3")
                {  alert("Please check with Pack Date");
                   return false;   
                }
              
               if(strMessage=="318_1")
                {  alert("Please Select at least one Class And Section");
                    return false;
                }     
                                   
                //For Student Drop Out Details(Added By Tinu)
                if(strMessage=="311_1")
                {
                    alert("You Do Not have Permission To Do Dropout");
                    return false;
                }  
                if(strMessage=="311_2")
                {
                    alert("You Do Not Have Permission To Modify");
                    return false;
                }   
                if(strMessage=="311_3")
                {
                    alert("You Do Not Have Permission To Readmit");
                    return false;
                }           
                if(strMessage=="310_1")
                {
                    alert("You Do Not have Permission To Issue TC");
                    return false;
                }    
                
                if (strMessage == "20")
                {  
                //varStr=StrLabel + " Does Not Exist";
                 alert("Please Enter Valid Time  [hh:mm] ");
                    return ;
                }
                if (strMessage == "21")
                {  alert("You Don't Have Permission");
                   return false;     
                }    
                //For Student Promotion
                if(strMessage=="309_1")
                {
                    alert("You Don't Have Permission For Promotion");
                    return false;
                }    
                if(strMessage=="309_2")
                {
                    alert("Please Select A Student To Promote");
                    return false;
                }
                 //For Academic Session Master
                if(strMessage=="101_1")
                {
                    alert("Session Start Date Should be lesser than Session End Date");
                    return false;
                } 
                if(strMessage=="101_2")
                {
                    alert("Academic Session Not Matching With Session Start Date");
                    return false;
                } 
                //For Change Password
                if(strMessage=="128_1")
                {
                    alert("All the fields are required");
                    return false;
                } 
                if(strMessage=="128_2")
                {
                    alert("Password must be alteast 5 characters long");
                    return false;
                }   
                if(strMessage=="128_3")
                {
                    alert("New Password & Confirm New Password do not match");
                    return false;
                } 
                //For User Management
                if(strMessage=="129_1")
                {
                    alert("Sorry, an error Occured");
                    return false;
                }  
                if(strMessage=="129_2")
                {
                    alert("Password and Confirm Password should be same");
                    return false;
                } 
                if(strMessage=="129_3")
                {
                    alert("Assign atleast one option for the User");
                    return false;
                }  
                if(strMessage=="129_4")
                {
                    alert("Assign atleast one school for the User");
                    return false;
                } 
                 if (strMessage == "504_1")
                { 
                    alert("Please Select Any Row In Grid");
                    return false;
                }  
                //For Fee Group Master
                if(strMessage=="1004_1")
                {
                    alert("Assign atleast one Class & Section for the Fee Group");
                    return false;
                } 
                //For Report Type Master
                if(strMessage=="1030_1")
                {
                    alert("Select AtLeast One Fee Head");
                    return false;
                } 
                //For Fee Transfer
                if(strMessage=="1013_1")
                {
                    alert("Select Atleast One Fee Master");
                    return false;
                }  
                 if(strMessage=="1017_2")
                { 
                    alert("Concession Amount Should Not Be Greater Than Structure Amount") ;                                 
                    return false;
                }
                 if(strMessage=="1017_3")
                { 
                    alert("Concession Already Assigned To This FeeHead ") ;                                 
                    return false;
                }
                 if(strMessage=="1032_1")
                {
                    alert("From Date Must Be Less Than To Date");
                    return false;
                } 
                  if(strMessage=="1032_2")
                {
                    alert("To Date Must Be Greater Than From Date");
                    return false;
                }   
                // ClassWise Subject Assigner
                
                if(strMessage == "1118_1")
                {
                    alert("Mark Entry Exists");
                }
                if(strMessage == "1118_2")
                {
                    alert("Attendance Entry Exists");
                }
                if(strMessage == "1118_3")
                {
                    alert("Remark Entry Exists");
                }
                // Exam Group Master
                if(strMessage == "1113_1")
                {
                    alert("Please Select Any Exam");
                }
                if(strMessage == "1113_2")
                {
                    alert("No Class Available For Assigning");
                }
                //ExamGradeMaster
                if(strMessage == "1114_1")
                {
                    alert("Please Enter Upper Limit");
                }
                if(strMessage == "1114_2")
                {
                    alert("Please Enter Lower Limit");
                }
                if(strMessage == "1114_3")
                {
                    alert("Upper Limit Should be Greater than Lower Limit");
                }
               //Update to Next Year
                if (strMessage == "1121_1")
                {  alert("Please Select Atleast One CheckBox");
                   return false;     
                }
                //ExamEntry
                if (strMessage == "1123_1")
                {  alert("Data Doesn't Exist");
                   return false;     
                } 
                if (strMessage == "1123_2")
                {  alert("Mark Entry Locked for the Examination");
                   return false;     
                } 
                //For Fee Reports
                if(strMessage=="1032_1")
                {
                    alert("From Date Must Be Less Than To Date");
                    return false;
                } 
                if(strMessage=="1032_2")
                {
                    alert("Select AtLeast One Fee Installment");
                    return false;
                }        
                if(strMessage == "816_2")
                {
                    alert("Please Check The Date (Expiry date Should be greater then Issue Date)");
                    return false;
                }                           
                //For Fee Reports
                if(strMessage=="1032_1")
                {
                    alert("From Date Must Be Less Than To Date");
                    return false;
                } 
                if(strMessage=="1032_2")
                {
                    alert("Select AtLeast One Fee Installment");
                    return false;
                }
                
                // NEW ADDED
                
                //Staff History
                if (strMessage == "1401_2")
                {  
                    alert("Effective Date Must Be Greater than Date of Appointment");     
                    return false;     
                }                    
                 // PRL Pay Group/Band History
                
                if (strMessage == "1405_1")
                {  
                    alert("Effective Date Must Be Greater than Date of Appointment");     
                    return false;     
                } 
                if(strMessage == "1405_2")
                {
                    alert('Date Should be Greater than Date of Appointment and Less than First Salary Date');
                    return false;
                }
                if(strMessage == "1405_3")
                {
                    alert("Effective Date Already Exists");
                    return false;
                }        
                // PRL Pay Increment History
                
                if (strMessage == "1406_1")
                {  
                    alert("Increment date must be greater than basic date"); 
                    return false;     
                } 
                if(strMessage == "1406_2")
                {
                    alert("Basic from date should be greater than date of appointment and less than first salary date");
                    return false;
                }
                if(strMessage == "1406_3")
                {
                    alert("Basic from date already exists");
                    return false;
                }
                // PRL Pay Head Master
                if(strMessage == "1602_1")
                {
                    alert("This Pay Head No Longer Exist in the Table");
                }
                if(strMessage == "1602_2")
                {
                    alert("Pay Head Name Already Existing");
                }
                if(strMessage == "1602_3")
                {
                    alert("Priority Already Existing");
                }
                if(strMessage == "1602_4")
                {
                    alert("System Heads You Can't Delete");
                }
                if(strMessage == "1602_5")
                {
                    alert("You Can't Delete");
                }
                      
                //For Staff Leave Forms
                if (strMessage == "1500")
                {  alert("Please Enter the valid Date [Date Format dd/MM/yyyy]");     
                   return false;     
                }
                if (strMessage == "1504_1")
                {  alert("Leave Start Date Should be less than Leave End Date");     
                   return false;     
                } 
                if (strMessage == "1504_2")
                {  alert("Leave Period should not greater than One year");     
                   return false;     
                } 
                if (strMessage == "1509_1")
                {  alert("Please Select Any Leave Date");     
                   return false;     
                } 
                if (strMessage == "1509_2")
                {  alert("Leave Entry Already Exists in this Date");     
                   return false;     
                } 
                if (strMessage == "1509_3")
                {  alert("Leave not Available for this Employee");     
                   return false;     
                } 
                if (strMessage == "1509_4")
                {  alert("Leave Entry Exceeds available Leaves");     
                   return false;     
                } 
                if(strMessage=="202_1")
                {
                    alert("Please Select Fee Group");
                    return false;
                }  
              //Reservation
                if(strMessage=="1247_1")
                {   alert("Please Select Correct Title");                                 
                    return false;
                }
                if(strMessage=="1247_2")
                {   alert('Reserved Date Should not Less Than Todays Date');                    
                    return false;
                }
               if(strMessage=="1247_3")
                {   alert ('Reservation Successfull.You Cannot Modify This Record');                 
                    return false;
                }
                if(strMessage=="1247_4")
                {  alert("Reservation Limit Is Not Assigned For This Collection");               
                    return false;
                }
               if(strMessage=="1247_5")
                {  alert('Your Limit is Over For This Collection');           
                    return false;
                }
               //Maintence 
                if (strMessage == "1250_1")
                { varStr='Vendor does not Exists,Do You want to create now?  '
                  return varStr;
                }
                if(strMessage=="1250_2")
                {   alert('Please Enter Acession Code and Press Enter');
                    return false;
                }
                if(strMessage=="1250_3")
                {   alert('Please Enter Maintenace Memo Number');     
                    return false;
                }
                if(strMessage=="1250_4")
                {   alert('Maintenace Memo Number Exists,Please enter another Memo Number');     
                    return false;
                } 
               if(strMessage=="1250_5")
                {   alert('Please Tick CheckBox'); 
                    return false;
                } 
                if(strMessage=="1250_6")
                {   alert('Please Tick CheckBox'); 
                    return false;
                } 
               if(strMessage=="1250_7")
                {  alert('Return Date Should not Less Than Issue Date');
                    return false;
                } 
               if(strMessage=="1250_8")
                {   alert('Please Click New Button');          
                    return false;
                } 
              if(strMessage=="1250_9")
                {   alert('Please Enter The Acession Code Or Title');           
                    return false;
                } 
             //Issue
               if(strMessage=="1248_1")
                {   alert('Collection Not Exists');           
                    return false;
                } 
                if(strMessage=="1248_2")
                {   alert('Collection Already Withdrawn');           
                    return false;
                }
               if(strMessage=="1248_3")
                {   alert('Collection Already Issued');           
                    return false;
                }
             if(strMessage=="1248_4")
                {  alert("This Collection Is Issued For Maintenance So Cannot Be Issued"); 
                    return false;
                } 
              if(strMessage=="1248_5")
                {   alert("Issue Limit Is Not Assigned For This Collection");
                    return false;
                }                
              if(strMessage=="1248_6")
                {   alert('Issue Limit Exceeds');     
                    return false;
                }    
              if(strMessage=="1248_7")
                {   alert("Transaction Cannot Be Deleted As Return Is Done !!"); 
                    return false;
                }   
               if(strMessage=="1248_8")
                {    alert('Select Any One');  
                    return false;
                }
              if(strMessage=="1248_9")
                {  alert('First Select/Enter Any Member');    
                    return false;
                } 
              if(strMessage=="1248_10")
                {    alert('No Collection To Be Issued');     
                    return false;
                }
             if(strMessage=="1248_11")
                {   alert('This Collection Is Already Selected');        
                    return false;
                }  
                
             ///Return
               if(strMessage=="1249_1")
                {   alert('No Collection For Returning');      
                    return false;
                }  
                
                if(strMessage=="1249_2")
                {    alert('Select AtLeast One Collection For Return!!');    
                    return false;
                } 
                
            ///News subscription
              if(strMessage=="1244_1")
                {    alert("Select The Newspaper"); 
                    return false;
                }  
                
                if(strMessage=="1244_2")
                {   alert("Subscription End Date Must Be Greater Than Subscription Start Date");    
                    return false;
                }  
             //Student transfer   
               if (strMessage == "203_1")
                { alert("Select AtLeast One Student For Transfer!!");
                  return false; 
                } 
               if (strMessage == "203_2")
                {  alert("Please Chose One Field To Display!!");
                  return false; 
                } 
               //Student Enquiry English
               if(strMessage=="201_1")
                {   varStr="Do You Want To Register The Student?";
                    return varStr;
                } 
               if (strMessage == "201_2")
                {  alert("Student Already Registered in School So Modification Not Allowed");
                  return false; 
                }                     
                if(strMessage=="202_2")
                {
                    alert("Please Enter The Enquiry Number/Select Name And Press The Enter Key");
                    return false;
                } 
                
                if (strMessage == "33")
                { varStr='Do You Want To Re-Enter This Acquisition?'
                  return varStr;
                } 
                if (strMessage == "34")
                { varStr='Do You Want To Withdraw This Acquisition?'
                  return varStr;
                } 
                if (strMessage == "35")
                { varStr='Source does not Exists,Do You want to create now?'
                  return varStr;
                } 
                if (strMessage == "36")
                { varStr='Publisher does not Exists,Do You want to create now?'
                  return varStr;
                } 
                if (strMessage == "37")
                { varStr='Author does not Exists,Do You want to create now?'
                  return varStr;
                } 
                
                if (strMessage == "38")
                { alert("Delete Not Allowed As Periodical Is Issued!!");
                  return false;   
                } 
                if (strMessage == "39")
                { alert("Delete Not Allowed As Periodical Is Withdrawn!!");
                  return false;   
                } 
                if (strMessage == "40")
                { alert("This Collection Is Issued For Maintenance So Cannot Be Issued");
                  return false;   
                } 
                if (strMessage == "41")
                {  alert("Edit Not Allowed As Periodical Is Issued!!");
                  return false;   
                } 
               if (strMessage == "42")
                {  alert("Edit Not Allowed As Periodical Is Withdrawn!!");
                  return false;   
                }
                if (strMessage == "43")
                {  alert("Withdrawn Not Allowed As Periodical Is Issued !!");
                  return false;   
                }  
                 if (strMessage == "44")
                {  alert("Withdrawn Not Allowed As Periodical Is Issued For Maintenance!!");
                  return false;   
                } 
                if (strMessage == "45")
                {  alert('Accession Code Already Exist Please Enter another Accession code');
                  return false;   
                } 
                if (strMessage == "46")
                {  alert('Do You Want To Save This Author');
                  return false;   
                } 
                if (strMessage == "47")
                {  alert('Please Save the EBook');
                  return false;   
                } 
                if (strMessage == "48")
                {  alert('Please Select Any Value');
                  return false;   
                } 
                
                 if (strMessage == "49")
                { varStr='Periodical does not Exists,Do You want to create now?'
                  return varStr;
                } 
                 if (strMessage == "50")
                {  alert('Accession No. not Exist Craete New');
                  return false;   
                } 
                 if (strMessage == "51")
                {  alert('Record Not Found');
                  return false;   
                } 
                if (strMessage == "52")
                { varStr='Name Not Exists,Do You Want To Create New?'
                  return varStr;
                } 
                 if (strMessage == "53")
                {  alert('Edit Not Allowed As Media Is Issued!!');
                  return false;   
                } 
                 if (strMessage == "54")
                {  alert('Edit Not Allowed As Media Is Withdrawn!!');
                  return false;   
                }
                 if (strMessage == "55")
                {  alert('Withdrawn Not Allowed As Media Is Issued!!!!');
                  return false;   
                }  
                 if (strMessage == "56")
                {  alert('Delete Not Allowed As Media Is Issued!!');
                  return false;   
                } 
                 if (strMessage == "57")
                {  alert('Delete Not Allowed As Media Is Withdrawn!!');
                  return false;   
                }

                if (strMessage == "58")
                { alert('Edit Not Allowed As Album Is Issued!!');
                  return false;   
                }
                if (strMessage == "59")
                {  alert('Edit Not Allowed As Album Is Withdrawn!!');
                  return false;   
                }
                if (strMessage == "60")
                {  alert('Withdrawn Not Allowed As Album Is Issued!!');
                  return false;   
                }
                if (strMessage == "61")
                { alert('Delete Not Allowed As Album Is Issued!!');
                  return false;   
                }
                if (strMessage == "62")
                {  alert('Delete Not Allowed As Album Is Withdrawn!!');
                  return false;   
                }
                if (strMessage == "63")
                {  varStr='Photo Does Not Exists,Do You Want To Create New ?'
                  return varStr; 
                }
                 if (strMessage == "64")
                {  alert('Number Of Photos Must Be Less Than The Max Capacity');
                  return false;   
                }
                  if (strMessage == "64")
                {  alert('Add No. Of Photos First');
                  return false;   
                }
                  if (strMessage == "65")
                {  alert('Album Capacity Exceeds!!');
                  return false;   
                }
                  if (strMessage == "66")
                {  alert('Select The Photo To Be Removed');
                  return false;   
                }
                 if (strMessage == "67")
                {  alert('First Remove All The Photographs !!!');
                  return false;   
                } 
                if (strMessage == "68")
                {  alert('First Remove All The Photographs !!!');
                  return false;   
                }
                 if (strMessage == "69")
                {  alert('Invalid Email');
                  return false;   
                }
                if (strMessage == "70")
                {  varStr='Do You Want To Renew This Membership?'
                  return varStr; 
                }
                if (strMessage == "71")
                {  alert("Select AtLeast One Student For Grant!!");
                   return false;    
                }
                if (strMessage == "72")
                {  alert("Select Student For Delete!!");
                   return false;    
                }
                 if(strMessage=="201_1")
                {   varStr="Do You Want To Register The Student?";
                    return varStr;
                } 
               if (strMessage == "201_2")
                {  alert("Student Already Registered in School So Modification Not Allowed");
                  return false; 
                }                     
                if(strMessage=="202_2")
                {
                    alert("Please Enter The Enquiry Number/Select Name And Press The Enter Key");
                    return false;
                } 
                
            }            
            
                    
            else
            { 
                if (strMessage == "7")
                {  alert("Please Enter "  + StrLabel);
                    return;
                } 
                if (strMessage == "8")
                {  alert("Please Select "  + StrLabel);
                    return;
                } 
                if (strMessage == "9")
                {  
                varStr="**Select "  + StrLabel+"**";                
                    return varStr;
                } 
                if (strMessage == "10")
                {                  
                    alert(StrLabel + " Already Exists");
                    return;
                } 
                if (strMessage == "11")
                {                  
                    alert(StrLabel + " Does Not Exist");
                    return ;
                }                
                if(strMessage=="13")
                {
                    alert("Please Enter "+StrLabel+" & Press The Enter Key");
                    return;
                }
                if(strMessage=="14")
                {
                    alert("Please Enter "+StrLabel+" In [dd/MM/yyyy] Format");
                    return;
                }
                if(strMessage=="15")
                {
                    alert(StrLabel+" Should Be Greater Than Admission Date");
                    return;
                }
                if(strMessage=="17")
                {
                    alert("Please Enter Valid "+StrLabel);
                    return;
                }
                 if (strMessage == "18")
                {
                 alert("Select Any "  + StrLabel);
                  return;
                }   
                 if (strMessage == "19")
                {
                  alert(StrLabel +  "Does Not Exists,Please Select Correct "  + StrLabel);
                  return;
                }  
                if (strMessage == "307_1")
                { alert("Please Create "+StrLabel+" For This Class");
                  return false;
                } 
                if (strMessage == "307_2")
                { alert("You Cannot Modify " + StrLabel);
                  return false;
                }      
                if (strMessage == "21")
                {  alert("إخع [خىطف أشرث ؛ثقةهسسسهخى");
                   return false;     
                }     
                 if(strMessage=="311_5")
                {
                    varStr="Do You Want To Readmit "+StrLabel+"?";
                    return varStr;
                } 
                if(strMessage=="311_6")
                {
                    varStr="Do You Want To Delete "+StrLabel+"?";
                    return varStr;
                }   
                
                if(strMessage=="505_1")
                {
                    alert(""+StrLabel+" Already Paid");
                    return false;   
                } 
                if (strMessage == "29")
                {                   
                    varStr = " ** Select " + StrLabel + " ** ";                   
                    return varStr;
                } 
                
                if(strMessage=="1017_1")
                {
                    alert(""+StrLabel+" Should be Leass Than 100");
                    return false;
                }
                if(strMessage=="202_3")
                {
                    alert("Date Should Be Greater Than Or Equal To Date Of Enquiry");
                    return false;
                }
            } 
        }
        else if (strType == "2")        
        {  if (StrLabel == "")
            {   if (strMessage == "1")
                {  alert("إخع [خىطف أشرث ؛ثقةهسسهخى لإخ {قثشفث");
                   return false;   
                }
                if (strMessage == "2")
                { alert("إخع [خىطف أشرث ؛ثقةهسسهخى لإخ ُيهف");                     
                   return false;     
                }
                if (strMessage == "3")
                {  alert("إخع [خىطف أشرث ؛ثقةهسسهخى لإخ {[ثمثفث");                  
                    return false;
                } 
                if (strMessage == "4")
                {    alert('آخفاهىل لإخ ٍشرث'); 
                    return false;
                }  
                if (strMessage == "5")
                {   // alert('[خ إخع ً#ًىشف لإخ [ُمثفث؟?'); 
                      varStr='[خ إخع ً#ًىشف لإخ [ُمثفث؟?'
                      return varStr;
                }
               if (strMessage == "6")
                {    alert('؛قهخقهفغ ٍاخعمي لآث لأقثشفثق فاثى ~صثقخ'); 
                    return false;
                }
                if (strMessage == "18")
                { 
                  varStr='[خ إخع ًشىف لإخ ٍشرث?'
                  return varStr;
                }
                  if(strMessage=="12")
                {
                    alert("لإاثقث صشس ش حقخلامثة قثفقهثرهىل يشفش بقخة فاث سثقرثقز");
                    return false;
                } 
                if (strMessage == "16")
                { alert('؛مشثسث ٍثمثؤف ـ؛لأولأ÷]ووـ؛ُلأ ]خقةشف ؛اخفخس ×ىمغ');
                   return;
                }
                if (strMessage == "17")
                { alert('÷ىرشمهي آعةلاثق');
                   return;
                }                 
                if (strMessage == "21")
                { 
//                    alert("You Don't Have Permission");
                   alert("إخع [خىطف أشرث ؛ثقةهسسهخى");
                   return false;     
                } 
                 if (strMessage == "22")
                { alert('؛مشثسث {مهؤن ٍشلرث لآعففخى لإخ سشرث لإاهس ٌثؤخقي');
                  return false;                   
                }  
                if (strMessage == "23")
                { alert('ُُىفثق }شمهي [شفث');
                return false;                   
                }    
                 if (strMessage == "24")
                {  alert("يبليبل يبليب يبل يب");
                   return false;   
                }
                if (strMessage == "25")
                {  alert(" يبليبل  يبليبليبليب");
                   return false;   
                }  
                if (strMessage == "26")
                {  alert("يبلي  يبليبليبليب");
                   return false;   
                }  
               if (strMessage == "27")
                {  alert("بيليب يبل يبل يبل");
                   return false;   
                }
               if (strMessage == "28")
                {  alert("؛مثشسث ُىفثق ِىغ ِةخعىف");
                   return false;   
                }    
                if (strMessage == "29")
                { varStr='؛مثشسث ُىفثق ِىغ ِةخعىف?'
                  return varStr;
                }
               if (strMessage == "30")
                { alert("؛مثشسث ُىفثق ِىغ ِةخعىف");
                  return varStr;
                }
                if (strMessage == "31")
                { alert("إخع {شىىخف ’خيهبغ لإاهس ٌثؤخقي");
                   return false;   
                }    
                if (strMessage == "31")
                { alert("يبليبليب باليبلبي t");
                   return false;   
                }  
               if (strMessage == "32")
                { alert("؛مثشسث ُىفثق {خخقثؤف ِةخعىف");
                   return false;   
                }    
               if (strMessage == "1015_1")
                { varStr=']ثث ِةخعىف ُءؤثسس [خ إخع ًشىف لإخ ٍشرث?'
                  return varStr;
                }  
               
                
               if (strMessage == "1015_2")
                { alert("؛مثشسث ُىفثق {خخقثؤف ِةخعىف");
                   return false;   
                } 
               if (strMessage == "1015_3")
                {  alert("؛مثشسث ُىفثق {خخقثؤف ِةخعىف");
                   return false;   
                }
            
                
               if(strMessage=="318_1")
                {  alert("؛مشثسث ٍثمثؤف ِف /شثسف ×ىث {مشسس ِىي ٍثؤفهخى ");
                    return false;
                }    
                 
                       
                //For Student Drop Out Details(Added by Tinu) 
                if(strMessage=="311_1")
                {
                    alert("إخع [خ آخف اشرث ؛ثقةهسسهخى لإخ [خ [قخحخعف");
                    return false;
                } 
                if(strMessage=="311_2")
                {
                    alert("إخع [خ آخف أشرث ؛ثقةهسسهخى لإخ ’خيهبغ");
                    return false;
                }
                if(strMessage=="311_3")
                {
                    alert("إخع [خ آخف أشرث ؛ثقةهسسهخى لإخ ٌثشيةهف");
                    return false;
                }       
                if(strMessage=="310_1")
                {
                    alert("لإ{ [شفث ٍاخعمي لآث لأقثشفثق لإاشى ِيةهسسهخى[شفث");
                    return false;
                }                   
                 if (strMessage == "20")
                {  
                //varStr=StrLabel + " Does Not Exist";
                 alert("[hh:mm] ؛مثشسث ُىفثق }شمهي فهةث ");
                    return ;
                } 
                //For Student Promotion
                if(strMessage=="309_1")
                {
                    alert("إخع [خىطف أشرث ؛ثقةهسسهخى ]خق ؛قخةخفهخى");
                    return false;
                }  
                if(strMessage=="309_2")
                {
                //alert("Please Select A Student To Promote");
                    alert("؛مثشسث ٍثمثؤف ِ ىٍفعيثىف لإخ ؛قخةخفث");
                    return false;
                }   
                //For Academic Session Master
                if(strMessage=="101_1")
                {
                    alert("ٍثسسهخى ٍفشقف [شفث ٍاخعمي لاث مثسسثق فاشى ٍثسسهخى ُىي [شفث");
                    return false;
                } 
                if(strMessage=="101_2")
                {
                    alert("ِؤشيثةهؤ ٍثسسهخى آخف ’شفؤاهىل ًهفا ٍثسسهخى ٍفشقف [شفث");
                    return false;
                } 
                //For Change Password
                if(strMessage=="128_1")
                {
                    alert("ِمم فاث بهثميس شقث قثضعهقثي");
                    return false;
                }
                if(strMessage=="128_2")
                {
                    alert("؛شسسصخقي ةعسف لاث شفمثشسف 5 ؤاشقشؤفثقس مخىل");
                    return false;
                } 
                if(strMessage=="128_3")
                {
                    alert("آثصة ؛شسسصخقي & {خىبهقة ؛شسسصخقي يخ ىخف ةشفؤا");
                    return false;
                } 
                 //For User Management
                if(strMessage=="129_1")
                {
                    alert("ٍخققغو شى ثققخق ×ؤؤعقثي");
                    return false;
                } 
                if(strMessage=="129_2")
                {
                    alert("؛شسسصخقي شىي {خىبهقة ؛شسسصخقي ساخعمي لاث سشةث");
                    return false;
                } 
                if(strMessage=="129_3")
                {
                    alert("ِسسهلى شفمثشسف خىث خحفهخى بخق فاث ‘سثق");
                    return false;
                }   
                if(strMessage=="129_4")
                {
                    alert("ِسسهلى شفمثشسف خىث سؤاخخم بخق فاث ‘سثق");
                    return false;
                } 
                 if (strMessage == "504_1")
                { 
                    alert("؛مثشسث ٍثمثؤف شىغ ٌخص هى لقهي");
                    return false;
                }  
                //For Fee Group Master
                if(strMessage=="1004_1")
                {
                    alert("ِسسهلى شفمثشسف خىث {مشسس & ٍثؤفهخى بخق فاث ]ثث لأقخعح");
                    return false;
                }  
                //For Report Type Master
                if(strMessage=="1030_1")
                {
                    alert("ٍثمثؤف ِفمثشسف ×ىث ]ثث أثشي");
                    return false;
                }                 
                //For Fee Transfer
                if(strMessage=="1013_1")
                {
                    alert("ٍثمثؤف ِفمثشسف ×ىث ]ثث ’شسفثق");
                    return false;
                } 
                 if(strMessage=="1017_2")
                {   
                    alert("{خىؤثسسهخى ِةخعىف ٍاخعمي آخف لآث لأقشفثق لإاشى ٍفقعؤفعقث ِةخعىف") ;                                 
                    return false;
                } 
                  if(strMessage=="1017_3")
                { 
                    alert("{خىؤثسسهخى ِمقثشيغ  ِسسهلىثي لإخ لإاهس ]ثثأثشي ") ;                                 
                    return false;
                } 
                
                if(strMessage=="1032_1")
                {
                    alert("]قخة [شفث ٍاخعمي لآث /ثشسس لإاشى لإخ [شفث");
                    return false;
                } 
                   if(strMessage=="1032_2")
                {
                    alert("لإخ [شفث ’عسف لآث لأقثشفثق لإاشى ]قخة [شفث");
                    return false;
                }           
                
                // ClassWise Subject Assigner
                
                if(strMessage == "1118_1")
                {
                    //alert("Mark Entry Exists");
                    alert("ةشقن ثىفقغ ثءهسفس");
                }
                if(strMessage == "1118_2")
                {
                    //alert("Attendance Entry Exists");
                    alert("شففثىيشىؤث ثىفقغ ثءهسفس");
                }                    
                if(strMessage == "1118_3")
                {
                    //alert("Remark Entry Exists");
                    alert("ٌقثةشقن ثىفقغ ثءهسفس");
                }
                // Exam Group Master
                if(strMessage == "1113_1")
                {
                    //alert("Please Select Any Exam");
                    alert("حمثشسث سثمثؤف شىغ ُءش");
                }
                if(strMessage == "1113_2")
                {
                    //alert("No Class Available For Assigning");
                    alert("ىخ ؤمشسس شرشهمشلامث بخق ثيهفهىل");
                }
                //ExamGradeMaster
                if(strMessage == "1114_1")
                {
                    //alert("Please Enter Upper Limit");
                   alert("حمثشسث ثىفثق ‘ححثق /هةهف");
                }
                if(strMessage == "1114_2")
                {
                    //alert("Please Enter Lower Limit");
                    alert("حمثشسث ثىفثق مخصثق مهةهف");
                }
                if(strMessage == "1114_3")
                {
                    //alert("Upper Limit Should be Greater than Lower Limit");
                    alert("عححثق مهةهف ساخعمي لاث لقثشفثق فااشى مخصثق مهةهف");
                }
                //Exam Mark Entry
                if(strMessage == "1123_1")
                {
                    //alert("Data Doesn't Exist");
                    alert("يشفش يخثسىطف ثءهسف");
                }
                if(strMessage == "1123_2")
                {
                    //alert("Mark entry locked for the exam");
                    alert("ةشقن ثىفقغ مخؤنثي بخق فاث ثءشة");
                }
                  //For Fee Reports
                if(strMessage=="1032_1")
                {
                    alert("]قخة [شفث ’عسف لآث /ثسس لإاشى لإخ [شفث");
                    return false;
                }  
                if(strMessage=="1032_2")
                {
//                    alert("Select AtLeast One Fee Installment");
                     alert("ٍثمثؤف ِفمثشسف ×ىث ]ثث ÷ىسفشممةثىف");
                    return false;
                }
                 if(strMessage=="201_1")
                {   varStr="Do You Want To Register The Student?";
                    return varStr;
                } 
               if (strMessage == "201_2")
                {  alert("Student Already Registered in School So Modification Not Allowed");
                  return false; 
                }                     
                if(strMessage=="202_2")
                {
                    alert("Please Enter The Enquiry Number/Select Name And Press The Enter Key");
                    return false;
                }                 
            }            
                    
            else
            {
             if (strMessage == "7")
                {  alert("؛مثشسث ُىفثق "  + StrLabel);
                    return;
                } 
                if (strMessage == "8")
                {  alert("ٍثمثؤف ٍثمثؤف  "  + StrLabel);
                    return;
                } 
                 if (strMessage == "9")
                {  
                varStr="**ٍُمثؤف  "  + StrLabel+"**";                
                    return varStr;
                } 
                if (strMessage == "10")
                {                  
                     alert(StrLabel + " ِمقثشيغ ُءهفس");
                    return ;
                }
                if (strMessage == "11")
                {                  
                  alert(StrLabel + " [خثس ىخف ُءهفس");                
                    return ;
                }
                //Added by Tinu
                if(strMessage=="13")
                {
                    alert("؛مثشسث ُىفثق "+StrLabel+" & ؛قثسس لإاث ُىفثق ،ثغ");
                    return;
                }
                if(strMessage=="14")
                {
                    alert("؛مثشسث ُىفثق "+StrLabel+" ÷ى جييظ’’ظغغغد ]خقةشف");
                    return;
                }
                if(strMessage=="15")
                {
                    alert(StrLabel+" ٍاخعمي لآث لأقثشفثق لإاشى ِيةهسسهخى[شفث");
                    return;
                }
                if(strMessage=="17")
                {                 
                    alert("؛مثشسث ُىفثق }شمهي  "+StrLabel);
                    return;
                }
                 if (strMessage == "18")
                {
                 alert(" ٍثمثؤف ِىغ "  + StrLabel);
                  return;
                }   
                 if (strMessage == "19")
                {
                  alert(StrLabel +  "يخثس ىخف ثءهسفسو؛مشثسث ٍثمثؤف {خققثؤف"  + StrLabel);
                  return;
                }   
                if (strMessage == "307_1")
                { alert("؛مثشسث {قثشفث"+StrLabel+" خق لإاهس {مشسس");
                  return false;
                   
                }             
                if (strMessage == "307_2")
                { alert("يخثس ىخف ثءهسفسو؛مشثسث " + StrLabel);
                  return false;
                }       
                if(strMessage=="311_5")
                {
                    varStr="[خ إخع ًشىف لإخ ٌثشيةهف  "+StrLabel+"?";
                    return varStr;
                } 
                if(strMessage=="311_6")
                {
                    varStr="[خ إخع ًشىف لإخ [ثمثفث   "+StrLabel+"?";
                    return varStr;
                } 
                  if(strMessage=="505_1")
                {
                   alert(""+StrLabel+" ِمقثشيغ ؛شهي");
                   return false;   
                } 
                if (strMessage == "29")
                { 
                     varStr = " ** ٍثمثؤف " + StrLabel + " ** ";                
                    return varStr;
                }
                if(strMessage=="1017_1")
                {
                    alert(""+StrLabel+" ٍاخعمي لآُ /ثسس لإاشى 100");
                    return false;
                } 
              
            } 
        }
  }

  function pFillListBoxBind(ParentObject1, varMinLength, varDesitination, reqURL) {
        try {
            var varClTime = new Date();
            var requestUrl = reqURL + "&DtTime=" + encodeURIComponent(varClTime) + "";

            var responseStream = getAjaxInfo(requestUrl);
            var data = eval("(responseStream)");

            RequestArray.length = 0;
            if (document.getElementById(ParentObject1).value.length < varMinLength) {
                hideLstBox();
                return;
            }
            ListBox = document.getElementById(varDesitination);
            ListBox.length = 10;
            ListBox.length = 0;
            ListBox.disabled = false;
            ParentObject = ParentObject1;
            if (navigator.userAgent.toLowerCase().indexOf("msie") != -1) {
                document.getElementById(ParentObject).onkeydown = function () { selectLst(event); };
                ListBox.onkeydown = function () { selectLst(event); };
                ListBox.onkeyup = function () { displayValueKeyPress(event); };

            }
            else {
                ListBox.setAttribute("onkeydown", "selectLst(event);");
                ListBox.setAttribute("onkeyup", "displayValueKeyPress(event);");
                document.getElementById(ParentObject).setAttribute("onkeydown", "selectLst(event)");
            }
            IFrame.id = "IFrame";
            IFrame.style.zIndex = 999;
            IFrame.style.width = String(parseInt(document.getElementById(ParentObject).style.width)) + "px";
            IFrame.style.height = "";
            IFrame.style.display = 'none';
            var varTable = document.getElementsByTagName("TBODY")[0];
            ListBox.multiple = 'multiple';
            ListBox.style.height = "";
            ListBox.style.width = String(parseInt(document.getElementById(ParentObject).style.width)) + "px";
            ListBox.style.display = 'none';
            ListBox.onclick = function () { displayValue('onclick'); };
            ListBox.onchange = function () { displayValue('onchange'); };
            ListBox.style.fontFamily = document.getElementById(ParentObject).style.fontFamily;
            ListBox.style.fontSize = document.getElementById(ParentObject).style.fontSize;
            ListBox.style.backgroundColor = document.getElementById(ParentObject).style.backgroundColor;
            ListBox.style.color = document.getElementById(ParentObject).style.color;
            ListBox.className = document.getElementById(ParentObject).className;
            ListBox.onfocusout = function () { hideLstBox(); };
            ListBox.style.zIndex = 1000;
            if (document.getElementById('IFrame') == null) varTable.appendChild(IFrame);
            setLoadingPicPosition(ParentObject, '');
            varAction = 'FillListBox';

            var ddlBind = ListBox.id;
            ListBox.length = 0;
            ddlBind.length = 0;
            var arrData = data.split('~');
            var LstWidth = 0;
            if (arrData.length >= 0 && data != "") {
                var optionItem;
                var txt;
                for (var i = 0; i < arrData.length; i++) {
                    txt = arrData[i].split('^');
                    if (LstWidth < txt[0].length) LstWidth = txt[0].length;
                    optionItem = new Option(txt[0], txt[1], false, false);
                    ListBox.options.add(optionItem);
                }
                setPanelPosition(ParentObject, IFrame);
                setPanelPosition(ParentObject, ListBox);
                IFrame.style.display = 'inline';
                if (arrData.length > 9) {
                    LstWidth = LstWidth + 15;
                    ListBox.style.height = "150px";
                    IFrame.style.height = "140px";
                    ListBox.rows = 10;
                }
                else {
                    ListBox.style.height = String(i * 17) + "px";
                    IFrame.style.height = String(i * 16) + "px";
                    if (i == 1) {
                        ListBox.style.height = "25px";
                        IFrame.style.height = "5px";
                    }
                    else if (i == 2) {
                        ListBox.style.height = "45px";
                        IFrame.style.height = "30px";
                    }
                }
                if (document.getElementById('img') != null) document.getElementById('img').style.display = "none";
                return false;
            }
            else {
                IFrame.style.display = 'none'
                ListBox.style.display = 'none';
                if (document.getElementById('img') != null) document.getElementById('img').style.display = "none";
                return false;
            }
            return false;
        }
        catch (ex) {
            return false;
        }
    }
    var GridName;
    function fillGridView(varGridName, reqURL)//pFillListBoxBind(ParentObject1, varMinLength, varDesitination, reqURL)
     {
        try {
             GridName = document.getElementById(varGridName);
            var varClTime = new Date();
            var requestUrl = reqURL + "&DtTime=" + encodeURIComponent(varClTime) + "";
            var responseStream = getAjaxInfo(requestUrl);
            var data = eval("(responseStream)");
            pClearGrid();
            var arrData = data.split('~');
            if (arrData.length > 0 && data != "") {
                for (var i = 0; i < arrData.length; i++) {
                    var varColValue = arrData[i].split('^');
                    for (var j = 0; j < varColValue.length; j++) {

                        if (GridName.rows[i + 1].cells[j].childNodes.length > 1) {
                            if (GridName.rows[i + 1].cells[j].getElementsByTagName('input').length > 0) {
                                if (GridName.rows[i + 1].cells[j].getElementsByTagName('input')[0].type == 'checkbox') {
                                    if (varColValue[j].toLowerCase() == "false")
                                        GridName.rows[i + 1].cells[j].getElementsByTagName('input')[0].checked = false;
                                    else
                                        GridName.rows[i + 1].cells[j].getElementsByTagName('input')[0].checked = true;
                                }
                                else {
                                    GridName.rows[i + 1].cells[j].getElementsByTagName('input')[0].value = varColValue[j];
                                }
                            }
                            else if (GridName.rows[i + 1].cells[j].getElementsByTagName('select').length > 0) {
                                GridName.rows[i + 1].cells[j].getElementsByTagName('select')[0].value = varColValue[j];
                            }
                            else if (GridName.rows[i + 1].cells[j].getElementsByTagName('TEXTAREA').length > 0) {
                                GridName.rows[i + 1].cells[j].getElementsByTagName('TEXTAREA')[0].value = varColValue[j];
                            }
                        }
                        else
                            GridName.rows[i + 1].cells[j].childNodes[0].nodeValue = varColValue[j];
                    }
                    GridName.rows[i + 1].style.display = '';
                }
            }
        }
        catch (ex) {
            return false;
        }
    }
 