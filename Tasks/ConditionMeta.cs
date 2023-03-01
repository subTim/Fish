using UnityEngine;


    public enum ConditionType
    {
        Coins, 
        Distance,
        
        SwipeLeft,
        SwipeRight, 
        SwipeUp,
        SwipeDown
    }
    [CreateAssetMenu]
    public class ConditionMeta : ScriptableObject
    {
      [SerializeField] private float myValue;
      [SerializeField] private ConditionType myType;
      
      public float MyValue => myValue;
      public ConditionType MyType => myType;
      public float CurrentValue => _currentValue;
      public bool IsComplited { get; private set; }

      private float _currentValue;

      public void ResetData()
      {
          IsComplited = false;
          _currentValue = 0;
      }
      
      public void CheckComplition(float valueToCompare)
      {
          if (myValue <= valueToCompare)
              IsComplited = true;

          else
          {
              IsComplited = false;
              _currentValue = valueToCompare;
          }
      }
    }
