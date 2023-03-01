using DG.Tweening;
using UnityEngine;


    public class CoinsAnimation : MonoBehaviour
    {
        [SerializeField]  private Vector3 targetPosition;
        [SerializeField] private float animationDuration; 
        private void Start()
        {
            DOTween.Sequence()
                .SetEase(Ease.Linear)
                .Append(transform.DOMove(new Vector3(transform.position.x, targetPosition.y, transform.position.z), animationDuration))
                .AppendCallback(ResetTargetPos)
                // .Append(transform.DORotate(new Vector3(0f, 360f, 0f), animationDuration, RotateMode.Fast))
                .SetLink(gameObject.transform.parent.gameObject)
                .SetLoops(-1);
        }

        private void ResetTargetPos()
        {
            targetPosition = -1 * targetPosition;
        }
    }
