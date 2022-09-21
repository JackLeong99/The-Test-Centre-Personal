using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Dictionary<string, bool> gatesReached;
    public Dictionary<string, bool> obtainedCollectables;
    public int checkpointIndex;

    public GameData()
    {
        gatesReached = new Dictionary<string, bool>();
        obtainedCollectables = new Dictionary<string, bool>();
        checkpointIndex = -1;
    }

}
