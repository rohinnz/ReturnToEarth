using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        if (!AudioBegin)
        {
            //audioSource.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
}
