using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    public AudioSource music;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        music.Play();
        StartCoroutine(musicLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator musicLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(35);
            music.Play();
        }
    }
}
