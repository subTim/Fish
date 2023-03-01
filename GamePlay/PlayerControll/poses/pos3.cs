using UnityEngine;


    public class pos3 : StateBase

    {
    private Vector3 pos = new Vector3(0, maxHeight, minWight);
    

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
