using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid() 
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool collected = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            collected = true;
            this.gameObject.SetActive(false);
        }
    }

    public void LoadData(GameData data) 
    {
        data.obtainedCollectables.TryGetValue(id, out collected);
        if (collected)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data) 
    {
        if (data.obtainedCollectables.ContainsKey(id)) 
        {
            data.obtainedCollectables.Remove(id);
        }
        data.obtainedCollectables.Add(id, collected);
    }
}
