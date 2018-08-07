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
    public string GetDisplayAp()
    {
        int currentAp = field.warMachine.GetAP().GetCurrentAp();
        return "AP " + currentAp;
    }
    public string[] GetResourceVals()
    {
        return field.warMachine.GetResourceManager().GetResourceDisplay();

    }
    public List<Facility> GetFacilities()
    {
        return field.warMachine.GetFaclilties();
    }

    public void FacilityProduce(int facId)
    {
        try
        {
            if (field.warMachine.GetAP().SubCurrentAp())
            {
                ResourceManager rm = field.warMachine.GetResourceManager();
                Facility fac = field.warMachine.GetFaclilties()[(facId - 1)];
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

    //exe when script is being loaded.
    void Awake()
    {
        field = new WarField();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}