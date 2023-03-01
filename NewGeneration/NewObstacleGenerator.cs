using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class NewObstacleGenerator : EnvirounmentGemerator
{
    [SerializeField, Range(0, 100)] private int percentOfGeneration;
    [SerializeField, Range(30, 200)] private int count;

    [SerializeField] private List<GameObject> enableObstaclesUp = new();
    [SerializeField] private List<GameObject> enableObstaclesDown = new();

    private List<StateBase> _poses = new() { new pos1(), new pos2(), new pos3(), new pos7(), new pos8(), new pos9()};
    private const int POS_INDEX_DOWNLINE = 3;

    private Predicate<GameObject> IsSuitableUp => obstacle => enableObstaclesUp.Contains(obstacle);
    private Predicate<GameObject> IsSuitableDown => obstacle => enableObstaclesDown.Contains(obstacle);

    public override void CreateObjecs(float distanceX)
    {
        List<GameObject> prefabs = new List<GameObject>();

        prefabs.AddRange(enableObstaclesDown);
        prefabs.AddRange(enableObstaclesUp);

        Pull = new Pull(transform, true, prefabs, count);
        Pull.CreatePool();

        SpawnTo = distanceX;
        SpawnItems();
    }

    protected override void SpawnItems()
    {
        while (GetLast() == null || GetLast().transform.position.x < SpawnTo) 
            AddLine();
    }

    private void AddLine()
    {
        bool add = true;
        for (int i = 0; i < _poses.Count; i++)
        {
            if (percentOfGeneration > GetChance() == false)
                continue;

            Predicate<GameObject> condition = GetCondition(i);
            
            var next = Pull.GetElementWithPredicate(condition);
            next.transform.position = GetPositionToSpawn(i);

            SetPosition(next, add);
            ActiveElements.Add(next);

            add = false;
        }
    }

    protected override void SetPosition(GameObject next, bool addOffset)
    {
        var transformPosition = next.transform.position;

        transformPosition.x = GetXPos(addOffset);
        next.transform.position = transformPosition;
    }

    private int GetChance() => Random.Range(0, 101);

    private Predicate<GameObject> GetCondition(int i)
    {
        var predicate = i < POS_INDEX_DOWNLINE ? IsSuitableUp : IsSuitableDown;
        return predicate;
    }

    private Vector3 GetPositionToSpawn(int i)
    {
        Vector3 positonInIteration = _poses[i].GetCords();

        return new Vector3(0f, positonInIteration.y, positonInIteration.z);
    }
}
