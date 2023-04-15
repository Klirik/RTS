using RTS.UI;
using UnityEngine;
using Zenject;

namespace RTS.Units
{
    public class UnitViewFactory : IFactory<Unit, Vector3, string, UnitView>
    {
        readonly DiContainer container;
        readonly UnitView prefab;
        readonly UpdateManager updateManager;
        readonly FactionStateCollection factionStateCollection;

        public UnitViewFactory(DiContainer container, UnitView prefab, UpdateManager updateManager
            , FactionStateCollection factionStateCollection)
        {
            this.container = container;
            this.prefab = prefab;
            this.updateManager = updateManager;
            this.factionStateCollection = factionStateCollection;
        }

        public UnitView Create(Unit model, Vector3 position, string name)
        {
            UnitView unitView = container.InstantiatePrefabForComponent<UnitView>(prefab);  
            var factionState = factionStateCollection.Collection[model.Faction];

            unitView.name = name;
            unitView.transform.position = position;
            unitView.SetDependencies(factionState);
            unitView.Set(model);
            updateManager.Add(unitView);
            
            return unitView;
        }
    }
}