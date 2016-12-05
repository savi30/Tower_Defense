﻿using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("more than 1 build managers");
        }
        instance = this;
    }

    void Start()
    {
        
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {

        if(PlayerStats.Money<turretToBuild.cost)
        {
            Debug.Log("not enough money to build that");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;


        GameObject turret= (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("turret buit, money left" + PlayerStats.Money);
    }
}
