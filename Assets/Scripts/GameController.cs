using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
    private float timer;
    public float startTime;
    private bool canCount = true;

    void Start()
    {
        timer = startTime;
    }

    void Update()
    {
        if (timer > 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f)
        {
            timer = 0.0f;
            timerText.text = "0.00";
            Win();
        }
    }

    static public void Win()
    {

    }
}
