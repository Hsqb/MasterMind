using UnityEngine;
using System.Collections;


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