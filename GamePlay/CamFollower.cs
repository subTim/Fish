using System.Collections;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    [SerializeField] private GameObject targetTr;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject startData;
    [SerializeField] private float smoothing = 1f;
    [SerializeField] private float startSpeedRotation;

    private bool _enableToMove;
    private Vector3 _offset;

    private void Awake()
    {
        SetDefaultPos();
        CalculateOffset();
    }

    public void SetDefaultPos()
    {
        _enableToMove = false;
        Transform transform1 = transform;
        transform1.position = startData.transform.position;
        transform1.rotation = startData.transform.rotation;
    }

    private void CalculateOffset()
    {
        Vector3 cameraPosition = targetTr.transform.position;
        Vector3 playerPosition = player.position;

        _offset = new Vector3(cameraPosition.x - playerPosition.x, cameraPosition.y - playerPosition.y,
            cameraPosition.z - playerPosition.z);
    }

    private void Update()
    {
        Move();
    }

    public void DoCameraStartMove()
    {
        StartCoroutine(StartMove());
    }


    private IEnumerator StartMove()
    {
        float t = 0f;
        while (t < 1)
        {
            Transform transform1 = transform;
            transform1.rotation = Quaternion.Lerp(startData.transform.rotation, targetTr.transform.rotation, t * t);
            transform1.position = Vector3.Lerp(startData.transform.position, targetTr.transform.position, t * t);
            t += Time.deltaTime / startSpeedRotation;

            yield return null;
        }

        _enableToMove = true;
        StopAllCoroutines();
    }


    private void Move()
    {
        if (_enableToMove)
        {
            Vector3 direction = transform.position;
            direction = Vector3.Lerp(direction, player.transform.position + _offset, Time.deltaTime * smoothing);
            transform.position = direction;
        }
    }
}
