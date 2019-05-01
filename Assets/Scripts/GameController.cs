using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
    public float mainTimer;
    public GameObject spawn1, spawn2;
    private float timer;
    private bool canCount = true;
    private GameObject player1, player2;


    void Start()
    {
        timer = mainTimer;
        player1 = Resources.Load<GameObject>("Prefabs/" + PlayerPrefs.GetString("Player1"));
        player2 = Resources.Load<GameObject>("Prefabs/" + PlayerPrefs.GetString("Player2"));
        Instantiate(player1, spawn1.transform);
        Instantiate(player2, spawn2.transform);
    }

    
    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f)
        {
            canCount = false;
            timerText.text = "0.0f";
            timer = 0.0f;
        }
    }
}
