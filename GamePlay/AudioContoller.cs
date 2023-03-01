
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioContoller : MonoBehaviour
{
    [SerializeField] private AudioSource player;
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip bgMusic;
    [SerializeField] private AudioClip buttonSound;

    [SerializeField] private Bank bank;

    [SerializeField] private List<Button> soundableButtons;

    private const string MUSIC_VOLUME = "musicVolume";
    private const string GAME_VOLUME = "gameVolume";


    private void Awake()
    {
        bank.OnCoinsValueChaged += () => player.PlayOneShot(coin);

        foreach (var button in soundableButtons)
        {
            button.onClick.AddListener(() => player.PlayOneShot(buttonSound));
        }
    }

    private void Start()
    {
        player.clip = bgMusic;
        player.volume = GetMusicVolume;
        player.Play();
    }

    public float GetMusicVolume => PlayerPrefs.GetFloat(MUSIC_VOLUME);
    public float GetGameVolume => PlayerPrefs.GetFloat(GAME_VOLUME);

    public void SaveGameVolume(float volume) => PlayerPrefs.SetFloat(GAME_VOLUME, volume);
    public void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME, volume);
        player.volume = volume;
    }
}