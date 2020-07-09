using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    private GameObject car;
    private string type;
    private float time = 0;
    public bool isStart = false;
    public bool isOver = false;
    private bool isGameCompleted = false;
    private GameObject[] carComputer;
    public Text timeLabel, startLabel, bestLabel;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Car");
        carComputer = GameObject.FindGameObjectsWithTag("CarComputer");
        type = PlayerPrefs.GetString("GAMETYPE");
        if (GAMETYPE.SINGLE.ToString() == type)
        {
            foreach(GameObject go in carComputer)
            {
                go.SetActive(false);
            }
        }
        timeLabel = GameObject.Find("Time").GetComponent<Text>();
        startLabel = GameObject.Find("Start").GetComponent<Text>();
        bestLabel = GameObject.Find("Best").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameCompleted || this.name != "Finish3dt")
        {
            return;
        }
        time += Time.deltaTime;
        if (time <= 2)
        {
            startLabel.text = "READY";
        }
        else if (time <= 3)
        {
            startLabel.text = "GO";
        }
        else
        {
            isStart = true;
            if (!isOver)
            {
                startLabel.text = string.Empty;
                timeLabel.text = "（"+(System.Math.Round(time,1) - 3).ToString()+"）";
            }
            else
            {
                time = (float)(System.Math.Round(time, 1) - 3);
                if (PlayerPrefs.HasKey("bestTime"))
                {
                    float best = PlayerPrefs.GetFloat("bestTime");
                    if (time < best)
                    {
                        PlayerPrefs.SetFloat("bestTime", Mathf.RoundToInt(time));
                        bestLabel.text = "Best!";
                    }
                    else
                    {
                        bestLabel.text = "（"+best.ToString()+".0）";
                    }
                }
                else
                {
                    PlayerPrefs.SetFloat("bestTime", Mathf.RoundToInt(time));
                    bestLabel.text = "Best!";
                }
                isGameCompleted = true;
            }
        }
    }

    [HideInInspector]
    public int rank = 1;
    public void OnTriggerEnter(Collider other)
    {
        if (this.name == "Finish3dt")
        {
            if(other.gameObject.name == "Collider_Bottom")
            {
                isOver = true;
                startLabel.text = "No." + rank;
            }
            if(other.gameObject.name == "Collider_BottomComputer")
            {
                rank += 1;
            }
        }
    }
}
