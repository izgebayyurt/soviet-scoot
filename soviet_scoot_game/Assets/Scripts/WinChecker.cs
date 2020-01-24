﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class WinChecker : MonoBehaviour
{
    public Tilemap road;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.caught) //if you get caught
        {
            gm.SetCoins((int)(gm.GetCoins() * gm.coinLossRate));
            gm.caught = false;

            if (gm.GetCoins() < gm.minCoinCount)
            {
                SceneManager.LoadScene(3); //End/lose screen index, lose condition
            }
            else
            {
                //Load the "Caught" screen, you got caught boi
                //For now just loads the end screen, but should be changed.
                SceneManager.LoadScene(3);
            }
        }
        else if (Mathf.Abs(road.transform.position.x) > gm.winDistance) //if you're not caught and reach end distance
        {
            if (gm.GetCoins() >= gm.winCoins)
            {
                //Load the Win screen win condition
                //For now just loads the main menu
                SceneManager.LoadScene(4);

            }
            else
            {
                // You done have enough coins, restart scene?
                // For now just restarts with nothing in the middle, potentially goes to caught screen or w/e
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }
}
