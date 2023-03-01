using UnityEngine;


public abstract class  StateBase
{
    static public  float maxHeight =9f ;
    static public float minHeight = 1f;
    static public float maxWight = 4f;
    static public float minWight  = -4f;
    static public float middleHeight  = 5f;
    public abstract void Enter();
    public abstract  void Exit();
    public abstract Vector3 GetCords();
    public abstract  void Update();
}    
