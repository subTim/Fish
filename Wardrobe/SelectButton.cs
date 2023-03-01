 using System;
 using UnityEngine;
 using UnityEngine.UI;

 public class SelectButton : MonoBehaviour
 {
     [SerializeField] private Button myButton;
     [SerializeField] private Sprite slectSprite;
     [SerializeField] private Sprite emptySprite;
     [SerializeField] private ShopCondition conditionPrefab;

     private ShopCondition _condition;

     private void Awake()
     {
         _condition = Instantiate(conditionPrefab, transform);
         _condition.SetInActive();
     }

     public void RenderSelect()
     {
         myButton.interactable = true;
         _condition.SetInActive();
         myButton.image.sprite = slectSprite;
     }

     public void RenderCondition(int value, bool isActive)
     {
         myButton.image.sprite = emptySprite;
         myButton.interactable = isActive;
         _condition.SetActive();
         _condition.Render(value.ToString());
     }

     public void Subscribe(Action command)
     {
         myButton.onClick.RemoveAllListeners();
         myButton.onClick.AddListener(() => command());
     }
 }