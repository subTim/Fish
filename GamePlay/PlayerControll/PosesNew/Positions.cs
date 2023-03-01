
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu]
public class Positions : ScriptableObject
{
    [SerializeField] private float offset;
    [SerializeField] private float upOffset;

    private List<Vector3> _poses;
    
    private List<int> LEFT_INDEXES = new () { 0, 3, 6 };
    private List<int> RIGHT_INDEXES = new () { 2, 5, 8 };
    private List<int> UP_INDEXES = new () { 0, 1, 2 };
    private List<int> DOWN_INDEXES = new () { 6, 7, 8 };

    public int LeftIntOffest => -1;
    public int RightIntOffset => 1;
    public int UpIntOffset => -3;
    public int DownIntOffest => 3;
    public List<Vector3> GetAllPoses => _poses;

    public void Create()
    {
        _poses = new List<Vector3>(10)
        {
            new (0, offset + upOffset,offset),
            new (0, offset + upOffset,0),
            new (0, offset + upOffset,-offset),
            new (0, upOffset, offset),
            new (0, upOffset,0),
            new (0, upOffset,-offset),
            new (0, -offset + upOffset, offset),
            new (0, -offset + upOffset, 0),
            new (0, -offset + upOffset, -offset),
        };
    }
    
    public Vector3 this[int index] => _poses[index];

    public int this[Vector3 pos]
    {
        get
        {
            if (_poses.Contains(pos))
            {
                return _poses.IndexOf(pos);
            }
            throw new InvalidDataException();
        }
    }

    public bool IsLeft(Vector3 position)
    {
        Debug.Log(LEFT_INDEXES.Contains(this[position]));
        return LEFT_INDEXES.Contains(this[position]);
    }
    
    public bool IsRight(Vector3 position)
    {
        return RIGHT_INDEXES.Contains(this[position]);
    }
    
    public bool IsUp(Vector3 position)
    {
        return UP_INDEXES.Contains(this[position]);
    }
    
    public bool IsDown(Vector3 position)
    {
        return DOWN_INDEXES.Contains(this[position]);
    }
}