using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TeleportStart : MonoBehaviour
{
    public static TeleportStart instance;

    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport()
    {
     //   player.GetComponent<ThirdPersonController>
    }
}
