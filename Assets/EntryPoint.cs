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
            ShowUnit(FactionType.Red, Vector3.up*2, "1Red");
            ShowUnit(FactionType.Red, Vector3.left*3, "2Red");
            ShowUnit(FactionType.Green, Vector3.right*2, "3Green");
            ShowUnit(FactionType.Green, Vector3.down*5, "4Green");
        }

        void ShowUnit(FactionType factionType, Vector3 position, string name)
        {
            var weapon = new Weapon(Random.Range(1, 3), Random.Range(1, 3), 5f);
            var unitConfig = new UnitConfig(speed: 3f, factionType
                , health: 10, maxHealth: 10
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
