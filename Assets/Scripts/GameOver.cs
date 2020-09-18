using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Animator text;
    [SerializeField] private Animator button;
    [SerializeField] private UnityAdsHelper adsHelper;
    [SerializeField] private Button MusicOn;
    [SerializeField] private Button MusicOf;
    [SerializeField] private AudioMixer Mixer;
    // [SerializeField] private GameCore GameCore;

    private bool soundOn;

    [Header("music")]
    [SerializeField] private AudioSource buttonSound;
    public void gameOver()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        soundOn = intToBool(PlayerPrefs.GetInt("val"));
        Debug.Log(soundOn + "Music");
        if (soundOn)
        {
            Mixer.SetFloat("Master", 0);
            MusicOf.gameObject.SetActive(false);
            MusicOn.gameObject.SetActive(true);
        }
        else
        {
            Mixer.SetFloat("Master", -80);
            MusicOn.gameObject.SetActive(false);
            MusicOf.gameObject.SetActive(true);
        }
    }
    public void Reset()
    {
        if (Random.Range(0, 2) == 1)
        {
            adsHelper.showVideoAd();
        }
        buttonSound.Play();
        DOTween.PauseAll();
        SceneManager.LoadScene("Main");
    }
    public void clikPlayMusic()
    {
        if (soundOn)
        {
            soundOn = false;
            PlayerPrefs.SetInt("val", 0);
            Mixer.SetFloat("Master", -80);
            MusicOn.gameObject.SetActive(false);
            MusicOf.gameObject.SetActive(true);
        }
        else
        {
            soundOn = true;
            PlayerPrefs.SetInt("val", 1);
            Mixer.SetFloat("Master", 0);
            MusicOf.gameObject.SetActive(false);
            MusicOn.gameObject.SetActive(true);
        }
    }
    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
