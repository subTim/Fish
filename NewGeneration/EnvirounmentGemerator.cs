using System.Collections.Generic;
using UnityEngine;


    public abstract class EnvirounmentGemerator : MonoBehaviour
    {
        [SerializeField] protected Transform parent;
        [SerializeField] protected float xOffset;
        [SerializeField] protected Transform startPosition;


        protected Pull Pull;
        protected List<GameObject> ActiveElements = new();
        protected float SpawnTo;

        public Transform Parent => parent;
        public abstract void CreateObjecs(float distanceX);

        protected abstract void SetPosition(GameObject next, bool addOffSet);

        protected float GetXPos(bool add)
        {
            float transformPosition = 0;
            transformPosition =  GetLast() == null?  startPosition.position.x: GetLast().transform.position.x;
            
            if (add)
                transformPosition += xOffset;
            
            return transformPosition;
        }

        protected abstract void SpawnItems();
        
        public virtual void Translate(float xCord)
        {
            while (GetFirst().transform.position.x < xCord)
            {
                RemoveOne();
            }

            SpawnItems();
        }


        
        
        protected GameObject GetLast()
        {
            if (ActiveElements.Count == 0)
                return null;
            
            return ActiveElements[ActiveElements.Count - 1] ;
        }

        protected GameObject GetFirst() => ActiveElements[0];
        
        protected void RemoveOne()
        {
            Pull.ReturnToPoll(GetFirst());
            ActiveElements.Remove(GetFirst());
        }
        
        public void RemoveAll()
        {
            if(Pull != null)
               Pull.Reset();
            
            var count = ActiveElements.Count;
            for (int i = 0; i < count; i++)
            {
                RemoveOne();
            }
        }

    }
