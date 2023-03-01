using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioContoller audioContoller;
    [SerializeField] private Slider mySlider;

    private void Awake()
    {
        mySlider.onValueChanged.AddListener(value => audioContoller.SaveMusicVolume(value));
    }

    private void OnEnable()
    {
        mySlider.value = audioContoller.GetMusicVolume;
    }
}