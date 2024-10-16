using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System;

public enum AudioType 
{   
    Master,
    BGM, 
    SFX,
}

public class SoundManager : MonoSingleton<SoundManager>
{
    [Header("=== Audio Mixer ===")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("=== Control ===")]
    [SerializeField] private SoundVolumeControl control;

    [Header("=== Audio Management ===")]
    [SerializeField, ReadOnly] private int audioIndex = 0;
    
    private Dictionary<AudioType, Transform> soundTransformDic = new Dictionary<AudioType, Transform>();
    private static Dictionary<AudioType, Dictionary<int, AudioSource>> soundAudioDic = new Dictionary<AudioType, Dictionary<int, AudioSource>>();

    [Header("=== Audio Setting ===")]
    [SerializeField, Range(.1f, 10f)] private float musicFadeSpeed = 1f;

    [Header("=== App Pause ===")]
    private bool applicationPause = false;

    [Header("===!!! Test Audio Clip !!!===")]
    public AudioClip[] misicClip_Test; // 나중에 지움
    public AudioClip[] sfxClip_Test; // 나중에 지움

#region Setting
    private void Awake()
    {
        foreach (AudioType type in Enum.GetValues(typeof(AudioType))) {
            // Master는 사운드 관리에서 제외
            if (type == AudioType.Master) continue;

            // Add Audio Source Transform 
            Transform typeGO = new GameObject(type.ToString()).transform;
            typeGO.transform.parent = this.gameObject.transform;
            soundTransformDic.Add(type, typeGO);

            // Add Audio Management
            soundAudioDic.Add(type, new Dictionary<int, AudioSource>());
        }
    }
#endregion

#region BGM (Loop, 1개의 사운드)
    public int PlayBGM(AudioClip clip, Transform transform = null)
    {
        return PlayBGM(AudioType.BGM, clip, 1f, transform);
    }

    public int PlayBGM(AudioClip clip, float volume, Transform transform = null)
    {
        return PlayBGM(AudioType.BGM, clip, volume, transform);
    }

    private int PlayBGM(AudioType audioType, AudioClip audioClip, float volume, Transform transform)
    {
        StopAllAudio(audioType, musicFadeSpeed); // 기존 음악 제거

        int audioID = AddAudio(audioType, audioClip, volume, transform); // 새 음악 추가

        StartCoroutine(FadeOutCoroutine(GetAudio(audioType, audioID), musicFadeSpeed)); // 볼륨 Fade O

        return audioID;
    }
#endregion

#region Sound (Loop X, 여러개 사운드)
    public int PlaySound(AudioClip clip, Transform transform = null)
    {
        return PlaySound(AudioType.SFX, clip, 1f, transform);
    }

    public int PlaySound(AudioClip clip, float volume, Transform transform = null)
    {
        return PlaySound(AudioType.SFX, clip, volume, transform);
    }

    private int PlaySound(AudioType audioType, AudioClip audioClip, float volume, Transform transform)
    {
        int audioID = AddAudio(audioType, audioClip, volume, transform); // 새 음악 추가

        StartCoroutine(FadeOutCoroutine(GetAudio(audioType, audioID), 0f)); // 볼륨 Fade X 즉시 사운드 실행

        return audioID;
    }
#endregion

#region Add AudioSource (사운드 추가 -> 컴포넌트 할당)
    private int AddAudio(AudioType audioType, AudioClip audioClip, float volume, Transform transform)
    {
        AudioSource audio = AddAudioSource(audioType, volume, transform);
        audio.clip = audioClip;
        soundAudioDic[audioType].Add(audioIndex, audio);

        return audioIndex++;
    }

    private AudioSource AddAudioSource(AudioType audioType, float volume, Transform transform)
    {
        // Set AudioSource Transform
        soundTransformDic.TryGetValue(audioType, out Transform audioTransform);

        // Set AudioSource Transform Exception
        if (transform != null) audioTransform = transform;

        // Set AudioSource
        AudioSource audio = audioTransform.AddComponent<AudioSource>();

        // AudioMixer Setting
        AudioMixerSetting(audioType, audio, volume);

        return audio;
    }

    // AudioMixer로 조절 가능 하도록 설정
    private void AudioMixerSetting(AudioType audioType, AudioSource audio, float volume)
    {
        audio.outputAudioMixerGroup = audioMixer.FindMatchingGroups(audioType.ToString())[0];
        audio.volume = volume;

        if (audioType == AudioType.BGM) {
            audio.loop = true;
        }
    }
#endregion

#region Auto Remove Audio (자동 삭제 관리)
    private void LateUpdate()
    {
        foreach (var audioDic in soundAudioDic) {
            UpdateAllAudio(audioDic.Value);
        }
    }

    private void UpdateAllAudio(Dictionary<int, AudioSource> audioDic)
    {
        List<int> keys = new List<int>(audioDic.Keys);
        foreach (int key in keys) {
            AudioSource audio = audioDic[key];

            if (!audio.isPlaying && !applicationPause) {
                Destroy(audio);
                audioDic.Remove(key);
            }
        }
    }
#endregion

#region Stop All Audio (모든 사운드 삭제)
    private void StopAllAudio(AudioType audioType, float fadeOutTime)
    {
        Dictionary<int, AudioSource> audioDic = soundAudioDic[audioType];
        List<int> keys = new List<int>(audioDic.Keys);
        
        StopAllCoroutines();
        foreach (int key in keys) {
            AudioSource audio = audioDic[key];
            if (fadeOutTime > 0) {
                StartCoroutine(FadeInCoroutine(audio, fadeOutTime));
            }
            else {
                audio.Pause();
            }
        }
    }
#endregion

#region Volume Fade (볼륨 페이드 인/아웃 효과)
    IEnumerator FadeInCoroutine(AudioSource audio, float fadeOutTime, Action callBack = null) // Volume Off
    {
        float time = 0f;
        float startVolume = audio.volume;
        
        if (fadeOutTime > 0) {
            while (time <= fadeOutTime) {
                audio.volume = Mathf.Lerp(startVolume, 0f, time / fadeOutTime);
                time += Time.deltaTime;
                yield return null;
            }
        }
        audio.volume = 0f;
        audio.Pause();
        callBack?.Invoke();
    }

    IEnumerator FadeOutCoroutine(AudioSource audio, float fadeOutTime, Action callBack = null)  // Volume On
    {
        float time = 0f;
        float startVolume = audio.volume;
        audio.Play();

        if (fadeOutTime > 0) {
            while (time <= fadeOutTime) {
                audio.volume = Mathf.Lerp(0f, startVolume, time / fadeOutTime);
                time += Time.deltaTime;
                yield return null;
            }
        }
        audio.volume = startVolume;
        callBack?.Invoke();
    }
#endregion

#region Get Set, ETC
    private AudioSource GetAudio(AudioType audioType, int audioID)
    {
        return soundAudioDic[audioType].TryGetValue(audioID, out AudioSource value) ? value : null;
    }

    public SoundVolumeControl GetControl()
    {
        return control;
    }

    public AudioMixer GetAudioMixer()
    {
        return audioMixer;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) {
            applicationPause = true;
        }
        else {
            if (applicationPause) {
                applicationPause = false;
            }
        }
    }
#endregion
}