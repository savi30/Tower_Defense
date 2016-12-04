using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    BuildManager buildManager;

    private Color startColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if(turret!=null)
        {
            Debug.Log("Can't build here");
            return;
        }

        //Build turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret= (GameObject)Instantiate(turretToBuild, transform.position+positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color=hoverColor;

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
