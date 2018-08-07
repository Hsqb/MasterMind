using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;




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

    private ResourceManager rm;
    private List<Facility> facs;
    private AP ap;
    public OurAi(int pHp, int pArmyNum)
    {
        this.hp = pHp;
        this.army = new Army(pArmyNum);
        this.rm = new ResourceManager();
        this.ap = new AP();
        this.facs = new List<Facility>();
        this.InitFacs();
        
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
    public ResourceManager GetResourceManager()
    {
        return this.rm;
    }
    public AP GetAP()
    {
        return this.ap;
    }
    public List<Facility> GetFaclilties()
    {
        return this.facs;
    }
    private void InitFacs()
    {
        LambdaFuncInt[] lfi = ConstantData.GetInstance().GetOnClickEvents();
        string[][] st = ConstantData.GetInstance().GetFacilitiesInfo();
        Resources temp;
        for(int i = 0; i < st.Length; i++)
        {
            List<string> resourceList = new List<string>(st[i][2].Split(' '));
            IEnumerable<Int32> resourceVal = resourceList.Select(x => Int32.Parse(x));
            temp = new Resources(resourceVal.ToArray());
            facs.Add(new Facility(Int32.Parse(st[i][0]), st[i][1],
                st[i][1] + "\n(" + ")",
                st[i][1] + "\n(" + this.rm.GetRequiredResourceString(temp) + ")",
                temp, 
                lfi[i]
                )
            );
        }
    }
}

/*
             "Power Plant\n(Electricity +3)",
            "Ore Mine\n(Ore +1)",
            "Micro Chips Plant\n(Ore -1 Micro Chips +2)",
            "Ingot Plant\n(Ore -1 Ingot +1)",
            "Newclear Silo\n(Ingot -2 Energy -3 Newclear +1)"
     */

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
    private int currentMaxAp;
    public AP()
    {
        this.currentAp = AP.INIT_AP;
        this.currentMaxAp = AP.INIT_AP;
    }

    public int GetCurrentAp()
    {
        return this.currentAp;
    }
    public int GetCurrentMaxAp()
    {
        return this.currentMaxAp;
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
            this.currentAp = this.currentMaxAp;
            return true;
        }
    }
    public bool AddCurrentMaxAp()
    {
        if (this.currentMaxAp >= AP.MAX_AP)
        {
            return false;
        }
        else
        {
            this.currentMaxAp++;
            return true;
        }
    }
    public bool AddCurrentAp()
    {
        if (this.currentMaxAp <= this.currentAp)
        {
            return false;
        }
        else
        {
            this.currentMaxAp++;
            return true;
        }
    }
}

public class ResourceManager
{
    private Resources myResources;
    public string[] resourcesName = new string[]
    {
            "Electric",
            "Ore",
            "MicroChips",
            "Ingot",
            "Newclear",
    };
    public ResourceManager()
    {
        myResources = new Resources();
    }

    public string[] GetResourceDisplay()
    {
        string[] temp = (string[])resourcesName.Clone();
        int[] resources = myResources.GetResources();
        int longestLength= 0;
        for(int i = 0; i < temp.Length; i++)
        {
            if(temp[i].Length > longestLength)
            {
                longestLength = temp[i].Length;
            }
        }
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = temp[i].PadRight(longestLength, ' ') + resources[i];
        }
        return temp;
    }
    public string GetRequiredResourceString(Resources r)
    {
        string[] temp = (string[])resourcesName.Clone();
        string rtnVal = "(";
        int[] resources = r.GetResources();
        int longestLength = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].Length > longestLength)
            {
                longestLength = temp[i].Length;
            }
        }

        for (int i = 0; i < temp.Length; i++)
        {
            rtnVal += temp[i].PadRight(longestLength, ' ') + "-" + resources[i];
            if (i < temp.Length - 1) rtnVal += " ";
        }

        return rtnVal+")";
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
    public Resources(int[] resourceArr)
    {
        this.resources = (int[])resourceArr.Clone();
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
    protected int buildingId;
    protected bool isActivated;
    protected string name;
    protected string displayStringActivated;
    protected string displayStringInactivated;

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
    public bool CheckIsActivated()
    {
        return this.isActivated;
    }
    public Resources GetPrice()
    {
        return this.price;
    }
    public string GetName()
    {
        return this.name;
    }
    public void Activate()
    {
        this.isActivated = true;
    }
}

public class Facility : Building
{
    LambdaFuncInt onClickEvent;
    public Facility(int pBuildingId, 
        string pName, 
        string pDisplayStringActivated,
        string pDisplayStringInactivated,
        Resources pPrice,
        LambdaFuncInt onClickEvent) : base(pBuildingId, 
            pName,
            pDisplayStringActivated, 
            pDisplayStringInactivated, 
            pPrice)
    {
        this.onClickEvent = onClickEvent;
    }
    public override void OnClickListener()
    {
        this.onClickEvent(this.buildingId);
    }
}