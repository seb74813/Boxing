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
        winText.text = "Player " + player + " wins";
    }
}
