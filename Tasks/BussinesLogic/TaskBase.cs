using System;
using System.Collections.Generic;


public abstract class TaskBase
{
    protected Rewarder Rewarder;
    protected List<TaskMap> MyTasks = new(10);
    protected Dictionary<ConditionType, Func<float>> DataComparer;

    public TaskBase(List<TaskMap> allTasks, Rewarder rewarder)
    {
        MyTasks = allTasks;
        FilterTasks();
        Rewarder = rewarder;
    }

    protected abstract void FilterTasks();

    private void RewardTask(TaskMap task)
    {
        if (!task.IsComplited && task.CheackComplition(DataComparer))
            Rewarder.RewardValue(task.GetRewardType(), task.GetMoney);
    }

    public void View()
    {
        foreach (var task in MyTasks)
        {
            RewardTask(task);
            task.Render();
        }
    }
}
