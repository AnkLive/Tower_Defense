using System;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyName
{
    Bot,
    Car,
    Tank,
    Boss,
}

[Serializable]
public class Wave
{
    
    [field: SerializeField, Header("Тип врага")]
    public EEnemyName _enemyName { get; private set; }
    [field: SerializeField, Range(1, 6), Header("Количество врагов")]
    public int _enemyCount { get; private set; } = 1;
    [field: SerializeField, Range(0.1f, 5f), Header("Время между спавном врагов")]
    public float _timeBetweenEnemy { get; private set; }
}

public class WaveManager : MonoBehaviour
{
    [field: SerializeField, Header("Время между волнами")]
    public float _timeBetweenWaves { get; private set; }
    [field: SerializeField, Header("Количество волн")]
    public List<Wave> _wavesList { get; private set; } = new List<Wave>();
}
