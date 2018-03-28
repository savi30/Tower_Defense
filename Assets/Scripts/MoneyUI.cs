using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (moneyText.text != "$" + PlayerStats.Money.ToString())
        {
            moneyText.text = "$" + PlayerStats.Money.ToString();
          
        }
        
	
	}
   
}
