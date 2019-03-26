using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for CCUserFunc
/// </summary>
public class CCUserFunc
{
    protected static int[] intDivisor ={ 10000000, 100000, 1000, 100 };
    protected static string[] strDivisor ={ "Crore", "Lakh", "Thousand", "Hundred" };
    protected static string[] strNumbers ={"Zero","One","Two","Three","Four","Five","Six","Seven","Eight",
                     "Nine","Ten","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen",
                     "Eighteen","Nineteen"};
    protected static string[] strTenNumbers ={ "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    
    public string NumberToWords(string StrInput)
    {
        string[] strArray = StrInput.Split('.');
        if (strArray.Length > 2)
            return "";
        long IntPart;
        int DecPart;
        string strReturn = "";
        try
        {
            if (strArray.Length > 0)
                IntPart = Convert.ToInt64(strArray[0]);
            else
                IntPart = Convert.ToInt64(StrInput);
            if (strArray.Length == 2)
                DecPart = Convert.ToInt32((Convert.ToDecimal(StrInput) - IntPart) * 100);
            else
                DecPart = 0;
            strReturn = IntParttowords(IntPart).Trim();// +" Rupees";
            //strReturn = IntParttowords(IntPart).Trim() + " Rupees";
            if (DecPart >0)
            {
                strReturn = strReturn;// + " and " + DecParttowords(DecPart).Trim() + " Paise";
                //strReturn = strReturn + " and " + DecParttowords(DecPart).Trim() + " Paise";
            }
            strReturn = strReturn + " Only";
        }
        catch
        {
            strReturn = "";
        }


        return strReturn;
    }
    protected string IntParttowords(long IPart)
    {
        string strIPart = "";
        long intDividend;
        long intRemainder;
        long intDiv;
        long intRem;
        for (int i = 0; i < intDivisor.Length; i++)
        {
            intDividend = IPart / intDivisor[i];
            if (intDividend > 0)
            {
                if (intDividend < 100)
                {
                    if (intDividend < 20)
                    {
                        strIPart = strIPart + strNumbers[intDividend] + " ";
                    }
                    else
                    {
                        intDiv = intDividend / 10;
                        if (intDiv > 0)
                            strIPart = strIPart + strTenNumbers[intDiv] + " ";
                        intRem = intDividend % 10;
                        if (intRem > 0)
                            strIPart = strIPart + strNumbers[intRem] + " ";
                    }
                }
                else
                {
                    strIPart = strIPart + IntParttowords(intDividend);
                    strIPart = strIPart.Trim() + " ";
                }
                strIPart = strIPart + strDivisor[i] + " ";
            }
            intRemainder = IPart % intDivisor[i];
            if (intRemainder > 0)
            {
                if (intRemainder < 100)
                {
                    if (intRemainder < 20)
                    {
                        strIPart = strIPart + strNumbers[intRemainder] + " ";
                    }
                    else
                    {
                        intDiv = intRemainder / 10;
                        if (intDiv > 0)
                            strIPart = strIPart + strTenNumbers[intDiv] + " ";
                        intRem = intRemainder % 10;
                        if (intRem > 0)
                            strIPart = strIPart + strNumbers[intRem] + " ";
                    }
                    break;
                }
                else
                {
                    IPart = intRemainder;
                }
            }
            else
                break;
        }
        return strIPart;
    }
    protected string DecParttowords(int DPart)
    {
        string strDPart = "";
        int intDiv;
        int intRem;
        if (DPart < 20)
        {
            strDPart = strDPart + strNumbers[DPart] + " ";
        }
        else
        {
            intDiv = DPart / 10;
            if (intDiv > 0)
                strDPart = strDPart + strTenNumbers[intDiv] + " ";
            intRem = DPart % 10;
            if (intRem > 0)
                strDPart = strDPart + strNumbers[intRem] + " ";
        }
        return strDPart;
    }
} 



