using UnityEngine;
using Zenject;

namespace Enemy.EnemyBehavior.EnemyManagers
{
    public class RunManager : StateManager<RunningEnemyBehavoir>
    {
        public GameObject CurrentEnemy;
        public EnemyRunStats Stats;
        
        [Inject(Id = "SpellLayer")] private LayerMask _spellLayer;
        [Inject(Id = "Player")] private GameObject _player;
        
        public override void SetSceneUp()
        {
            CurrentState = States[RunningEnemyBehavoir.Patrol];
        }

        public override void AddStates()
        {
            PatrollState patrollingState = 
                new PatrollState(RunningEnemyBehavoir.Patrol, this, Stats, CurrentEnemy, this, _spellLayer);
            RunState runState = new RunState(RunningEnemyBehavoir.Run, this, HealthSystem, Stats, _player, CurrentEnemy);
            States.Add(RunningEnemyBehavoir.Patrol, patrollingState);
            States.Add(RunningEnemyBehavoir.Run, runState);
        }
    }
}