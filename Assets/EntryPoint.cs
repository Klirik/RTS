using RTS.UI;
using UnityEngine;
using Zenject;

namespace RTS
{
    public class EntryPoint : MonoBehaviour
    {
        IFactory<UnitView> unitViewfactory;
        DefaultUnitFactory unitModelFactory;
        UpdateManager updateManager;
        
        [Inject]
        void Init(IFactory<UnitView> unitViewfactory, DefaultUnitFactory unitModelFactory, UpdateManager updateManager)
        {
            this.unitViewfactory = unitViewfactory;
            this.unitModelFactory = unitModelFactory;
            this.updateManager = updateManager;
        }
        void Start()
        {
            ShowUnit(FactionType.Red, Vector3.up*5, "1.1Red");
            ShowUnit(FactionType.Red, Vector3.left*5, "1.2Red");
            ShowUnit(FactionType.Red, Vector3.up*7, "1.3Red");
            ShowUnit(FactionType.Red, Vector3.left*7, "1.4Red");
            ShowUnit(FactionType.Red, Vector3.up*9, "1.5Red");
            ShowUnit(FactionType.Red, Vector3.left*9, "1.6Red");
            ShowUnit(FactionType.Green, Vector3.right*5, "2.1Green");
            ShowUnit(FactionType.Green, Vector3.down*5, "2.2Green");
            ShowUnit(FactionType.Green, Vector3.right*7, "2.3Green");
            ShowUnit(FactionType.Green, Vector3.down*7, "2.4Green");
            ShowUnit(FactionType.Green, Vector3.right*9, "2.5Green");
            ShowUnit(FactionType.Green, Vector3.down*9, "2.6Green");
        }

        void ShowUnit(FactionType factionType, Vector3 position, string name)
        {
            var weapon = new Weapon(Random.Range(1, 3), Random.Range(1, 3), 5f);
            var unitConfig = new UnitConfig(speed: 3f, factionType
                , health: 4, maxHealth: 4
                , weapon);
            var unit = unitModelFactory.Create(unitConfig);
            var unitView = unitViewfactory.Create();
            unitView.transform.position = position;
            unitView.Set(unit);
            unitView.name = name;
            updateManager.Add(unitView);
        }
    }
}
