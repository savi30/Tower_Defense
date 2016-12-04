using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void PurchaseStandardTurret()
    {
        Debug.Log("am luat muahahaah");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissleLauncher()
    {
        Debug.Log("am luat missle launcher");
        buildManager.SetTurretToBuild(buildManager.missleLauncherPrefab);
    }

}
