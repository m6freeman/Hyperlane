using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    public AudioClip intro;
    public AudioClip loop;
    public AudioClip[] notes = new AudioClip[12];
    public int comboNotesPosition = 0;

    private AudioSource source;

    void Awake()  // Create Singleton GameObject
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();

        GetComponent<AudioSource>().loop = true;
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        source.clip = intro;
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.clip = loop;
        source.Play();
    }


   
}
