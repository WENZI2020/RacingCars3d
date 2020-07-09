using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvMenu : MonoBehaviour
{
    public GameObject contiune;
    public GameObject suspend;
    // Start is called before the first frame update
    void Start()
    {
        contiune.SetActive(false);
        suspend.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Contiune()
    {
        contiune.SetActive(false);
        suspend.SetActive(true);
    }
    public void Suspend()
    {
        contiune.SetActive(true);
        suspend.SetActive(false);
    }

}
