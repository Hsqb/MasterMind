using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;

public class Building
{
    protected int buildingId;
    protected bool isActivated;
    protected string name;
    protected string displayStringActivated;
    protected string displayStringInactivated;

    private Resources price;
    private Army armyAsMaterial;
    private Resources cost;
    private Resources product;
    private Army rollouted;

    public Building(int pBuildingId,
        string pName, 
        string pDisplayStringActivated,
        string pDisplayStringInactivated,
        Resources pPrice,
        Resources pProduct,
        Resources pCost,
        Army pMaterial,
        Army pRollouted
        )
    {
        this.buildingId = pBuildingId;
        this.name = pName;
        this.price = pPrice;
        this.isActivated = false;
        this.displayStringActivated = pDisplayStringActivated;
        this.displayStringInactivated = pDisplayStringInactivated;
        this.product = pProduct;
        this.cost = pCost;
        this.rollouted = pRollouted;
        this.armyAsMaterial = pMaterial;
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

    public string GetName()
    {
        return this.name;
    }
    public void Activate()
    {
        this.isActivated = true;
    }
    public Resources GetPrice()
    {
        return this.price;
    }
    public Resources GetCost()
    {
        return this.cost;
    }
    public Resources GetProduct()
    {
        return this.product;
    }

}

public class Facility : Building
{
    private LambdaFuncInt onClickEvent;
    public Facility(int pBuildingId, 
        string pName, 
        string pDisplayStringActivated,
        string pDisplayStringInactivated,
        Resources pPrice,
        Resources pProduct,
        Resources pCost,
        Army pMaterial,
        Army pRollouted,
        LambdaFuncInt onClickEvent) : base(pBuildingId, 
            pName,
            pDisplayStringActivated, 
            pDisplayStringInactivated, 
            pPrice,
            pProduct,
            pCost,
            pMaterial,
            pRollouted)
    {
        this.onClickEvent = onClickEvent;
    }
    public override void OnClickListener()
    {
        //Debug.Log("this.buildingId : " + this.buildingId);
        this.onClickEvent(this.buildingId);
    }
}