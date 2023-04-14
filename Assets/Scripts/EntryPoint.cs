using System.Collections.Generic;
using RTS.UI;
using RTS.Units;
using UnityEngine;
using Zenject;

namespace RTS
{
    public class EntryPoint : MonoBehaviour
    {
        IFactory<UnitView> unitViewfactory;
        UnitFactory unitModelFactory;
        UpdateManager updateManager;

        public List<UnitConfigSO> redUnits; 
        public List<UnitConfigSO> greenUnits; 
        
        [Inject]
        void Init(IFactory<UnitView> unitViewfactory, UnitFactory unitModelFactory, UpdateManager updateManager)
        {
            this.unitViewfactory = unitViewfactory;
            this.unitModelFactory = unitModelFactory;
            this.updateManager = updateManager;
        }
        void Start()
        {
            CreateUnit(FactionType.Red, GetLineFormation(-3, redUnits), redUnits);
            CreateUnit(FactionType.Green, GetLineFormation(3, greenUnits), greenUnits);
        }

        void CreateUnit(FactionType factionType, Vector3 position, List<UnitConfigSO> configs)
        {
            for (var i = 0; i < configs.Count; i++)
            {
                ShowUnit(configs[i], factionType, position, $"1.{i}{factionType}");
                position += Vector3.up * 1.5f;
            }
        }

        void ShowUnit(UnitConfigSO unitConfig, FactionType factionType, Vector3 position, string name)
        {
            var unit = unitModelFactory.Create(unitConfig, factionType);
            var unitView = unitViewfactory.Create();
            unitView.name = name;
            unitView.transform.position = position;
            unitView.Set(unit);
            updateManager.Add(unitView);
        }

        Vector3 GetLineFormation(int x, List<UnitConfigSO> configs) => new Vector3(x, configs.Count / 2f);
    }
}
