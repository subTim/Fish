using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu]
    public class SpriteStok : ScriptableObject
    {
        [SerializeField] private Sprite coinSprite;
        [SerializeField] private Sprite distanceSprite;
        [SerializeField] private Sprite turnLeft;
        [SerializeField] private Sprite turnRight;
        [SerializeField] private Sprite turnUp;
        [SerializeField] private Sprite turnDown;

        [SerializeField] private Sprite completSprite;
        
        public Dictionary<ConditionType, Sprite> Sprites = new Dictionary<ConditionType, Sprite>();

        public void Init()
        {
            Sprites = new Dictionary<ConditionType, Sprite>()
            {
                { ConditionType.Coins, coinSprite },
                { ConditionType.Distance, distanceSprite },
                { ConditionType.SwipeLeft , turnLeft},
                { ConditionType.SwipeRight , turnRight},
                { ConditionType.SwipeUp , turnUp},
                { ConditionType.SwipeDown , turnDown},

            };
        }
    }
    
