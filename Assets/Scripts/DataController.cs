using UnityEngine;
using System.Collections;

public class DataController : MonoBehaviour {

	private static DataController instance;

	public static DataController GetInstance() {

		if (instance == null) {
			instance = FindObjectOfType<DataController> ();

			if (instance == null) {
				GameObject container = new GameObject ("DataController");

				instance = container.AddComponent<DataController> ();

			}

		}
		return instance;
	}


	private int m_resource1 = 0;
	private int m_resource1PerClick = 0;
	private int m_resource2 = 0;
	private int m_resource2PerClick = 0;
	private int m_resource3 = 0;
	private int m_resource3PerClick = 0;
	private int m_resource4 = 0;
	private int m_resource4PerClick = 0;
	private int m_resource5 = 0;
	private int m_resource5PerClick = 0;

	private int m_playerAP = 0;
	private int m_playerMaxAP = 0;

	private int m_turn = 0;

	private int m_myArmy = 0;
	private int m_enemyArmy = 0;

/*
	private bool m_availFacility1 = true;
	private bool m_availFacility2 = true;
	private bool m_availFacility3 = true;
	private bool m_availFacility4 = true;
	private bool m_availFacility5 = true;
	private bool m_availAdvancedFacility1 = true;
	private bool m_availAdvancedFacility2 = true;
	private bool m_availAdvancedFacility3 = true;
	private bool m_availAdvancedFacility4 = true;
*/

	private int m_availabilityFacility1 = 0;
	private int m_availabilityFacility2 = 0;
	private int m_availabilityFacility3 = 0;
	private int m_availabilityFacility4 = 0;
	private int m_availabilityFacility5 = 0;
	private int m_availabilityAdvancedFacility1 = 0;
	private int m_availabilityAdvancedFacility2 = 0;
	private int m_availabilityAdvancedFacility3 = 0;
	private int m_availabilityAdvancedFacility4 = 0;

	void Awake() {

		// KEY : VALUE 
		m_resource1 = PlayerPrefs.GetInt("Resource1");
		m_resource1PerClick = PlayerPrefs.GetInt("Resource1PerClick",3);
		// 아무런 값ㅣ 들어오지 않으면 1로 초기화

		// PlayerPregs 는 KEY : VALUE 의 사전 컬럼이다.
		// Set 으로 setting 하 Get 으로 가져온다
		m_resource2 = PlayerPrefs.GetInt("Resource2");
		m_resource2PerClick = PlayerPrefs.GetInt("Resource2PerClick",1);
		m_resource3 = PlayerPrefs.GetInt("Resource3");
		m_resource3PerClick = PlayerPrefs.GetInt("Resource3PerClick",1);
		m_resource4 = PlayerPrefs.GetInt("Resource4");
		m_resource4PerClick = PlayerPrefs.GetInt("Resource4PerClick",1);
		m_resource5 = PlayerPrefs.GetInt("Resource5");
		m_resource5PerClick = PlayerPrefs.GetInt("Resource5PerClick",1);

		m_playerAP = PlayerPrefs.GetInt ("PlayerAP",3);
		m_playerMaxAP = PlayerPrefs.GetInt ("PlayerMAXAP",3);

		m_turn = PlayerPrefs.GetInt ("Turn",1);

		m_myArmy = PlayerPrefs.GetInt ("MyArmy", 3);
		m_enemyArmy = PlayerPrefs.GetInt ("EnemyArmy", 0);

		m_availabilityFacility1 = PlayerPrefs.GetInt ("ActivateFacility1", 1);
		m_availabilityFacility2 = PlayerPrefs.GetInt ("ActivateFacility2", 1);
		m_availabilityFacility3 = PlayerPrefs.GetInt ("ActivateFacility3", 0);
		m_availabilityFacility4 = PlayerPrefs.GetInt ("ActivateFacility4", 0);
		m_availabilityFacility5 = PlayerPrefs.GetInt ("ActivateFacility5", 0);
		m_availabilityAdvancedFacility1 = PlayerPrefs.GetInt ("ActivateAdvancedFacility1", 0);
		m_availabilityAdvancedFacility2 = PlayerPrefs.GetInt ("ActivateAdvancedFacility2", 0);
		m_availabilityAdvancedFacility3 = PlayerPrefs.GetInt ("ActivateAdvancedFacility3", 0);
		m_availabilityAdvancedFacility4 = PlayerPrefs.GetInt ("ActivateAdvancedFacility4", 0);
	}

