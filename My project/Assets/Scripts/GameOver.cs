using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    public GameObject deathMenu;
    // Start is called before the first frame update
    void Start()
    {
        deathMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMenu()
    {
        deathMenu.SetActive(true);
        //will need to disable player
    }

    public void Death()
    {
        deathMenu.SetActive(false);
        TeleportStart.instance.Teleport();
    }
}
