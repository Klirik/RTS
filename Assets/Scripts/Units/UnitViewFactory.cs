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

        public UnitViewFactory(DiContainer container, UnitView prefab, UpdateManager updateManager)
        {
            this.container = container;
            this.prefab = prefab;
            this.updateManager = updateManager;
        }

        public UnitView Create(Unit model, Vector3 position, string name)
        {
            UnitView unitView = container.InstantiatePrefabForComponent<UnitView>(prefab);  
            
            unitView.name = name;
            unitView.transform.position = position;
            unitView.Set(model);
            updateManager.Add(unitView);
            
            return unitView;
        }
    }
}