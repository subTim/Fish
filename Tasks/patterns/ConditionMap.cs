using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConditionMap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI max;
    [SerializeField] private TextMeshProUGUI now;
    [SerializeField] private TextMeshProUGUI slash;

    [SerializeField] private Slider mySlider;
    [SerializeField] private float animationDuration;

    [SerializeField] private Image fillArea;
    [SerializeField] private Sprite compliteSpriteArea;

    public ConditionType Type => _data.MyType;
    public bool IsComplited => _data.IsComplited;

    private SliderAnimation _sliderAnimation;
    private ConditionMeta _data;



    public void SetBaseData(ConditionMeta data)
    {
        _data = data;
        max.text = data.MyValue.ToString();
        now.text = data.CurrentValue.ToString();
    }

    public void CheckComplition()
    {
        if (_data.IsComplited)
        {
            mySlider.value = 1f;
            fillArea.sprite = compliteSpriteArea;
            max.gameObject.SetActive(false);
            now.gameObject.SetActive(false);
            slash.gameObject.SetActive(false);
        }
    }

    public void Animate()
    {
        if (_data.IsComplited)
            return;

        now.text = _data.CurrentValue.ToString();
        _sliderAnimation = new SliderAnimation();

        var targetValue = _data.CurrentValue / _data.MyValue;
        _sliderAnimation.Animate(mySlider, targetValue, animationDuration);
    }
}