	//Initialize Fuction is not using yet.
	public void Initialize(){
		
		PlayerPrefs.SetInt("Resource1",0);
		PlayerPrefs.SetInt("Resource2",0);
		PlayerPrefs.SetInt("Resource3",0);
		PlayerPrefs.SetInt("Resource4",0);
		PlayerPrefs.SetInt("Resource5",0);
		PlayerPrefs.SetInt("PlayerAP",3);
		PlayerPrefs.SetInt("PlayerMAXAP",3);
		PlayerPrefs.SetInt("Turn",1);
		PlayerPrefs.SetInt("MyArmy",3);
		PlayerPrefs.SetInt("EnemyArmy",0);
		PlayerPrefs.SetInt ("ActivateFacility1", 1);
		PlayerPrefs.SetInt ("ActivateFacility2", 1);
		PlayerPrefs.SetInt ("ActivateFacility3", 0);
		PlayerPrefs.SetInt ("ActivateFacility4", 0);
		PlayerPrefs.SetInt ("ActivateFacility5", 0);
		PlayerPrefs.SetInt ("ActivateAdvancedFacility1", 0);
		PlayerPrefs.SetInt ("ActivateAdvancedFacility2", 0);
		PlayerPrefs.SetInt ("ActivateAdvancedFacility3", 0);
		PlayerPrefs.SetInt ("ActivateAdvancedFacility4", 0);

		m_resource1 = PlayerPrefs.GetInt("Resource1");
		m_resource2 = PlayerPrefs.GetInt("Resource2");
		m_resource3 = PlayerPrefs.GetInt("Resource3");
		m_resource4 = PlayerPrefs.GetInt("Resource4");
		m_resource5 = PlayerPrefs.GetInt("Resource5");
		m_playerAP = PlayerPrefs.GetInt("PlayerAP");
		m_playerMaxAP = PlayerPrefs.GetInt("PlayerMAXAP");
		m_turn = PlayerPrefs.GetInt("Turn");
		m_myArmy = PlayerPrefs.GetInt ("MyArmy");
		m_enemyArmy = PlayerPrefs.GetInt ("EnemyArmy");
		m_availabilityFacility1 = PlayerPrefs.GetInt ("ActivateFacility1", 1);
		m_availabilityFacility2 = PlayerPrefs.GetInt ("ActivateFacility2", 1);
		m_availabilityFacility3 = PlayerPrefs.GetInt ("ActivateFacility3", 0);
		m_availabilityFacility4 = PlayerPrefs.GetInt ("ActivateFacility4", 0);
		m_availabilityFacility5 = PlayerPrefs.GetInt ("ActivateFacility5", 0);
		m_availabilityAdvancedFacility1 = PlayerPrefs.GetInt ("ActivateAdvancedFacility1", 0);
		m_availabilityAdvancedFacility2 = PlayerPrefs.GetInt ("ActivateAdvancedFacility2", 0);
		m_availabilityAdvancedFacility3 = PlayerPrefs.GetInt ("ActivateAdvancedFacility3", 0);
		m_availabilityAdvancedFacility4 = PlayerPrefs.GetInt ("ActivateAdvancedFacility4", 0);

	}

	public void SetResource1(int newResource1)
	{
		m_resource1 = newResource1;
		PlayerPrefs.SetInt ("Resource1", m_resource1);
	}

	public void AddResource1(int newResource1){
		//m_resource1 = m_resource1 + m_resource1PerClick;
		m_resource1 += m_resource1PerClick;
		SetResource1 (m_resource1);
	}

	public void SubResource1(int newResource1){
		m_resource1 -= newResource1;
		SetResource1 (m_resource1);
	}

	public int GetResource1(){
		return m_resource1;
	}

