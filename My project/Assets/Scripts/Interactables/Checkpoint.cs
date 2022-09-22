using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Material onMat;

    [SerializeField]
    private Material offMat;

    [SerializeField]
    private GameObject light;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager.instance.SetCheckpoint(this.gameObject);
        }

        switch (GameManager.instance.currentCheckpoint[GameManager.instance.currentIndex] == this.gameObject) 
        {
            case true:
                light.GetComponent<Renderer>().material = onMat;
                break;
            default:
                light.GetComponent<Renderer>().material = offMat;
                break;
        }
    }
}
