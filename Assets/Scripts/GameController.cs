using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text timerText;
    public float mainTimer;
    public GameObject spawn1, spawn2;
    private float timer;
    private bool canCount = true;
    private GameObject player1, player2;
    [SerializeField] private List<GameObject> players = new List<GameObject>();


    void Start()
    {
        timer = mainTimer;
        foreach (GameObject player in players)
        {
            if (player.name == PlayerPrefs.GetString("Player1"))
            {
                player1 = Instantiate(player);
                player1.transform.position = new Vector2(-3, 2);
            }
            if (player.name == PlayerPrefs.GetString("Player2"))
            {
                player2 = Instantiate(player);
                player2.transform.position = new Vector2(3, 2);
            }
        }
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
            PlayerPrefs.SetInt("Winner", 3);
            SceneManager.LoadScene("WinScreen");
        }
    }
}
