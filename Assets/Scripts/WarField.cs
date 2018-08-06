using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;

public class WarField {
	public EnemyAi masterMind;
	public OurAi warMachine;
	private int turn;
	public WarField(){
		turn = 1;
		masterMind = new EnemyAi(2000, 100);
		warMachine = new OurAi(500, 10);
	}
	public int GetCurrentTurn(){
		return this.turn;
	}
	public void nextTurn(int x){
		this.turn+=x;
	}
}

public abstract class Ai {
	protected int hp;
    protected Army army;
	public abstract int GetHp();
	public abstract void AddHp(int hp);
	public abstract void SubHp(int hp);
	public abstract Army GetArmy();
}

public class EnemyAi : Ai{

    public EnemyAi(int pHp, int pArmyNum)
    {
        this.hp = pHp;
        this.army = new Army(pArmyNum);
    }
	public override int GetHp(){
		return this.hp;
	}
	public override void AddHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override void SubHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override Army GetArmy(){
		return this.army;
	}
}

public class OurAi : Ai{

    private ResourceMaganer rm;
    private ArrayList facs;
    private AP ap;
    public OurAi(int pHp, int pArmyNum)
    {
        this.hp = pHp;
        this.army = new Army(pArmyNum);
        this.rm = new ResourceMaganer();
        this.facs = new ArrayList();
        this.InitFacs();
        this.ap = new AP();
    }

    public override int GetHp(){
		return this.hp;
	}
	public override void AddHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override void SubHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override Army GetArmy(){
		return this.army;
	}
    public ResourceMaganer GetResourceManager()
    {
        return this.rm;
    }
    private void InitFacs()
    {

    }

}

public class Army
{
    private int armyNum;

    public Army(int armyNum)
    {
        this.armyNum = armyNum;
    }
    public int GetArmyNum()
    {
        return this.armyNum;
    }
    public void SetArmyNum(int armyNum)
    {
        this.armyNum = armyNum;
    }

}
public class AP
{
    private const int MAX_AP = 5;
    private const int INIT_AP = 2;
    private int currentAp;
    private int currentMaxAP;
    public AP()
    {
        this.currentAp = AP.INIT_AP;
        this.currentMaxAP = AP.INIT_AP;
    }
    public bool SubCurrentAp()
    {
        if(this.currentAp < 1)
        {
            return false;
        }else
        {
            this.currentAp--;
            return true;
        }
    }
    public bool ResetCurrentAp()
    {
        if (this.currentAp > 0)
        {
            return false;
        }
        else
        {
            this.currentAp = this.currentMaxAP;
            return true;
        }
    }
    public bool AddCurrentMaxAp()
    {
        if (this.currentMaxAP >= AP.MAX_AP)
        {
            return false;
        }
        else
        {
            this.currentMaxAP++;
            return true;
        }
    }
}

public class ResourceMaganer
{
    private Resources myResources;

    public ResourceMaganer()
    {
        myResources = new Resources();
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
public class Building
{
    private int buildingId;
    private bool isActivated;
    private string name;
    private string displayStringActivated;
    private string displayStringInactivated;

    private Resources price;

    public Building(int pBuildingId,
        string pName, 
        string pDisplayStringActivated,
        string pDisplayStringInactivated,
        Resources pPrice)
    {
        this.buildingId = pBuildingId;
        this.name = pName;
        this.price = pPrice;
        this.isActivated = false;
        this.displayStringActivated = pDisplayStringActivated;
        this.displayStringInactivated = pDisplayStringInactivated;
    }

    public virtual void OnClickListener() {
        Debug.Log("Building Object On Click");
    }
    public string GetDisplayString()
    {
        return this.isActivated ? this.displayStringActivated : this.displayStringInactivated;
    }
}
public class Facility : Building
{
    public Facility(int pBuildingId, 
        string pName, 
        string pDisplayStringActivated,
        string pDisplayStringInactivated,
        Resources pPrice) : base(pBuildingId, pName, pDisplayStringActivated, pDisplayStringInactivated, pPrice)
    {

    }
    public override void OnClickListener()
    {
        Debug.Log("Facility Object On Click");
    }
}
public class AdvFacility : Building
{

    public AdvFacility(int pBuildingId,
        string pName,
        string pDisplayStringActivated,
        string pDisplayStringInactivated,
        Resources pPrice) : base(pBuildingId, pName, pDisplayStringActivated, pDisplayStringInactivated, pPrice)
    {

    }
    public override void OnClickListener()
    {
        Debug.Log("AdvFacility Object On Click");
    }
}