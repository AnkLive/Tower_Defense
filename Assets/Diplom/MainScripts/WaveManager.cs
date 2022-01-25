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
    
    [field: SerializeField, Header("��� �����")]
    public EEnemyName _enemyName { get; private set; }
    [field: SerializeField, Range(1, 6), Header("���������� ������")]
    public int _enemyCount { get; private set; } = 1;
    [field: SerializeField, Range(0.1f, 5f), Header("����� ����� ������� ������")]
    public float _timeBetweenEnemy { get; private set; }
}

public class WaveManager : MonoBehaviour
{
    [field: SerializeField, Header("����� ����� �������")]
    public float _timeBetweenWaves { get; private set; }
    [field: SerializeField, Header("���������� ����")]
    public List<Wave> _wavesList { get; private set; } = new List<Wave>();
}
