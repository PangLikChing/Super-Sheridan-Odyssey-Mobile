using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryAndFailureDataTransfer : MonoBehaviour
{
    //Member declaration
    int numOfCoinsHeld;

    public Text gameScore;

    // Start is called before the first frame update
    void Start()
    {
        gameScore.text = "Score: " + numOfCoinsHeld;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Once this script is enabled, load in the data and set the local variables equal to its values.
    void OnEnable()
    {
        numOfCoinsHeld = PlayerPrefs.GetInt("Coins");
    }
}
