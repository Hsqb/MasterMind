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
        Debug.Log(Stringify());

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
}