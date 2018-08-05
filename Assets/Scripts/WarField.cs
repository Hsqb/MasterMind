using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public OurAi(int pHp, int pArmyNum)
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

public class Wallet
{
<<<<<<< HEAD
	public int Electro = 0;
	public int Ingot = 133;
=======
	public Wallet(){
		this.resourceContainer = new int[5];
	}
	private int[] resourceContainer;

>>>>>>> 63c66cfe00074728c6846900352a643f4c26ced6
}
public class Price
{

}
public class Building
{
    
}
public class Facility : Building
{

}
public class AdvFacility : Building
{

}