using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region Variables
    [Header("start")]
    public float xStart;
    public float yStart;
    public float zStart;
    public Vector3 begin;
    [Header("end")]
    public float xEnd;
    public float yEnd;
    public float zEnd;
    public Vector3 finish;
    [Header("speed")]
    public float speed;
    #endregion

    private Vector3 start;
    private Vector3 end;
    private bool starting=true;
    private bool ending=false;

    // Start is called before the first frame update
    void Start()
    {
        start = (begin - finish).normalized;
        end = (finish - begin).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if(starting)
        {
            transform.Translate(start * Time.deltaTime *speed);
            if(transform.position.x<= xStart && transform.position.y <= yStart && transform.position.z <= zStart)
            {
                starting = false;
                ending = true;
            }
        }
        if(ending)
        {
            transform.Translate(end * Time.deltaTime *speed);
            if (transform.position.x >= xEnd && transform.position.y >= yEnd && transform.position.z >= zEnd)
            {   
                ending = false;
                starting = true;
                
            }
        }
    }
}
