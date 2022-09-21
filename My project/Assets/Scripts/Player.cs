using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static private Player instance;
    static public Player Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("There is no Player instance in the scene");
            }
            return instance;
        }
    }

    private int playerDeathCounter = 1;
    public int PlayerDeathCounter
    {
        get
        {
            return playerDeathCounter;
        }
    }

    public float moveSpeed = 10f;
    private float space=0;
    private float timer = 0;
    private float jump = 0;
    private float jumpHeight = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=0)
        {
            timer -= Time.deltaTime;
            jump = 1;
        }
        float dx = Input.GetAxis("Horizontal");
        float dy =Input.GetAxis("Vertical");
        transform.Translate(new Vector3(dx, jump, dy) * moveSpeed * Time.deltaTime);

        //jump += jumpHeight * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = 2;
           // transform.Translate(new Vector3(dx, jumpHeight, dy) * moveSpeed * Time.deltaTime);

        }
        jump = 0;

    }
}
