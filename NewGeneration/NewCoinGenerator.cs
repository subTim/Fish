using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


    public class NewCoinGenerator : EnvirounmentGemerator
    {
        [SerializeField, Range(3f, 50f)] private float linesOffSet;
        [SerializeField, Range(5, 8)] private int lineMaxCapacity;
        [SerializeField] private LayerMask mask;
        [SerializeField] private List<GameObject> prefabs;

        private const float REMOVMENT_TRIGGER_DISTANCE = 1f;

        private List<StateBase> _poses = new()
        {
            new pos1(), new pos2(), new pos3(), new pos4(),
            new pos5(), new pos6(), new pos7(), new pos8(), new pos9()
        };

        private StateBase _currentPose;

        public override void CreateObjecs(float distanceX)
        {
            Pull = new Pull(transform, true, prefabs, 10);
            Pull.CreatePool();

            SpawnTo = distanceX - 10f;
            ChangePos();

            SpawnItems();
        }

        protected override void SpawnItems()
        {
            while (GetLast() == null || GetLast().transform.position.x < SpawnTo)
            {
                bool newLine = true;
                ChangePos();

                for (int i = 0; i < GetLineCapacity(); i++)
                {
                    var next = Pull.GetElement();
                    SetPosition(next, newLine);
                    ActiveElements.Add(next);
                    newLine = false;
                }
            }
        }

        public override void Translate(float xCord)
        {
            base.Translate(xCord);
            ActiveElements.ForEach(coin => TranslateCoins(coin));
        }

        public void RemoveCoin(GameObject triggered)
        {
            var target = ActiveElements.IndexOf(triggered);
            Destroy(ActiveElements[target]);
            ActiveElements.RemoveAt(target);
        }

        protected override void SetPosition(GameObject next, bool addOffSet)
        {
            Vector3 transformPosition = _currentPose.GetCords();
            
            if (addOffSet)
                transformPosition.x = linesOffSet;

            transformPosition.x += GetXPos(true);
            next.transform.position = transformPosition;
        }
        
        private void  TranslateCoins( GameObject coin)
        {
            Vector3 targetPos = coin.transform.position;
            while (CheckIsTriggered(coin))
            {
                targetPos.x += xOffset;
                coin.transform.position = targetPos;
            }
        }

        private bool CheckIsTriggered(GameObject coin) => Physics.CheckSphere(coin.transform.position, REMOVMENT_TRIGGER_DISTANCE, mask);
        private int GetLineCapacity() => Random.Range(lineMaxCapacity, lineMaxCapacity + 1);
        private void ChangePos() => _currentPose = _poses[Random.Range(0, 9)];
    }
