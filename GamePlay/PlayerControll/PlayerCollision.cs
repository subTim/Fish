
using UnityEngine;


    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Game game;
        [SerializeField] private NewCoinGenerator coinGenerator;
        [SerializeField] private LayerMask obstacleMask;
         private const int COIN_MASK =  6;
         private const int OBSTACLE_MASK =  3;

        private Bank _bank;
        
        
        private void Start()
        {
            _bank = game.BankHSystem;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer.Equals(OBSTACLE_MASK) )
            {
                game.CollidedState();
            }

            if (other.gameObject.layer.Equals(COIN_MASK))
            {
                _bank.AddCoins(1);
                coinGenerator.RemoveCoin(other.transform.parent.gameObject);
            }
        }
    }

