using System.Collections.Generic;
using RTS.Currencies;
using RTS.Healths;
using RTS.Units;
using UnityEngine;
using Zenject;

namespace RTS.UI
{
    public class UnitView : MonoView<Unit>, ITickable, IDamageable
    {
        public SpriteRenderer renderer;
        public HealthBar healthBar;
        public Collider2D BodyCollider;
        public Collider2D SearchCircle;
        
        public UnitMovement movementStrategy;
        public UnitEnemyTargetDetector EnemyDetector;
        public UnitGatherTargetDetector GatherDetector;
        public UnitHealthSystem UnitHealthSystem;
        public UnitAttackSystem UnitAttackSystem;
        
        public UnitStateMachine StateMachine;

        public FactionState FactionState;
        
        public Dictionary<FactionType, Color> colorView = new()
        {
            {FactionType.Red, Color.red},
            {FactionType.Green, Color.green}
        };

        public void SetDependencies(FactionState factionState)
        {
            FactionState = factionState;
        }
        
        public override void Set(Unit source)
        {
            base.Set(source);
            SetBehaviour();
            SetView(source);
        }

        void SetBehaviour()
        {
            StateMachine = new UnitStateMachine(this);
            
            EnemyDetector = new UnitEnemyTargetDetector(Source);
            GatherDetector = new UnitGatherTargetDetector();
            UnitHealthSystem = new UnitHealthSystem(Source);
            UnitAttackSystem = new UnitAttackSystem(Source);
            
            EnemyDetector.Initialize();
            GatherDetector.Initialize();
        }

        void SetView(Unit source)
        {
            renderer.color = colorView[source.Faction];
            healthBar.Set(source);
        }

        public void Tick()
        {
            UnitAttackSystem?.Tick();
            StateMachine?.Tick();
        }
        
        public void TakeDamage(int amount) => UnitHealthSystem.TakeDamage(amount);
        public void ClickToMove(Vector3 position) => movementStrategy.MoveTo(position, Source.Speed);
        public void OnTriggerEnter2D(Collider2D col)
        {
            EnemyDetector.Add(col.transform);
            GatherDetector.Add(col.transform);
        } 
        public void OnTriggerExit2D(Collider2D col)
        {
            EnemyDetector.Remove(col.transform);
            GatherDetector.Remove(col.transform);
        } 

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        void OnDestroy()
        {
            StateMachine = null;
            UnitAttackSystem = null;
        }
    }
}
