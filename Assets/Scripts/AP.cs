using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;

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
