using System;
using System.Collections.Generic;


public class TasksLong : TaskBase
{
    public TasksLong(GameStats provider, Rewarder rewarder, List<TaskMap> tasks) : base(tasks,rewarder)
    {
        DataComparer = new Dictionary<ConditionType, Func<float>>()
        {
            { ConditionType.Coins, () => provider.GetMoneyController.GetTodayDone() },
            { ConditionType.Distance, () => provider.GetDistanceController.GetTodayDone() },
            { ConditionType.SwipeLeft, () => provider.GetSwipesController.GetLeftToday() },
            { ConditionType.SwipeRight, () => provider.GetSwipesController.GetRightToday() },
            { ConditionType.SwipeDown, () => provider.GetSwipesController.GetDownToday() },
            { ConditionType.SwipeUp, () => provider.GetSwipesController.GetUpToday() }
        };
    }

    protected override void FilterTasks()
    {
        MyTasks = MyTasks.FindAll(task => task.IsLong);
    }

  
}