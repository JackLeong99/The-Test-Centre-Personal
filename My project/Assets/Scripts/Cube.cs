using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("cubeTriggered");
        GameObject other = collider.gameObject;
        if (other.tag == "platform")
        {
            this.transform.parent = other.transform;
        }
    }
}
