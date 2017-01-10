using UnityEngine;
using System.Collections;

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
    void Awake()
    {
        DontDestroyOnLoad(SoundManager.Instance);
    }

    void Start ()
    {
        BGMSource = gameObject.AddComponent<AudioSource>();
        BGMSource.loop = false;
        PlayBGM("Aublia");
	}

    void Update ()
    {
        for (int i = 0; i < BGMs.Length; i++)
        {
            if (BGMs[i].FadeFlag == true && BGMs[i].m_FadeTime >= 0.0f)
            {
                BGMs[i].m_Volume -= volume.BGMVolume / BGMs[i].m_FadeTime / 60.0f;
                BGMSource.volume = BGMs[i].m_Volume;
                Debug.Log(BGMSource.volume);

                if (BGMs[i].m_Volume <= 0)
                {
                    BGMSource.Stop();
                }
            }
        }
    }
    public void OnBGMVolumeChanged()
    {
        if (BGMSource.volume != volume.BGMVolume) BGMSource.volume = volume.BGMVolume;
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

    // Fade再生する
    public void FadeBGM(string name)
    {
        int i = 0;
        for (i = 0; i < BGMs.Length; i++)
        {
            if (BGMs[i].Name.Equals(name))
            {
                break;
            }
        }
        StartCoroutine("Fade",BGMs[i]);
    }

    IEnumerator Fade(SoundSource bgm)
    {
        while (BGMSource.volume > 0)
        {
           BGMSource.volume -= volume.BGMVolume / bgm.m_FadeTime / 60.0f;
            yield return new WaitForEndOfFrame();
        }
        BGMSource.Stop();
        BGMSource.volume = 0.0f;
        BGMSource.clip = bgm.clip;
        BGMSource.Play();
        while (BGMSource.volume < volume.BGMVolume)
        {
            BGMSource.volume += volume.BGMVolume / bgm.m_FadeTime / 60.0f;
            yield return new WaitForEndOfFrame();
        }
        BGMSource.volume = volume.BGMVolume;
        yield return 0;
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
