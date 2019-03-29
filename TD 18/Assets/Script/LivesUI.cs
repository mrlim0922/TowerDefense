using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {


    public Text lovesText;

    private void Update()
    {
        lovesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
