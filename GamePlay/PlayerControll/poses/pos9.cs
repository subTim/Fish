using UnityEngine;


    public class pos9 : StateBase
    {
        private Vector3 pos = new Vector3(0, minHeight, -4);
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
