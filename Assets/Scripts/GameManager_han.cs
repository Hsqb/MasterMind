using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Reflection;

public class GameManager_han : MonoBehaviour {
    public static GameManager_han instance;

    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            AttachEvent();
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        DataController_han.GetInstance();
        
            
    }
    //1초에 한번 갱신 Project Setting > Time 에서 수정가능
    private void FixedUpdate()
    {
        Refresh();
    }
    private void AttachEvent()
    {
        List<Facility> facs = DataController_han.GetInstance().GetFacilities();
        for (int j = 0; j < facs.Count; j++)
        {
            Debug.Log("attachEvent");
            int k = j;
            GameObject.Find("FacilityButton" + (j + 1)).GetComponent<Button>().onClick.AddListener(delegate { facs[k].OnClickListener(); });
        }
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
        for(int j = 0; j < facs.Count; j++)
        {
            GameObject.Find("FacilityButton" + (j + 1)).GetComponent<Button>().interactable = DataController_han.GetInstance().GetIsInteractable(facs[j]);
            GameObject.Find("FacilityText" + (j + 1)).GetComponent<Text>().text = facs[j].GetDisplayString();
        }

        // 아마도 Army


        //AP check
        DataController_han.GetInstance().CheckAP();
    }
}
