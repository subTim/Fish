using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContainerAnimation : UiActivityAnimated
{
    [SerializeField] private List<Button> buttons;
    
    public override async void Enable()
    {
        if (myAnimations[0].IsAnimating == false)
        {
            base.Enable();
            SetInInteractable();
            Task timeToWait = Task.Delay(myAnimations[0].Duration);
            await timeToWait;
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
    
    public void DisableAndAnimate()
    {
        if (myAnimations[0].IsAnimating == false)
        {
            base.Disable();
            SetInInteractable();
        }
    }
}