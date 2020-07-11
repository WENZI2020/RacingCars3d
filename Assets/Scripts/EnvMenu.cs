using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnvMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject panels;
    public GameObject touchpad;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(true);
        panels.SetActive(false);
        touchpad.GetComponent<Image>().enabled = true;
    }
    public void Suspend()
    {
        player.SetActive(false);
        panels.SetActive(true);
        touchpad.GetComponent<Image>().enabled = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Contiune()
    {
        player.SetActive(true);
        panels.SetActive(false);
        touchpad.GetComponent<Image>().enabled = true;
    }
}
