using System;
using System.Collections.Generic;
using UnityEngine;

namespace RTS.UI
{
    public class UnitView : MonoView<Unit>, ITickable, IDamageable
    {
        public SpriteRenderer renderer;
        public Collider2D BodyCollider;
        public Collider2D SearchCircle;
        
        public UnitMovement movementStrategy;
        public UnitEnemyTargetDetector EnemyDetector;
        public UnitHealthSystem UnitHealthSystem;
        public UnitAttackSystem UnitAttackSystem;
        
        UnitStateMachine stateMachine;
            
        public Dictionary<FactionType, Color> colorView = new()
        {
            {FactionType.Red, Color.red},
            {FactionType.Green, Color.green}
        };

        public override void Set(Unit source)
        {
            base.Set(source);
            SetBehaviour();
            SetView(source);
        }

        void SetBehaviour()
        {
            stateMachine = new UnitStateMachine(this);
            
            EnemyDetector = new UnitEnemyTargetDetector(Source);
            UnitHealthSystem = new UnitHealthSystem(Source.Health, Source.MaxHealth);
            UnitHealthSystem.OnUpdate += () => { Debug.Log($"{name}: take damage health, health = {UnitHealthSystem.Health.Value}"); };

            UnitAttackSystem = new UnitAttackSystem(Source.Weapon);

            EnemyDetector.Initialize();
        }

        void SetView(Unit source)
        {
            renderer.color = colorView[source.Faction];
        }

        public void Tick()
        {
            UnitAttackSystem?.Tick();
            stateMachine?.Tick();
        }
        
        public void TakeDamage(int amount) => UnitHealthSystem.TakeDamage(amount);
        public void ClickToMove(Vector3 position) => movementStrategy.MoveTo(position, Source.Speed);
        public void OnTriggerEnter2D(Collider2D col) => EnemyDetector.Add(col.transform);
        public void OnTriggerExit2D(Collider2D col) => EnemyDetector.Remove(col.transform);

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        void OnDestroy()
        {
            stateMachine = null;
            UnitAttackSystem = null;
        }
    }
}
