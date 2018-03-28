using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turret;

    public TurretBlueprint turretBlueprint;
    public bool isUpgraded;

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
  
        if(turret!=null)
        {                                
            buildManager.SelectNode(this);
            return; 
        }


        if (!buildManager.CanBuild)
            return;

        //Build turret
        BuildTurret(buildManager.GetTurretToBuild());
       
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

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("not enough money to build that");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buidEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money to upgade that");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Getting rid of the old turret
        Destroy(turret.gameObject);

        //Building the new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buidEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
