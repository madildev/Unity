using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    private void Awake() 
    {
      DontDestroyOnLoad(gameObject);
      foreach(var sound in sounds)
      {
         sound.source = gameObject.AddComponent<AudioSource>();
         sound.source.clip = sound.clip;
         sound.source.volume = sound.volume;
         sound.source.pitch = sound.pitch;
         sound.source.name = sound.name;
      }   
    }

    public void PlaySound(string name)
    {
         foreach (var sound in sounds)
         {
             if(sound.name == name)
             {
                sound.source.Play();
             }
         }
    }
}
