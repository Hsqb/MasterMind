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

    public Text[] resourceText = new Text[5];
    public Text[] facilityText = new Text[5];
    public Text[] advancedFacilityText = new Text[5];
    public int[] resourcesAmount = new int[5] { 0, 0, 0, 0, 0 };
    public int[,] requireResourceAmountForActivateFacility = new int[,] { 
                                                                         {1,1,0,0,0 }, 
                                                                         {2,2,0,0,0 },
                                                                         {3,3,0,0,0 },
                                                                         {4,4,0,0,0 },
                                                                         {5,5,0,0,0 }
                                                                        };
    public int[,] requireResourceAmountForActivateAdvFac = new int[,] {
                                                                         {1,1,0,0,0 },
                                                                         {2,2,0,0,0 },
                                                                         {3,3,0,0,0 },
                                                                         {4,4,0,0,0 }
                                                                        };
    public int[,] requireResourceAmountForUsingFac = new int[,] {
                                                                         {0,0,0,0,0 },
                                                                         {0,0,0,0,0 },
                                                                         {0,1,0,0,0 },
                                                                         {0,1,0,0,0 },
                                                                         {3,0,0,2,0 },
                                                                        };
    private int playerAp = 3;
    private int playerMaxAp = 3;
    private int turn = 1;
    private int maxResourceNum = 5;
    private int maxFacilityNum = 5;
    private int maxAdvFacilityNum = 5;
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
    void Start () {
        int temp = -1;
	    for(int i = 1; i <= maxResourceNum; i++)
        {
            MethodInfo m = DataController.GetInstance().GetType().GetMethod("GetResource" + i);
            if(m != null)
            {
                temp = (int)(m.Invoke(DataController.GetInstance(), null));
            }

            (GameObject.Find("Resource" + i + "Text").GetComponent<Text>()).text = resourceTextArray[i - 1] + temp;



        }
        (GameObject.Find("PlayerApText").GetComponent<Text>()).text = "AP " + playerAp;
        ActiveFacilities();
    }
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

    public void Initialize()
    {
        DataController.GetInstance().Initialize();
        Start();
    }
}
