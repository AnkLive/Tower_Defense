using UnityEngine;

public class ObjectDamage : Damage
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private float countDamage;
    [SerializeField] private float cooldown;
    public override float _countDamage { get => countDamage; set => countDamage = value; }
    public override float _cooldown { get => cooldown; set => cooldown = value; }
    public override GameObject _obj { get; set; }

    private void Awake() => base.Subscribe();

    private void Start() => UpdateTimeStamp();

    public override void IsDamage(GameObject TrackingObj)
    {
        base.IsDamage(TrackingObj);

        if (_timeStamp <= Time.time)
        {
            _shotEffect.Play();
            _obj.GetComponent<Health>().TakeDamage(_countDamage);
            _timeStamp = Time.time + _cooldown;
        }
    }

    public override void UpdateTimeStamp() => base.UpdateTimeStamp();
    
    private void OnDisable() => base.Unsubscribe();
}
