using UnityEngine;

public class TowerDamage : Damage
{
    [field: SerializeField, HideInInspector] public ParticleSystem _shotEffect;
    public override GameObject _obj { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public override float _countDamage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public override float _cooldown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public override float _timeStamp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
