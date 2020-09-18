using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlay : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Animator AnimatorText;
    [SerializeField] Animator AnimatorButton;
    [SerializeField] private Button button;
    [Header("music")]
    [SerializeField] private AudioSource buttonSound;

    public void Play()
    {
        buttonSound.Play();
        player.going = true;
        AnimatorButton.SetTrigger("out");
        AnimatorText.SetTrigger("out");
        button.gameObject.SetActive(false);

    }
}
