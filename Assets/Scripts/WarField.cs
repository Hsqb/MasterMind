using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;

public class WarField {
    private static int version = 1;
	public EnemyAi masterMind;
	public OurAi warMachine;
	private int turn;
	public WarField(){
		turn = 1;
        masterMind = new EnemyAi(2000, 10, 0);
        warMachine = new OurAi(500, 10, 0);
    }

	public int GetCurrentTurn(){
		return this.turn;
	}
	public void nextTurn(){
		this.turn++;
	}
    public string Stringify()
    {
        /*
        (version):(turn):(ourhp):(ourArmy):(ourAdvArmy):
        (currentAp):(currentMaxAp):(resources):
        (enemyhp):(enemyArmy):(enemyAdvArmy)
         */
        string[] tmpArr = new string[]{
            version.ToString(),
            turn.ToString(),
            warMachine.GetHp().ToString(),
            warMachine.GetArmy().GetArmyNum().ToString(),
            warMachine.GetArmy().GetAdvArmyNum().ToString(),
            warMachine.GetAP().GetCurrentAp().ToString(),
            warMachine.GetAP().GetCurrentMaxAp().ToString(),
            warMachine.GetResourceManager().ToString(),
            warMachine.GetHp().ToString(),
            warMachine.GetArmy().GetArmyNum().ToString(),
            warMachine.GetArmy().GetAdvArmyNum().ToString()
        };
        return String.Join(":", tmpArr);
    }
    public void Parse(string savedData)
    {
        
        string[] data = savedData.Split(':');
        //version Check
        if (data[0] == "1")
        {
            
            //turn
            this.turn = Int32.Parse(data[1]);
            //ourAiHp
            this.masterMind = new EnemyAi(Int32.Parse(data[2]), Int32.Parse(data[3]), Int32.Parse(data[4]));
            this.warMachine = new OurAi(Int32.Parse(data[8]), Int32.Parse(data[9]), Int32.Parse(data[10]));
            this.warMachine.GetAP().AddCurrentMaxAp();

            int savedCurrentAp = Int32.Parse(data[5]);
            int savedMaxAp = Int32.Parse(data[6]);
            for (int i = 0; i < AP.MAX_AP; i++)
            {
                if(this.warMachine.GetAP().GetCurrentMaxAp() < savedMaxAp) { 
                    this.warMachine.GetAP().AddCurrentMaxAp();
                    
                }
            }
            this.warMachine.GetAP().ResetCurrentAp();
            for (int i = 0; i < AP.MAX_AP; i++)
            {
                if (this.warMachine.GetAP().GetCurrentAp() > savedMaxAp)
                    this.warMachine.GetAP().SubCurrentAp();
            }

            //resources
            ResourceManager rm = this.warMachine.GetResourceManager();
            rm.ReceiveResource(rm.ToResource(data[7]));
        }

    } 
}