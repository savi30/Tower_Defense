﻿using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserBeamer;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void SelectStandardTurret()
    {
        Debug.Log("am luat muahahaah");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissleLauncher()
    {
        Debug.Log("am luat missle launcher");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("am luat laser Beamer");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
