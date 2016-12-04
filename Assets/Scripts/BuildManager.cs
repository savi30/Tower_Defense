using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private GameObject turretToBuild;

    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("more than 1 build managers");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missleLauncherPrefab;

    void Start()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
