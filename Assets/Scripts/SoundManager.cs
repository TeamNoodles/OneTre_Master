using UnityEngine;
using System;

[System.Serializable]
public class SoundVolume
{
    public float BGMVolume = 1.0f;
    public float SEVolume = 1.0f;
    public bool BGMMute = false;
    public bool SEMute = false;

    private void Init()
    {
        BGMVolume = 1.0f;
        SEVolume = 1.0f;
        BGMMute = false;
        SEMute = false;
    }
}

[System.Serializable]
public class SoundSource
{
    public AudioClip clip;
    public string Name;

    public bool FadeFlag = false;
    public float m_VolumeBefore = 0.0f;
    public float m_VolumeAfter = 0.0f;
    public float m_FadeTime = 0.0f;

    public float m_Volume;
}


public class SoundManager : Singleton<SoundManager>
{

    private AudioSource BGMSource;
    private AudioSource[] SESources;

    public SoundVolume volume = new SoundVolume();

    public SoundSource[] BGMs;
    public SoundSource[] SEs;

    void Start ()
    {
        BGMSource = gameObject.AddComponent<AudioSource>();
        BGMSource.loop = false;
	
	}

    void Update ()
    {
        for (int i = 0; i < BGMs.Length; i++)
        {
            if (BGMs[i].FadeFlag == true && BGMs[i].m_FadeTime >= 0.0f)
            {
                BGMs[i].m_Volume += (BGMs[i].m_VolumeAfter - BGMs[i].m_VolumeBefore) / BGMs[i].m_FadeTime / 60.0f;
                BGMSource.volume = BGMs[i].m_Volume;

                if (BGMs[i].m_Volume >= 0.0f)
                {
                    BGMs[i].m_Volume = 1.0f;
                    BGMs[i].m_FadeTime = 0.0f;
                }
                else if (BGMs[i].m_Volume <= 0.0f)
                {
                    BGMs[i].m_Volume = 0.0f;
                    BGMs[i].m_FadeTime = 0.0f;
                    BGMSource.Stop();
                }
            }
        }
	}

    public void StopBGM(string name)
    {

        foreach (SoundSource ss in BGMs)
        {
            if (ss.Name.Equals(name) == true)
            {
                BGMSource.clip = ss.clip;
                BGMSource.Stop();
            }
        }

    }

    public void FadeOutBGM(string name)
    {

        foreach (SoundSource ss in BGMs)
        {
            if (ss.Name.Equals(name) == true)
            {
                ss.FadeFlag = true;
            }
        }

    }

    public void PlayBGM(string name)
    {

        foreach (SoundSource ss in BGMs)
        {
            if (ss.Name.Equals(name) == true)
            {
                BGMSource.clip = ss.clip;
                BGMSource.volume = volume.BGMVolume;
                BGMSource.Play();

                ss.m_Volume = volume.BGMVolume;
            }
        }

    }

    public void PlaySE(string name)
    {

        foreach (SoundSource ss in SEs)
        {
            if (ss.Name.Equals(name) == true)
            {

                foreach (AudioSource audiosource in SESources)
                {
                    if (audiosource.isPlaying == false)
                    {
                        audiosource.clip = ss.clip;
                        audiosource.volume = volume.SEVolume;
                        audiosource.Play();
                        return;
                    }
                }
            }
        }
    }
}
