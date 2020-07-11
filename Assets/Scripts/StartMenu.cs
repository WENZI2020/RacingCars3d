using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GAMETYPE
{
    SINGLE,
    MULTI
}
public class StartMenu : MonoBehaviour
{
    public GameObject panelA;
    public GameObject panelB;
    public GAMETYPE gAMETYPE;
    // Start is called before the first frame update
    void Start()
    {
        panelA.SetActive(true);
        panelB.SetActive(false);
    }
    void Update()
    {

    }
    public void PanelA()
    {
        panelA.SetActive(true);
        panelB.SetActive(false);
    }
    public void PanelB()
    {
        panelA.SetActive(false);
        panelB.SetActive(true);
    }
    // Update is called once per frame
    public void PlaySingle()
    {
        gAMETYPE = GAMETYPE.SINGLE;
        PlayerPrefs.SetString("GAMETYPE", "SINGLE");
        SceneManager.LoadScene(1);
    }
    public void PlayMulti()
    {
        gAMETYPE = GAMETYPE.MULTI;
        PlayerPrefs.SetString("GAMETYPE", "MULTI");
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
