using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;
public abstract class Ai {
	protected int hp;
    protected Army army;
	public abstract int GetHp();
	public abstract void AddHp(int hp);
	public abstract void SubHp(int hp);
	public abstract Army GetArmy();
}

public class EnemyAi : Ai{

    public EnemyAi(int pHp, int pArmyNum, int pAdvArmyNum)
    {
        this.hp = pHp;
        this.army = new Army(pArmyNum, pAdvArmyNum);
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
    public OurAi(int pHp, int pArmyNum, int pAdvArmyNum)
    {
        this.hp = pHp;
        this.army = new Army(pArmyNum, pAdvArmyNum);
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
        Resources tempPrice;
        Resources tmpProduct;
        
        for (int i = 0; i < st.Length; i++)
        {
            //make price
            tempPrice = new Resources(StringIntToIntArr(st[i][2]));
            tmpProduct = new Resources(StringIntToIntArr(st[i][5]));

            facs.Add(new Facility(Int32.Parse(st[i][0]), st[i][1],
                st[i][1] + "\n" + this.rm.GetFormattedResourceString(tmpProduct, true),
                "Activate "+st[i][1] + "\n" + this.rm.GetFormattedResourceString(tempPrice),
                tempPrice,
                tmpProduct,
                new Resources(StringIntToIntArr(st[i][3])),
                new Army(StringIntToIntArr(st[i][4])),
                new Army(StringIntToIntArr(st[i][6])),
                lfi[i]
            ));
        }
        facs[0].Activate();
    }

    private int[] StringIntToIntArr(string arr)
    {
        return new List<string>(arr.Split(' ')).Select(x => Int32.Parse(x)).ToArray();
    }
}

/*
             "Power Plant\n(Electricity +3)",
            "Ore Mine\n(Ore +1)",
            "Micro Chips Plant\n(Ore -1 Micro Chips +2)",
            "Ingot Plant\n(Ore -1 Ingot +1)",
            "Newclear Silo\n(Ingot -2 Energy -3 Newclear +1)"
     */
