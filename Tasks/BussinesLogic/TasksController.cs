using System;
using System.Globalization;
using UnityEngine;

public class TasksController : MonoBehaviour, ITimeDependenced
{
    [SerializeField] private Game game;
    [SerializeField] private TasksContainer tasksContainer;

    private ShortTasks _shortTasks;
    private TasksLong _longTask;

    public Action IsSomeCommited;

    public void SetActive() => gameObject.SetActive(true);
    public void SetInActive() => gameObject.SetActive(false);

    public void Init(Rewarder rewarder)
    {
        tasksContainer.GetActiveTasks();

        _longTask = new TasksLong(game.Stats,rewarder, tasksContainer.GetTasks);
        _shortTasks = new ShortTasks(game.Stats,rewarder, tasksContainer.GetTasks);

        SetInActive();
    }

    private void OnEnable()
    {
        if (_longTask != null && _shortTasks != null)
        {
            ShowTasks();
        }
    }

    private void ShowTasks()
    {
        _longTask.View();
        _shortTasks.View();
    }

    public void ResetData()
    {
        tasksContainer.ResetTasks();
        tasksContainer.CreateTasks();
    }
}