using UnityEngine;


    public class pos10Death : StateBase
    {
        private Vector3 pos;

        public Vector3 Pos
        {
            set => pos = value;
        }
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override Vector3 GetCords()
        {
            return pos;
        }

        public override void Update()
        {
  
        }
    }