	public int GetResource1PerClick(){
		return m_resource1PerClick;
	}

	public void SetResource1PerClick (int newRecource1PerClick)	{
		m_resource1PerClick = newRecource1PerClick;
		PlayerPrefs.SetInt ("Resource1PerClick", m_resource1PerClick);
	}
	// resource2

	public void SetResource2(int newResource2)
	{
		m_resource2 = newResource2;
		PlayerPrefs.SetInt ("Resource2", m_resource2);
	}

	public void AddResource2(int newResource2){
		//m_resource1 = m_resource1 + m_resource1PerClick;
		m_resource2 += m_resource2PerClick;
		SetResource2 (m_resource2);
	}

	public void SubResource2(int newResource2){
		m_resource2 -= newResource2;
		SetResource2 (m_resource2);
	}

	public int GetResource2(){
		return m_resource2;
	}

	public int GetResource2PerClick(){
		return m_resource2PerClick;
	}

	public void SetResource2PerClick (int newRecource2PerClick)	{
		m_resource2PerClick = newRecource2PerClick;
		PlayerPrefs.SetInt ("Resource2PerClick", m_resource2PerClick);
	}

	// resource3

	public void SetResource3(int newResource3)
	{
		m_resource3 = newResource3;
		PlayerPrefs.SetInt ("Resource3", m_resource3);
	}

	public void AddResource3(int newResource3){
		m_resource3 += m_resource3PerClick;
		SetResource3 (m_resource3);
	}

	public void SubResource3(int newResource3){
		m_resource3 -= newResource3;
		SetResource3 (m_resource3);
	}

	public int GetResource3(){
		return m_resource3;
	}

	public int GetResource3PerClick(){
		return m_resource3PerClick;
	}

	public void SetResource3PerClick (int newRecource3PerClick)	{
		m_resource3PerClick = newRecource3PerClick;
		PlayerPrefs.SetInt ("Resource3PerClick", m_resource3PerClick);
	}

	// resource4

	public void SetResource4(int newResource4)
	{
		m_resource4 = newResource4;
		PlayerPrefs.SetInt ("Resource4", m_resource4);
	}

	public void AddResource4(int newResource4){
		m_resource4 += m_resource4PerClick;
		SetResource4 (m_resource4);
	}

	public void SubResource4(int newResource4){
		m_resource4 -= newResource4;
		SetResource4 (m_resource4);
	}

	public int GetResource4(){
		return m_resource4;
	}

	public int GetResource4PerClick(){
		return m_resource4PerClick;
	}

	public void SetResource4PerClick (int newRecource4PerClick)	{
		m_resource4PerClick = newRecource4PerClick;
		PlayerPrefs.SetInt ("Resource4PerClick", m_resource4PerClick);
	}

	// resource5


	public void SetResource5(int newResource5)
	{
		m_resource5 = newResource5;
		PlayerPrefs.SetInt ("Resource5", m_resource5);
	}

	public void AddResource5(int newResource5){
		m_resource5 += m_resource5PerClick;
		SetResource5 (m_resource5);
	}

	public void SubResource5(int newResource5){
		m_resource5 -= newResource5;
		SetResource5 (m_resource5);
	}

	public int GetResource5(){
		return m_resource5;
	}

	public int GetResource5PerClick(){
		return m_resource5PerClick;
	}

	public void SetResource5PerClick (int newRecource5PerClick)	{
		m_resource5PerClick = newRecource5PerClick;
		PlayerPrefs.SetInt ("Resource5PerClick", m_resource5PerClick);
	}


	//AP Function Develope
	public void SetPlayerAP (int newPlayerAP){
		m_playerAP = newPlayerAP;
		PlayerPrefs.SetInt ("PlayerAP", m_playerAP);
	}

	public void InitializePlayerAP (){
		m_playerAP = m_playerMaxAP;
		SetPlayerAP (m_playerAP);
	}
		
	public void SubPlayerAP (){
		m_playerAP -= 1;
		SetPlayerAP (m_playerAP);
	}

	public int GetPlayerAP (){
		return m_playerAP;
	}


