using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Reflection;

public class GameManager_han : MonoBehaviour {
    public static GameManager_han instance;

    public static GameManager_han GetInstance()
    {

        if (instance == null)
        {
            instance = FindObjectOfType<GameManager_han>();

            if (instance == null)
            {
                GameObject container = new GameObject("GameManager_han");

                instance = container.AddComponent<GameManager_han>();

            }

        }
        return instance;
    }

    private string[] resourceTextArray = new string[] {
        "Electric  ",
        "Ore       ",
        "MicroChips",
        "Ingot     ",
        "Newclear  ",
        };

    private string[,] facilityTextArray = new string[,] {
        {
            "Power Plant\n(Electricity +3)",
            "Ore Mine\n(Ore +1)",
            "Micro Chips Plant\n(Ore -1 Micro Chips +2)",
            "Ingot Plant\n(Ore -1 Ingot +1)",
            "Newclear Silo\n(Ingot -2 Energy -3 Newclear +1)"

        },
        {
            "Active Power Plant\n(Electricity -3)",
            "Active Ore Mind\n(Electricity -3)",
            "Active Micro Chips Plant\n(Electricity -3)",
            "Active Ingot Plant\n(Electricity -3)",
             "Active Newclear Silo\n(Electricity -3)"
        }
        };

    private string[,] advFacilityTextArray = new string[,] {
        {
            "Power Plant\n(Electricity +3)",
            "Ore Mine\n(Ore +1)",
            "Micro Chips Plant\n(Ore -1 Micro Chips +2)",
            "Ingot Plant\n(Ore -1 Ingot +1)",
            "Newclear Silo\n(Ingot -2 Energy -3 Newclear +1)"

        },
        {
            "Active Power Plant\n(Electricity -3)",
            "Active Ore Mind\n(Electricity -3)",
            "Active Micro Chips Plant\n(Electricity -3)",
            "Active Ingot Plant\n(Electricity -3)",
            "Active Newclear Silo\n(Electricity -3)"
        }
        };


    // Use this for initialization
    private void Start()
    {
        DataController.GetInstance().Initialize();
        Refresh();
    }
    public void Refresh()
    {
        // 화면을 새로운 값으로 갱신


        // AP값 갱신
        GameObject.Find("PlayerApText").GetComponent<Text>().text = DataController_han.GetInstance().GetDisplayAp();
        // 자원값 갱신
        string[] resourceValArr = DataController_han.GetInstance().GetResourceVals();
        for( int i = 0; i < resourceValArr.Length; i++)
        {
            GameObject.Find("ResourceText" + (i + 1)).GetComponent<Text>().text = resourceValArr[i];
        }
        // 건물 액티브 체크후 갱신
        List<Facility> facs = DataController_han.GetInstance().GetFacilities();
        for(int i = 0; i < facs.Count; i++)
        {
            GameObject.Find("FacilityButton" + (i + 1)).GetComponent<Button>().interactable = facs[i].CheckIsActivated();
            GameObject.Find("FacilityText" + (i + 1)).GetComponent<Text>().text = facs[i].GetDisplayString();
        }

        // 아마도 Army
    }
}
