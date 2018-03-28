using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject UI;

    private Node target;

    public Button upgradeButton;

    public Text upgradeCostText;
    public Text sellAmountText;

    public void SetTarget(Node _target)
    {
        target = _target;

        if (!target.isUpgraded)
        {
            upgradeButton.interactable = true;
            upgradeCostText.text = "UPGRADE\n$" + target.turretBlueprint.upgradeCost.ToString();
        }
        else
        {
            upgradeButton.interactable = false; 
            upgradeCostText.text = "UPGRADE\nDONE!";
        }
        transform.position = target.GetBuildPosition();

        sellAmountText.text = "SELL\n$" + target.turretBlueprint.GetSellAmount().ToString();

        UI.SetActive(true);
    }
	public void Hide()
    {
        UI.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
