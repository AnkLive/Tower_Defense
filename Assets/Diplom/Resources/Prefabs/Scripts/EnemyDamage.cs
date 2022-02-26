using UnityEngine;

public class EnemyDamage : Damage
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private float countDamage;
    [SerializeField] private float cooldown;
    public override float _countDamage { get => countDamage; set => countDamage = value; }
    public override float _cooldown { get => cooldown; set => cooldown = value; }
    public override GameObject _obj { get; set; }
    public override float _timeStamp { get; set; }

    private void Awake() => Subscribe();

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

    private void OnDisable() => Unsubscribe();

    public override void UpdateTimeStamp() => base.UpdateTimeStamp();

    public override void Subscribe() => base.Subscribe();

    public override void Unsubscribe() => base.Unsubscribe();
}
