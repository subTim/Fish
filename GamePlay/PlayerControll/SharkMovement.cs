using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class SharkMovement : MonoBehaviour
{
    [SerializeField] private float annimationDuration;
    [SerializeField, Range(1f, 15f)] private float fishSpeed;
    private float _currentSpeed;
    private int[] _offsetVariants = { -1, 1 };
    private int _layerMask = 1 << 3;
    private StateMachimeController _stateMachine;
    private Coroutine _turnCoroutine;
    private bool _enableToCheck;


    private void Awake()
    {
        GameManager.Collided.AddListener(() => _currentSpeed = 0f);
        GameManager.IsPlaying.AddListener(() => _currentSpeed = fishSpeed);
        _stateMachine = new StateMachimeController();
        _stateMachine.Initializate(_stateMachine[5]);
    }

    private void OnEnable()
    {
        _enableToCheck = true;
        transform.position = _stateMachine.CurrentState.GetCords() + new Vector3(50f, 0, 0);
        StartCoroutine(CheckDemandToGo());
    }

    private int CheckState()
    {
        int offset = 0;
        Debug.Log(_stateMachine[_stateMachine.CurrentState]);

        switch (_stateMachine[_stateMachine.CurrentState])
        {
            case 5:
                offset = _offsetVariants[Random.Range(0, 2)];
                break;
            case 4:
                offset = _offsetVariants[1];
                break;
            case 6:
                offset = _offsetVariants[0];
                break;
            default:
                Debug.Log(_stateMachine.CurrentState);
                break;
        }

        return offset;
    }


    private bool CheckWhereToMove(int offset)
    {
        var position = transform.position;
        var trigger = new Vector3(position.x, position.y,
            _stateMachine[_stateMachine.CurrentIndex + offset].GetCords().z);
        if (!Physics.Raycast(trigger, Vector3.forward, 10f, _layerMask))
        {
            _stateMachine.ChangeState(_stateMachine[_stateMachine[_stateMachine.CurrentState] + offset]);
            _turnCoroutine = StartCoroutine(TurnShark(transform.position, trigger));
            return true;
        }

        return false;
    }

    private void Update()
    {
        transform.position -= new Vector3((GameManager.Singleton.speed + _currentSpeed) * Time.deltaTime, 0, 0);
    }

    private IEnumerator CheckDemandToGo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (_enableToCheck && Physics.Raycast(transform.position, Vector3.left, 10f, _layerMask))
            {
                var offset = CheckState();
                if (!CheckWhereToMove(offset))
                    CheckWhereToMove(-offset);
            }

            yield return null;
        }
    }

    private IEnumerator TurnShark(Vector3 start, Vector3 target)
    {
        var t = 0f;
        _enableToCheck = false;
        while (t < 1)
        {
            var transformPosition = transform.position;
            transformPosition.z = Vector3.Lerp(start, target, t * t).z;
            transform.position = transformPosition;
            t += Time.deltaTime / annimationDuration;
            yield return null;
        }

        _enableToCheck = true;

        StopCoroutine(_turnCoroutine);
    }
}