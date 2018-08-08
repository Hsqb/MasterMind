using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;

public class Army
{
    private int armyNum;
    private int advArmyNum;

    public Army(int armyNum, int advArmyNum)
    {
        this.armyNum = armyNum;
        this.advArmyNum = advArmyNum;
    }
    public Army(int[] armyNumArr)
    {
        this.armyNum = armyNumArr[0];
        this.advArmyNum = armyNumArr[1];
    }
    public int GetArmyNum()
    {
        return this.armyNum;
    }
    public void SetArmyNum(int armyNum)
    {
        this.armyNum = armyNum;
    }
    public int GetAdvArmyNum()
    {
        return this.advArmyNum;
    }
    public void SetAdvArmyNum(int advArmyNum)
    {
        this.advArmyNum = advArmyNum;
    }
}