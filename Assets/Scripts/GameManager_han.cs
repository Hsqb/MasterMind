using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Reflection;

public class GameManager_han : MonoBehaviour {
    public static GameManager instance;

    public static GameManager GetInstance()
    {

        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();

            if (instance == null)
            {
                GameObject container = new GameObject("GameManager");

                instance = container.AddComponent<GameManager>();

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
    private void Refresh()
    {
        // 화면을 새로운 값으로 갱신


        // AP값 갱신
        GameObject.Find("PlayerApText").GetComponent<Text>().text = DataController_han.GetInstance().getDisplayAp();
        // 자원값 갱신
        int[] resourceValArr = DataController_han.GetInstance().getResourceVals();
        for( int i = 0; i < resourceValArr.Length; i++)
        {
            GameObject.Find("Resource"+(i+1)+"Text").GetComponent<Text>().text = ""+resourceValArr[i];
        }
        // 건물 액티브 체크후 갱신
        DataController_han.GetInstance().getFacs();

        // 아마도 Army
    }
    /*
    private void ActiveFacilities() {
        for(int i = 0; i < maxFacilityNum; i++)
        {
            if (isFacilityActivated(i + 1))
            {
                GameObject.Find("Facility"+(i+1)+"Button").GetComponent<Button>().interactable = true;
                (GameObject.Find("Facility" + (i + 1) + "Text").GetComponent<Text>()).text = facilityTextArray[0, (i + 1)];
            }
            else
            {
                if (canBeActivated((i + 1)))
                {
                    GameObject.Find("Facility" + (i + 1) + "Button").GetComponent<Button>().interactable = true;
                }else
                {
                    GameObject.Find("Facility" + (i + 1) + "Button").GetComponent<Button>().interactable = false;
                }                
                (GameObject.Find("Facility" + (i + 1) + "Text").GetComponent<Text>()).text = facilityTextArray[0, (i + 1)];

            }
        }
        for (int i = 0; i < maxAdvFacilityNum; i++)
        {
            if (isFacilityActivated(i + 1))
            {
                GameObject.Find("AdvancedFacility" + (i + 1) + "Button").GetComponent<Button>().interactable = true;
                (GameObject.Find("AdvancedFacility" + (i + 1) + "Text").GetComponent<Text>()).text = facilityTextArray[0, (i + 1)];
            }
            else
            {
                if (canBeActivated((i + 1)))
                {
                    GameObject.Find("AdvancedFacility" + (i + 1) + "Button").GetComponent<Button>().interactable = true;
                }
                else
                {
                    GameObject.Find("AdvancedFacility" + (i + 1) + "Button").GetComponent<Button>().interactable = false;
                }
                (GameObject.Find("AdvancedFacility" + (i + 1) + "Text").GetComponent<Text>()).text = facilityTextArray[0, (i + 1)];

            }
        }
    }
    /*
    private bool isFacilityActivated(int facilityId, bool isAdvance=false)
    {
        System.Type DC = DataController.GetInstance().GetType();
        MethodInfo tempMethod;
        string methodName = isAdvance ? "GetAdvancedFacility" : "GetFacility";
        int val = 0;
        try
        {
            tempMethod = DC.GetMethod(methodName + facilityId);
            val = (int)tempMethod.Invoke(DataController.GetInstance(), null);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Data);
        }
        return val == 1;
    }
    
    private bool canBeActivated(int facilityId, bool isAdvance = false)
    {
        System.Type DC = DataController.GetInstance().GetType();
        MethodInfo tempMethod;
        int[,] table = isAdvance ? requireResourceAmountForActivateAdvFac : requireResourceAmountForActivateFacility;
        bool caNbeActivated = true;
        int[] currentResourcesAmount = new int[maxResourceNum];
        try { 
            for (int i = 0; i <= maxResourceNum; i++)
            {
                tempMethod = DC.GetMethod("GetResource" + (i+1));
                currentResourcesAmount[i] = (int) tempMethod.Invoke(DataController.GetInstance(), null);
            }
            for(int i = 0; i <= currentResourcesAmount.Length; i++)
            {
                caNbeActivated &= currentResourcesAmount[i] >= table[facilityId, i];
            }
        }catch(System.Exception e)
        {
            Debug.LogError(e.Data); 
        }
        return caNbeActivated;
    }
    
    public void UsingAP()
    {
        DataController.GetInstance().SubPlayerAP();
        if (DataController.GetInstance().GetPlayerAP() <= 0)
        {
            DataController.GetInstance().InitializePlayerAP();
            turn = PlayerPrefs.GetInt("Turn", 1);
            turn++;
            Debug.Log("turn is " + turn);
            PlayerPrefs.SetInt("Turn", turn);
        }
        GameObject.Find("PlayerApText").GetComponent<Text>().text = "AP " + DataController.GetInstance().GetPlayerAP();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnClickFacility(int facilityId)
    {
        System.Type DC = DataController.GetInstance().GetType();
        MethodInfo tempMethod;
        if (!isFacilityActivated(facilityId))
        {
            for(int i = 0; i < maxResourceNum; i++)
            {
                tempMethod = DC.GetMethod("SubResource" + (i + 1));
                tempMethod.Invoke(DataController.GetInstance(), new object[] { requireResourceAmountForActivateFacility[0,facilityId] });
            }
            UsingAP();
            DataController.GetInstance().ActivateAdvancedFacility1();
            Start();
            ActiveFacilities();
        }else
        {

        }
    }
    */

}
