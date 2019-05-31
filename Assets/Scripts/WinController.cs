using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    [SerializeField] private Text winText;
    private int player;

    void Start()
    {
        player = PlayerPrefs.GetInt("Winner");
        if (player == 1 || player == 2)
        { 
            winText.text = "Player " + player + " wins";
        }
        if (player == 3)
        {
            winText.text = "Timer ran out. Nobody wins";
        }
    }
}