	// army

	public void SetMyArmy(int newMyarmy)
	{
		m_myArmy = newMyarmy;
		PlayerPrefs.SetInt ("MyArmy", m_myArmy);
	}

	public void AddMyArmy(int addMyarmy){
		m_myArmy += addMyarmy;
		SetMyArmy (m_myArmy);
	}

	public void SubMyArmy(int subMyarmy){
		m_myArmy -= subMyarmy;
		SetMyArmy (m_myArmy);
	}

	public int GetMyArmy(){
		return m_myArmy;
	}

	//enemy
	public void SetEnemyArmy(int newEnemyarmy)
	{
		m_enemyArmy = newEnemyarmy;
		PlayerPrefs.SetInt ("EnemyArmy", m_enemyArmy);
	}

	public void AddEnemyArmy(int addEnemyarmy){
		m_enemyArmy += addEnemyarmy;
		SetEnemyArmy (m_enemyArmy);
	}

	public void SubEnemyArmy(int subEnemyarmy){
		m_enemyArmy -= subEnemyarmy;
		SetEnemyArmy (m_enemyArmy);
	}

	public int GetEnemyArmy(){
		return m_enemyArmy;
	}

	public void ActivateFacility1(){
		m_availabilityFacility1 = m_availabilityFacility1 + 1;
		PlayerPrefs.SetInt ("ActivateFacility1", m_availabilityFacility1);
	}

	public void ActivateFacility2(){
		m_availabilityFacility2 = m_availabilityFacility2 + 1;
		PlayerPrefs.SetInt ("ActivateFacility2", m_availabilityFacility2);
	}

	public void ActivateFacility3(){
		m_availabilityFacility3 = m_availabilityFacility3 + 1;
		PlayerPrefs.SetInt ("ActivateFacility3", m_availabilityFacility3);
	}

	public void ActivateFacility4(){
		m_availabilityFacility4 = m_availabilityFacility4 + 1;
		PlayerPrefs.SetInt ("ActivateFacility4", m_availabilityFacility4);
	}

	public void ActivateFacility5(){
		m_availabilityFacility5 = m_availabilityFacility5 + 1;
		PlayerPrefs.SetInt ("ActivateFacility5", m_availabilityFacility5);
	}

	public void ActivateAdvancedFacility1(){
		m_availabilityAdvancedFacility1 = m_availabilityAdvancedFacility1 + 1;
		PlayerPrefs.SetInt ("ActivateAdvancedFacility1", m_availabilityAdvancedFacility1);
	}

	public void ActivateAdvancedFacility2(){
		m_availabilityAdvancedFacility2 = m_availabilityAdvancedFacility2 + 1;
		PlayerPrefs.SetInt ("ActivateAdvancedFacility2", m_availabilityAdvancedFacility2);
	}

	public void ActivateAdvancedFacility3(){
		m_availabilityAdvancedFacility3 = m_availabilityAdvancedFacility3 + 1;
		PlayerPrefs.SetInt ("ActivateAdvancedFacility3", m_availabilityAdvancedFacility3);
	}

	public void ActivateAdvancedFacility4(){
		m_availabilityAdvancedFacility4 = m_availabilityAdvancedFacility4 + 1;
		PlayerPrefs.SetInt ("ActivateAdvancedFacility4", m_availabilityAdvancedFacility4);
	}

	public int GetFacility1(){
		return m_availabilityFacility1;
	}

	public int GetFacility2(){
		return m_availabilityFacility2;
	}

	public int GetFacility3(){
		return m_availabilityFacility3;
	}

	public int GetFacility4(){
		return m_availabilityFacility4;
	}

	public int GetFacility5(){
		return m_availabilityFacility5;
	}

	public int GetAdvancedFacility1(){
		return m_availabilityAdvancedFacility1;
	}

	public int GetAdvancedFacility2(){
		return m_availabilityAdvancedFacility2;
	}

	public int GetAdvancedFacility3(){
		return m_availabilityAdvancedFacility3;
	}

	public int GetAdvancedFacility4(){
		return m_availabilityAdvancedFacility4;
	}

}



