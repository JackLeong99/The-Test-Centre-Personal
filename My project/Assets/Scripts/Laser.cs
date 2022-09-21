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
    private float laserTimer;
    public float laserOffTimer = 2;
    public float laserResetTimer = 2;
    public float laserFireTimer = 2;

    public Material green;
    public Material yellow;
    public Material red;

    private MeshRenderer myLaser;

    // Start is called before the first frame update
    void Start()
    {
        laserState = LaserState.Off;
        myLaser = GetComponent<MeshRenderer>();
        laserTimer = laserOffTimer;
    }

    // Update is called once per frame
    void Update()
    {
        laserTimer -= Time.deltaTime;

        switch (laserState)
        {
            case LaserState.Off:
                if (laserTimer <= 0)
                {
                    myLaser.material = green;
                    laserTimer = laserResetTimer;
                    laserState = LaserState.Reset;
                }
                break;

            case LaserState.Reset:
                if(laserTimer <= 0)
                {
                    myLaser.material = yellow;
                    laserTimer = laserFireTimer;
                    laserState = LaserState.Firing;
                }
                break;

            case LaserState.Firing:
                if (laserTimer <= 0)
                {
                    myLaser.material = red;
                    laserTimer = laserOffTimer;
                    laserState = LaserState.Off;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && laserState == LaserState.Firing) 
        {
            GameManager.instance.ReturnToCheckpoint();
        }
    }

}
