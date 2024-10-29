using Assets.Scripts;
using System.Threading.Tasks;
using UnityEngine;

public class ShootingState : BaseState
{
    private ShootingConfig _config;
    private Transform _muzzle; 
    private AudioSource _audioSource;
    private bool _alreadyAttacked;

    public ShootingState(IStateSwitcher switcher, StateMachineData data, EnemyContext enemyContext) : base(switcher, data, enemyContext)
    {
        _config = enemyContext.Config.ShootingConfig;
        _audioSource = enemyContext.AudioSource;
        _muzzle = enemyContext.Muzzle;
    }

    private float _speed => _config.Speed;
    private AudioClip _shootingSound => _config.ShootingSound;
    private ParticleSystem _shootingEffect => _config.ShootingEffect;
    private float _timeBetweenShoots => _config.TimeBetweenShoots;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _speed;
        Agent.speed = Data.Speed;
        View.SetShootingState();
    }

    public override void Exit()
    {
        base.Exit();
        View.UnsetShootingState();
    }

    public override void HandleConditions()
    {
        base.HandleConditions();

        if (!PlayerDetector.PlayerInShootingRange)
            StateSwitcher.SwitchState<ChasingState>();
    }

    public override void Update()
    {
        base.Update();
        AttackPlayer();
    }

    private async void AttackPlayer()
    {
        Transform.LookAt(PlayerDetector.Player.transform);

        if (!_alreadyAttacked) 
        {
            _audioSource.PlayOneShot(_shootingSound);
            ParticleSystem shootEffect = ParticleSystem.Instantiate(_shootingEffect, _muzzle.position, _muzzle.rotation);
            EnemysProjectile projectile = ObjectPool.instance.GetBullet();
            projectile.transform.position = _muzzle.position;
            projectile.ProjcetileFly(_muzzle.forward);  

            _alreadyAttacked = true;

            await Task.Delay((int)_timeBetweenShoots * 1000);
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }
}