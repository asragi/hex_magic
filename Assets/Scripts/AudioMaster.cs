using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    [SerializeField]
    AudioSource[] sources;
    [SerializeField]
    AudioSource vanish;
    [SerializeField]
    AudioSource clear;
    [SerializeField]
    AudioSource place;

    public void PlayVanish() => vanish.Play();
    public void PlayClear() => clear.Play();
    public void PlayPlace() => place.Play();

    public void PlayChainSE(int chainNum)
    {
        int target = Mathf.Min(sources.Length - 1, chainNum - 1);
        sources[target].Play();
    }
}
