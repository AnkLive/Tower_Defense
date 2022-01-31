using System;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyName { Bot, Car, Tank, Boss }

[Serializable]
public class Wave
{
    public EEnemyName _enemyName;
    public int _enemyCount;
    public float _timeBetweenEnemy;
}

public class WaveManager : MonoBehaviour
{
    [field: SerializeField, HideInInspector]
    public float _timeBetweenWaves { get; set; }
    [field: SerializeField, HideInInspector]
    public List<Wave> _wavesList = new List<Wave>();
}
