using System.Collections.Generic;

using UnityEngine;


public class StateMachimeController
{
    public StateBase CurrentState { get; set; }
    private Vector3 _currentPos;

    public int CurrentIndex { get; set; }


    private List<StateBase> _posMas = new List<StateBase>()
        { new pos1(), new pos2(), new pos3(), new pos4(), new pos5(), new pos6(), new pos7(), new pos8(), new pos9() };

    public StateBase this[int index]
    {
        get
        {
            if (index > 9)
                index = 9;
            if (index < 0)
                index = 0;

            CurrentIndex = index;
            return _posMas[index - 1];
        }
    }

    public int this[StateBase state]
    {
        get
        {
            int v = _posMas.IndexOf(state) + 1;
            return v;
        }
    }


    public void ChangeState(StateBase newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentIndex = this[CurrentState];
        CurrentState.Enter();
    }

    public void Initializate(StateBase newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }
}
