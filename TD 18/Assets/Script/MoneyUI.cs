using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUI : MonoBehaviour {


    public Text moneyText;

    private void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }


}
