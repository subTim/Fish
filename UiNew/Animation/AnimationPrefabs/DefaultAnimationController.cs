using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class DefaultAnimationController : MonoBehaviour
{
    [SerializeField] private List<UIAniimationBehaviour> myAnimations;
    [SerializeField] private List<Button> buttons;

    private void Awake()
    {
        myAnimations.ForEach(behaviour => behaviour.InitAnimation());
    }

    public async void EnableAndAnimate()
    {
        if (myAnimations[0].IsAnimating == false)
        {
            gameObject.SetActive(true);
           myAnimations.ForEach(behaviour => behaviour.Animate());
           await GetDuration();
           SetInteracteble();
        }
    }
    
    private void SetInteracteble()
    {
        buttons.ForEach(button => button.interactable = true);
    }
    private void SetInInteractable()
    {
        buttons.ForEach(button => button.interactable = false);
    }
    

    public virtual async void DisableAndAnimate()
    {
        if (myAnimations[0].IsAnimating == false)
        {
            SetInInteractable();
            myAnimations.ForEach(behaviour => behaviour.AnimateReverse());
            await GetDuration();
            gameObject.SetActive(false);
        }
    }

    protected Task GetDuration()
    {
        Task timeToWait = Task.Delay(myAnimations[0].Duration);
        return timeToWait;
    }
}