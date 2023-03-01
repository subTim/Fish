using System.Collections.Generic;
using UnityEngine;


    public class NewRoadGenerator : EnvirounmentGemerator
    {
        [SerializeField] private List<GameObject> prefabs;
        [SerializeField] private int count;

        
        public override void CreateObjecs(float distanceX)
        {
            SpawnTo = distanceX;
            Pull = new Pull(transform,false, prefabs,count);
            Pull.CreatePool();

            SpawnItems();
        }
        
        protected override void SpawnItems()
        {
            while (GetLast() == null || GetLast().transform.position.x < SpawnTo)
            {
                var next = Pull.GetElement();
                SetPosition(next, true);
                ActiveElements.Add(next);
            }
        }
        
        protected override void SetPosition(GameObject element, bool addOffSet)
        {
            Vector3 targetPos = new Vector3(GetXPos(addOffSet), startPosition.position.y, 0);
            
            element.transform.position= targetPos;
        }
    }
