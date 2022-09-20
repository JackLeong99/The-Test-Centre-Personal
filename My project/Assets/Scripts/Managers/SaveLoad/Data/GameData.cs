using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public SerializableDictionary<string, bool> gatesReached;

    public GameData()
    {
        gatesReached = new SerializableDictionary<string, bool>();
    }

}
