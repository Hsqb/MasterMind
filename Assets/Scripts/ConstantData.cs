using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ConstantData
{
    public static ConstantData instance;
    public static ConstantData GetInstance()
    {
        if (instance == null)
        {
            instance = new ConstantData();
        }
        return instance;
    }
    private ConstantData()
    {

    }

    public string[][] GetFacilitiesInfo()
    {
        //pBuildingId, pName,pDisplayStringActivated, pDisplayStringInactivated, pPrice
        return new string[][]
        {//id, Name, ActivatedRequiredResource, ProcessRequiredResource, 
            //ProcessRequiredArmy, ResultResource, ResultArmy
            new string[] {"1","Power Plant",           "1 0 0 0 0", "0 0 0 0 0", "0 0", "3 0 0 0 0", "0 0" },
            new string[] {"2","Ore Mine",              "3 0 0 0 0", "0 0 0 0 0", "0 0", "0 2 0 0 0", "0 0" },
            new string[] {"3","Micro Chips Plant",     "3 1 0 0 0", "0 1 0 0 0", "0 0", "0 0 2 0 0", "0 0" },
            new string[] {"4","Ingot Plant",           "5 2 0 0 0", "0 2 0 0 0", "0 0", "0 0 0 1 0", "0 0" },
            new string[] {"5","Newclear Silo",         "5 0 0 3 0", "3 0 0 1 0", "0 0", "0 0 0 0 1", "0 0" },
            new string[] {"6","WarBot Facility",       "3 0 2 0 0", "2 0 1 0 0", "0 0", "0 0 0 0 0", "1 0" },
            new string[] {"7","Armory",                "5 0 0 1 0", "0 0 0 2 0", "1 0", "0 0 0 0 0", "0 1" },
            new string[] {"8","Data Server",           "5 0 0 2 0", "5 0 0 3 0", "0 0", "0 0 0 0 0", "0 0" },
            new string[] {"9","Missile Luancher",      "0 0 0 2 3", "0 0 0 0 1", "0 0", "0 0 0 0 0", "0 0" },
        };
    }

    public LambdaFuncInt[] GetOnClickEvents()
    {
        //pBuildingId, pName,pDisplayStringActivated, pDisplayStringInactivated, pPrice
        LambdaFuncInt type1 = (int id) =>
        {
            //Debug.Log("LambdaFuncInt id : " + id);
            Facility fac = DataController_han.GetInstance().GetFacilities()[(id - 1)];
            if (fac.CheckIsActivated())
            {
                DataController_han.GetInstance().FacilityProduce(id);
                //Debug.Log(fac.GetName()+" do something!");
                //GameManager_han.GetInstance().Refresh();
            }
            else
            {
                //Debug.Log("LambdaFuncInt ActivateFacility id : " + id);
                DataController_han.GetInstance().ActivateFacility(id);
                //Debug.Log(fac.GetName() + " Is Activated!!");
                //GameManager_han.GetInstance().Refresh();
            }
            
        };
        LambdaFuncInt type2 = (int id) =>
        {
            DataController_han.GetInstance().ActivateFacility(id);
            //GameManager_han.GetInstance().Refresh();
        };
        return new LambdaFuncInt[]
        {//id, Name, Required
            type1,
            type1,
            type1,
            type1,
            type1,
            type1,
            type1,
            type1,
            type1,
            type1,
            type1,
        };
    }

}
