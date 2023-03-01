using UnityEngine;


    public class pos5 : StateBase
    {
        private Vector3 pos = new Vector3(0, middleHeight, 0);
        public override void Enter()
        {
        
          
        }
        public override Vector3 GetCords()
        {
            return pos;
        }

        public override void Exit()
        {
         
        }

        public override void Update()
        {
        }
    }
