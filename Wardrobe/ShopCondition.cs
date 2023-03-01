 using TMPro;
 using UnityEngine;

 public class ShopCondition : MonoBehaviour
 {
     [SerializeField] private TextMeshProUGUI condition;

     public void SetActive() => gameObject.SetActive(true);
     public void SetInActive() => gameObject.SetActive(false);

     public void Render(string cap)
     {
         condition.text = cap;
     }
 }