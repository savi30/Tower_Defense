﻿using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    private Color startColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if(turret!=null)
        {
            Debug.Log("Can't build here");
            return;
        }

        //Build turret
        buildManager.BuildTurretOn(this);
       
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
