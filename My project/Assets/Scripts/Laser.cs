using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    enum LaserState 
    { 
        Off, Reset, Firing
    }

    private LaserState laserState;
    public float laserFireTimer = 5;

    public Material Yellow;
    public Material Red;

    private GameObject myLaser;

    // Start is called before the first frame update
    void Start()
    {
        laserState = LaserState.Off;
        myLaser = GetComponent<GameObject>();
        Debug.Log(myLaser);
    }

    // Update is called once per frame
    void Update()
    {
        laserFireTimer -= Time.deltaTime;

        switch (laserState)
        {
            case LaserState.Off:
                if (laserFireTimer <= 0)
                {
                    laserState = LaserState.Reset;
                }

            break;

            case LaserState.Reset:

            break;


        }
    }
}
