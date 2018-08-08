using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;
public class ResourceManager
{
    private Resources myResources;
    public string[] resourcesName = new string[]
    {
            "Electric",
            "Ore",
            "MicroChips",
            "Ingot",
            "Newclear",
    };
    public ResourceManager()
    {
        myResources = new Resources();
    }

    public string[] GetResourceDisplay()
    {
        string[] temp = (string[])resourcesName.Clone();
        int[] resources = myResources.GetResources();
        int longestLength= 0;
        for(int i = 0; i < temp.Length; i++)
        {
            if(temp[i].Length > longestLength)
            {
                longestLength = temp[i].Length;
            }
        }
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = temp[i].PadRight(longestLength, ' ') + resources[i];
        }
        return temp;
    }
    public string GetFormattedResourceString(Resources r, bool isAdd=false)
    {
        string[] temp = (string[])resourcesName.Clone();
        string rtnVal = "(";
        int[] resources = r.GetResources();

        for (int i = 0; i < temp.Length; i++)
        {
            if(resources[i] > 0) { 
                rtnVal += temp[i] + (isAdd ? " " : " -") + resources[i];
                if (i < temp.Length - 1) rtnVal += " ";
            }
        }

        return rtnVal+")";
    }
    
    public bool IsPayable(Resources invoice)
    {
        int[] b = invoice.GetResources();
        int[] a = myResources.GetResources();
        bool isPayable = true;
        for(int i = 0; i < a.Length; i++)
        {
            //Debug.Log(isPayable + " a " + a[i] + "|b " + b[i]);
            isPayable = (a[i] - b[i]  > -1) && isPayable;
        }
        return isPayable;
    }
    public bool PayResource(Resources invoice)
    {
        try
        {
            Resources temp = myResources.SubResources(invoice);
            myResources = temp;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            return false;
        }
        return true;
    }
    public bool ReceiveResource(Resources income)
    {
        try{ 
            myResources = myResources.AddResources(income);
        }catch(System.Exception e)
        {
            Debug.Log( e.ToString());
            return false;
        }
        return true;
    }

}
public class Resources
{
    private int[] resources = new int[5];
    public Resources(int elec=0, int ore = 0, int mchips = 0, int ingot = 0, int nuke = 0)
    {
        this.resources[0] = elec;
        this.resources[1] = ore;
        this.resources[2] = mchips;
        this.resources[3] = ingot;
        this.resources[4] = nuke;
    }
    public Resources(int[] resourceArr)
    {
        this.resources = (int[])resourceArr.Clone();
    }
    public int[] GetResources()
    {
        return (int[])this.resources.Clone();
    }
    public Resources AddResources(Resources newIncome)
    {
        int[] mine = this.GetResources();
        int[] newOne = newIncome.GetResources();
        for(int i = 0; i < mine.Length; i++)
        {
            mine[i] += newOne[i];
        }

        return new Resources(mine[0], mine[1], mine[2], mine[3], mine[4]);
        
    }
    public Resources SubResources(Resources newPayment)
    {
        int[] mine = this.GetResources();
        int[] newOne = newPayment.GetResources();
        for (int i = 0; i < mine.Length; i++)
        {
            mine[i] -= newOne[i];
            if(mine[i] < 0)
            {
                throw new System.Exception();
            }
        }
        return new Resources(mine[0], mine[1], mine[2], mine[3], mine[4]);
    }
}