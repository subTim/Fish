using System;
using System.Collections.Generic;
using UnityEngine.Scripting;


public class ShortTasks : TaskBase
{
    public ShortTasks(GameStats provider, Rewarder rewarder, List<TaskMap> tasks) : base(tasks,rewarder)
    {
        DataComparer = new Dictionary<ConditionType, Func<float>>()
        {
            { ConditionType.Coins, () => provider.GetMoneyController.GetNowDone() },
            { ConditionType.Distance, () => provider.GetDistanceController.GetNowDone() },
            { ConditionType.SwipeLeft, () => provider.GetSwipesController.GetLeft },
            { ConditionType.SwipeRight, () => provider.GetSwipesController.GetRight },
            { ConditionType.SwipeDown, () => provider.GetSwipesController.GetDown },
            { ConditionType.SwipeUp, () => provider.GetSwipesController.GetUp }
        };
    }

    protected override void FilterTasks()
    {
        MyTasks = MyTasks.FindAll(task => task.IsLong == false);
    }
}

