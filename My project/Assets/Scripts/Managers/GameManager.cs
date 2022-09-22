using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public static GameManager instance { get; private set; }

    [SerializeField]
    private Vector3 StartingPosition;

    public List<GameObject> currentCheckpoint;

    public int currentIndex = -1;

    public GameObject player;

    public GameObject mainCamera;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogError("Multiple game managers");
        }
        instance = this;
        currentCheckpoint = GameObject.FindGameObjectsWithTag("checkpoint").ToList();
        this.player = GameObject.FindWithTag("Player");
        this.mainCamera = GameObject.FindWithTag("MainCamera");
        this.mainCamera.GetComponent<GlitchEffect>().enabled = false;
    }

    public void SetCheckpoint(GameObject checkpoint) 
    {
        currentIndex = currentCheckpoint.IndexOf(checkpoint);
        DataPersistenceManager.instance.SaveGame();
        Debug.Log("Set checkpoint as: " + currentCheckpoint[currentIndex].transform.root);
    }

    public void ReturnToCheckpoint() 
    {
        switch (currentIndex) 
        {
            case (>= 0):
                player.transform.position = currentCheckpoint[currentIndex].transform.position;
                break;
            default:
                player.transform.position = StartingPosition;
                break;
        }
    }

    public void LoadData(GameData data) 
    {
        this.currentIndex = data.checkpointIndex;
        ReturnToCheckpoint();
    }

    public void SaveData(ref GameData data) 
    {
        data.checkpointIndex = this.currentIndex;
    }

    public void toggleGlitchOn() 
    {
        this.mainCamera.GetComponent<GlitchEffect>().enabled = true;
    }
}
