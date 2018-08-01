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
		masterMind = new EnemyAi();
		warMachine = new OurAi();
	}
	public int getCurrentTurn(){
		return this.turn;
	}
	public void nextTurn(int x){
		this.turn+=x;
	}
}

public abstract class Ai {
	private int hp;
	private Army army;
	public int getHp();
	public void addHp(int hp);
	public void subHp(int hp);
	public Army getArmy();
}

public class EnemyAi : Ai{
	public override int getHp(){
		return this.hp;
	}
	public override void addHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override void subHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override Army getArmy(){
		return this.army;
	};
}

public class OurAi : Ai{
	public override int getHp(){
		return this.hp;
	}
	public override void addHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override void subHp(int hp){
		if(hp < 0) hp = 0;
		this.hp += hp;
	}
	public override Army getArmy(){
		return this.army;
	};
}
