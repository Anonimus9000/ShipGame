using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCore : MonoBehaviour
{
    [SerializeField] private CannonController _cannon;
    [SerializeField] private CoreController _core;

    public CoreController SpawnCore()
    { 
        CoreController spawnedCore;

        spawnedCore = Instantiate(_core, _cannon.transform);
        _core = spawnedCore;

        return spawnedCore;
    }
}
