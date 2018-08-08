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
		masterMind = new EnemyAi(2000, 10, 0);
		warMachine = new OurAi(500, 10, 0);
	}
	public int GetCurrentTurn(){
		return this.turn;
	}
	public void nextTurn(){
		this.turn++;
	}
}