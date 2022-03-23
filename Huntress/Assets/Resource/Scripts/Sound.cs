using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] GameObject shooting, enemy1, enemy2, player,beast,reaperBot,ghost;
    ghostAI ghostAI;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        if (shooting &&enemy1&& enemy2 && player && beast && reaperBot  && ghost != null)
        {
            shooting.GetComponent<shooting>().action += Onplay;
            enemy1.GetComponent<enemyController>().action += Onplay;
            enemy2.GetComponent<enemyController>().action += Onplay;
            player.GetComponent<playerHealth>().action += Onplay;
            beast.GetComponent<beastAI>().action += Onplay;
            reaperBot.GetComponent<reaoerBot>().action += Onplay;
            ghost.GetComponent<ghostAI>().action += Onplay;
        }

    }
    private void OnDisable()
    {
        if (shooting && enemy1 && enemy2 && player && beast && reaperBot != null)
        {
            shooting.GetComponent<shooting>().action -= Onplay;
            enemy1.GetComponent<enemyController>().action -= Onplay;
            enemy2.GetComponent<enemyController>().action += Onplay;
            player.GetComponent<playerHealth>().action -= Onplay;
            beast.GetComponent<beastAI>().action -= Onplay;
            reaperBot.GetComponent<reaoerBot>().action -= Onplay;
            ghost.GetComponent<ghostAI>().action += Onplay;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Onplay(int element)
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSource.PlayOneShot(audioClips[element]);
        }
    }
}
