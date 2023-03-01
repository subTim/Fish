using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class TasksContainer : MonoBehaviour
{
    [SerializeField] private List<TaskMeta> meteFiles;
    [SerializeField] private TaskMap taskMap;
    [SerializeField] private int tasksCount;
    public List<TaskMap> GetTasks => _tasks;
    private List<TaskMap> _tasks = new List<TaskMap>(10);

    public void CreateTasks()
    {
        List<int> activeindexes = new List<int>(tasksCount);
        var haveToGenerate = tasksCount - _tasks.Count;

        if (haveToGenerate <= 0)
            return;

        PlayerPrefs.SetString("TasksBornTime", DateTime.Now.ToString(CultureInfo.InvariantCulture));

        while (haveToGenerate > 0)
        {
            int metaIndx;

            do
            {
                metaIndx = GetRandomIndex();
            } while (activeindexes.Contains(metaIndx));

            var cell = Instantiate(taskMap, transform);

            activeindexes.Add(metaIndx);

            var taskMeta = meteFiles[metaIndx];
            taskMeta.isActive = true;

            cell.SetData(taskMeta);
            _tasks.Add(cell);
            haveToGenerate--;
        }
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, meteFiles.Count);
    }

    public void ResetTasks()
    {
        foreach (var meta in meteFiles)
        {
            meta.ResetAll();
        }

        var countTill = transform.childCount;

        for (int i = 0; i < countTill; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        _tasks.Clear();
    }



    public void GetActiveTasks()
    {
        void InstantiateCells(TaskMeta meta)
        {
            var cell = Instantiate(taskMap, transform);
            cell.SetData(meta);
            _tasks.Add(cell);
        }

        foreach (var meta in meteFiles.Where((meteFilescell) => meteFilescell.isActive && !meteFilescell.isComplited))
            InstantiateCells(meta);

        foreach (var meta in meteFiles.Where((meteFilescell) => meteFilescell.isActive && meteFilescell.isComplited))
            InstantiateCells(meta);


        if (_tasks.Count < tasksCount)
            CreateTasks();
    }
}