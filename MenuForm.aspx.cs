/*
    Project Name            :   CampusCare
    Client                  :   
    Database                :   SQL Server 2000
    Front-End               :   ASP.NET With C#, Java Script, Ajax
    Reporting Tool          :   Crystal Report 11.0
    Team                    :   Alex,Daison,Garima,Rashmi,Resmi,Sandhya,Senthil,Shiju
    Tables                  :   
    Procedures              :   
    Page Created            :   Alex  
    Codes                   :   Alex
    Testing & Modification  :   Shiju
    Remarks                 :      
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MenuForm : System.Web.UI.Page
{
    CCWeb objCCWeb = new CCWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Write("<script>window.close();window.open('Logon.aspx','_parent');</script>");
            return;
        }
        if (!IsPostBack)
        {

            //SqlConnection conMyConnection = new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));
            //conMyConnection.Open();
            SqlConnection conMyConnection = new SqlConnection(); //new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));
            conMyConnection.ConnectionString = objCCWeb.ReturnConnectionString();
            conMyConnection.Open();
            SqlCommand cmdMyCommand = new SqlCommand("SELECT MM.ModuleName,UM.MenuCaption,LEN(UM.MenuLevel) AS MenuLevel,UM.MenuLinkPage,UM.MenuName FROM MTUserMenuMaster UM INNER JOIN MTUserModuleMaster MM ON MM.ModuleID=UM.ModuleID INNER JOIN MTUserLimitMaster LM ON UM.MenuName = LM.MenuName AND LM.ModuleID=UM.ModuleID AND LM.VisibleOption='Y' AND LM.UID=" + Session["UID"] + " Where UM.MenuName Not in  ('mnuStaffPayInfo', 'mnuStaffOtherInfo')   ORDER BY MM.Priority,MM.ModuleID,RollNumber ", conMyConnection);
            SqlDataReader rdrMyReader = cmdMyCommand.ExecuteReader();
            TreeNode objRootNode, objtreenode, objchildnode1, objchildnode2, objchildnode3;
            objRootNode = new TreeNode("");
            objtreenode = new TreeNode("");
            objchildnode1 = new TreeNode("");
            objchildnode2 = new TreeNode("");
            while (rdrMyReader.Read())
            {
                int intLevel;
                intLevel = Convert.ToInt32(rdrMyReader.GetValue(2).ToString());
                if (intLevel == 0)
                {
                    objRootNode = new TreeNode(rdrMyReader.GetValue(0).ToString(), "", "", "MainForm.aspx", "MainFrame");

                    trvMenu.Nodes.Add(objRootNode);
                }
                if (intLevel == 1)
                {
                    if (rdrMyReader.GetValue(3).ToString() != "")
                        objtreenode = new TreeNode(rdrMyReader.GetValue(1).ToString(), "", "", rdrMyReader.GetValue(3).ToString().Trim() + "?MenuName=" + rdrMyReader.GetValue(4).ToString().Trim(), "MainFrame");
                    else
                        objtreenode = new TreeNode(rdrMyReader.GetValue(1).ToString());
                    objRootNode.ChildNodes.Add(objtreenode);

                }
                else if (intLevel == 2)
                {
                    if (rdrMyReader.GetValue(3).ToString() != "")
                        objchildnode1 = new TreeNode(rdrMyReader.GetValue(1).ToString(), "", "", rdrMyReader.GetValue(3).ToString().Trim() + "?MenuName=" + rdrMyReader.GetValue(4).ToString().Trim(), "MainFrame");
                    else
                        objchildnode1 = new TreeNode(rdrMyReader.GetValue(1).ToString());
                    objtreenode.ChildNodes.Add(objchildnode1);
                }
                else if (intLevel == 3)
                {
                    if (rdrMyReader.GetValue(3).ToString() != "")
                        objchildnode2 = new TreeNode(rdrMyReader.GetValue(1).ToString(), "", "", rdrMyReader.GetValue(3).ToString().Trim() + "?MenuName=" + rdrMyReader.GetValue(4).ToString().Trim(), "MainFrame");

                    else
                        objchildnode2 = new TreeNode(rdrMyReader.GetValue(1).ToString());
                    objchildnode1.ChildNodes.Add(objchildnode2);
                }
                else if (intLevel == 4)
                {
                    if (rdrMyReader.GetValue(3).ToString() != "")
                        objchildnode3 = new TreeNode(rdrMyReader.GetValue(1).ToString(), "", "", rdrMyReader.GetValue(3).ToString().Trim() + "?MenuName=" + rdrMyReader.GetValue(4).ToString().Trim(), "MainFrame");
                    else
                        objchildnode3 = new TreeNode(rdrMyReader.GetValue(1).ToString());
                    objchildnode2.ChildNodes.Add(objchildnode3);
                }

                if (objRootNode.ChildNodes.Count >= 1)
                {
                    objRootNode.SelectAction = TreeNodeSelectAction.Expand;
                }
                if (objtreenode.ChildNodes.Count >= 1)
                {
                    objtreenode.SelectAction = TreeNodeSelectAction.Expand;
                }
                if (objchildnode1.ChildNodes.Count >= 1)
                {
                    objchildnode1.SelectAction = TreeNodeSelectAction.Expand;
                }
                if (objchildnode2.ChildNodes.Count >= 1)
                {
                    objchildnode2.SelectAction = TreeNodeSelectAction.Expand;
                }

            }
            //GetMenuData();
            cmdMyCommand.Dispose();
            rdrMyReader.Close();
            rdrMyReader.Dispose();
            conMyConnection.Close();
            conMyConnection.Dispose();
        }
    }
    //private void GetMenuData()
    //{
    //    SqlConnection conMyConnection = new SqlConnection(); //new SqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));
    //    conMyConnection.ConnectionString = objCCWeb.ReturnConnectionString();
    //    conMyConnection.Open();
    //    DataTable table = new DataTable();
    //    string sql = "Select RollNumber menu_id,MenuCaption1 menu_name,menu_Parent_Id,MenuLinkPage menu_url from MTUserMenuMaster where ModuleID <11 and moduleid not in(4,7,8) ";
    //    //"select menu_id, menu_name, menu_parent_id, menu_url from menuMaster";
    //    SqlCommand cmd = new SqlCommand(sql, conMyConnection);
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(table);
    //    DataView view = new DataView(table);
    //    view.RowFilter = "menu_parent_id is NULL";
    //    foreach (DataRowView row in view)
    //    {
    //        MenuItem menuItem = new MenuItem(row["menu_name"].ToString(), row["menu_id"].ToString());
    //        menuItem.NavigateUrl = row["menu_url"].ToString();
    //        menuBar.Items.Add(menuItem);
    //        AddChildItems(table, menuItem);
    //    }
    //}
    //private void AddChildItems(DataTable table, MenuItem menuItem)
    //{
    //    DataView viewItem = new DataView(table);
    //    viewItem.RowFilter = "menu_parent_id=" + menuItem.Value;
    //    foreach (DataRowView childView in viewItem)
    //    {
    //        MenuItem childItem = new MenuItem(childView["menu_name"].ToString(), childView["menu_id"].ToString());
    //        childItem.NavigateUrl = childView["menu_url"].ToString();
    //        menuItem.ChildItems.Add(childItem);
    //        AddChildItems(table, childItem);
    //    }
    //}

}
