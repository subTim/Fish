using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class TaskMap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskCaption;
    [SerializeField] private TextMeshProUGUI reward;
    [SerializeField] private ConditionMap conditionMap;
    [SerializeField] private Transform container;

    public bool IsComplited => _meta.isComplited;
    public bool IsLong => _meta.isLong;
    public int GetMoney => _meta.coinReward;
    public Rewards GetRewardType() => _meta.rewards;

    private Queue<ConditionMap> _conditions = new(4);
    private TaskMeta _meta;

    public void SetData(TaskMeta meta)
    {
        _meta = meta;

        taskCaption.text = _meta.nameTask;
        reward.text = _meta.coinReward.ToString();

        CreateConditions();
    }

    private void CreateConditions()
    {
        foreach (var conditionMeta in _meta.myConditions)
        {
            var next = Instantiate(conditionMap, container);
            next.SetBaseData(conditionMeta);

            _conditions.Enqueue(next);
        }
    }

    public void Render()
    {
        foreach (var condition in _conditions)
            condition.Animate();
    }

    public bool CheackComplition(Dictionary<ConditionType, Func<float>> dataComparer)
    {
        if (_meta.isComplited)
            return false;

        foreach (var conditionMeta in _meta.myConditions)
            conditionMeta.CheckComplition(dataComparer[conditionMeta.MyType].Invoke());

        foreach (var condition in _conditions)
            condition.CheckComplition();

        if (_conditions.Count == _conditions.Where(condition => condition.IsComplited).Count())
        {
            SetComplited();
            return true;
        }

        return false;
    }

    private void SetComplited()
    {
        _meta.isComplited = true;
    }

    public void RemoveConditions()
    {
        for (int i = 0; i < _conditions.Count; i++)
            Destroy(_conditions.Dequeue().gameObject);

        _conditions.Clear();
    }
}