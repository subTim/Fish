using Vector3 = UnityEngine.Vector3;


    public class pos1 : StateBase
    {
        private Vector3 pos = new Vector3(0, maxHeight, maxWight);
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
