using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWall : MonoBehaviour, IDataPersistence
{

    [SerializeField]
    private string id;

    private bool met = false;

    public void LoadData(GameData data) 
    {
        data.gatesReached.TryGetValue(id, out met);
        if (met) 
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data) 
    {
        if (data.gatesReached.ContainsKey(id)) 
        {
            data.gatesReached.Remove(id);
        }
        data.gatesReached.Add(id, met);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && met == false) 
        {
            met = true;
            DataPersistenceManager.instance.SaveGame();
        }
    }

}
