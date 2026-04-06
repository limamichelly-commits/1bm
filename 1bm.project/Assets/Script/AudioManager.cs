using System.Collections.Generic;using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Private Fields
       
       private List<AudioSource> systemSourceChannels;
       private List<AudioSource> ActiveSources;
       
       #endregion
       
    #region Singleton 
    public static AudioManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            systemSourceChannels = new List<AudioSource>();
            ActiveSources = new List<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    
    #region Play 2D Sonds

    public void playMusic(AudioClip clip)
    {
        if (systemSourceChannels.Count == 0)
        {
            systemSourceChannels.Add(gameObject.AddComponent<AudioSource>());
        }
        systemSourceChannels[0].Stop();
        systemSourceChannels[0].clip = clip;
        systemSourceChannels[0].Play();
    }

    public void StopMusic()
    {
        if (systemSourceChannels.Count > 0)
        {
            systemSourceChannels[0].Stop();
        }
            
    }

    public void pauseMusic()
    {
        if (systemSourceChannels.Count > 0)
        {
            systemSourceChannels[0].UnPause();
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (systemSourceChannels.Count == 0)
        {
            systemSourceChannels.Add(gameObject.AddComponent<AudioSource>());
        }
        systemSourceChannels[0].PlayOneShot(clip);
    }
    #endregion
}
   