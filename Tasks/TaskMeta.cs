using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu]
    public class TaskMeta : ScriptableObject
    {
        public bool isLong;
        public int coinReward;
        public Rewards rewards;
        public string nameTask;
        
        public List<ConditionMeta> myConditions;
        public bool isComplited ;
        public bool isActive ;

        public void ResetAll()
        {
            isActive = false;
            isComplited = false;
            myConditions.ForEach(conddition => conddition.ResetData());
        }
    }
