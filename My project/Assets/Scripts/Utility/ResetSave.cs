using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSave : MonoBehaviour, IDataPersistence
{
    private GameData currentSave;
    private bool reset;

    private void Update()
    {
        if (Input.GetKeyDown("c")) 
        {
            reset = true;
            DataPersistenceManager.instance.SaveGame();
        }
    }

    public void LoadData(GameData data)
    {
        //do not delete this method it is needed for the interface
    }

    public void SaveData(ref GameData data)
    {
        if (reset == true)
        {
            data.gatesReached.Clear();
        }
    }
}
