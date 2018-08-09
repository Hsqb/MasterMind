using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataController_han : MonoBehaviour {
    private WarField field;
    private static DataController_han instance;


    public static DataController_han GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataController_han>();
            if (instance == null)
            {
                GameObject container = new GameObject("DataController_han");
                instance = container.AddComponent<DataController_han>();
            }

        }
        return instance;
    }
    public bool GetIsInteractable(Facility fac)
    {
        ResourceManager rm = field.warMachine.GetResourceManager();
        return fac.CheckIsActivated() ?  rm.IsPayable(fac.GetCost()) : rm.IsPayable(fac.GetPrice());
    }
    public void CheckAP()
    {
        if(field.warMachine.GetAP().GetCurrentAp() < 1)
        {
            field.nextTurn();
            field.warMachine.GetAP().ResetCurrentAp();
            field.nextTurnImage();
        }
    }
    public string GetDisplayAp()
    {
        int currentAp = field.warMachine.GetAP().GetCurrentAp();
        return "AP " + currentAp;
    }
    public string[] GetResourceVals()
    {
        Debug.Log("dcgerres"+field.warMachine.GetResourceManager().GetResourceDisplay()[0]);
        return field.warMachine.GetResourceManager().GetResourceDisplay();

    }
    public List<Facility> GetFacilities()
    {
        return field.warMachine.GetFaclilties();
    }

    public void FacilityProduce(int facId)
    {
        //Debug.Log("Fac Id : " + facId);
        try
        {
            if (field.warMachine.GetAP().SubCurrentAp())
            {
                ResourceManager rm = field.warMachine.GetResourceManager();
                Facility fac = field.warMachine.GetFaclilties()[(facId - 1)];
                rm.PayResource(fac.GetCost());
                rm.ReceiveResource(fac.GetProduct());
            }
        }
        catch (System.Exception e)
        {
            field.warMachine.GetAP().AddCurrentAp();
            Debug.LogError(e);
        }
    }
    public void ActivateFacility(int facId)
    {
        try {
            if (field.warMachine.GetAP().SubCurrentAp())
            {
                ResourceManager rm = field.warMachine.GetResourceManager();
                Facility fac = field.warMachine.GetFaclilties()[(facId - 1)];
                if (!fac.CheckIsActivated())
                {
                    rm.PayResource(fac.GetPrice());
                    fac.Activate();
                }
                else
                {
                    throw new System.Exception("Already Activated! Something is wrong");
                }


            }
        }
        catch(System.Exception e)
        {
            field.warMachine.GetAP().AddCurrentAp();
            Debug.LogError(e);
        }

    }
    public void SaveData()
    {
        PlayerPrefs.SetString("SavedData", field.Stringify());
    }
    //exe when script is being loaded.
    void Awake()
    {
        string s = PlayerPrefs.GetString("SavedData");
        Debug.Log("Called DC_han : awake : "+s);
        field = new WarField();
        if ( s.Equals(""))
        {
            Debug.Log("No Save Data");
        }
        else
        {
            Debug.Log("Save Data is.");
            field.Parse(s);//mightWillBeCapsuled;
        }
        Debug.Log(field.warMachine.GetResourceManager().GetResourceDisplay()[0]);
    }

    public void ResetData()
    {
        PlayerPrefs.SetString("SavedData", "");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}