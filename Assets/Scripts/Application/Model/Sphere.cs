using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using JackAudio;
using System.IO;
using System;

public class Sphere : PECModel
{
    // TODO : set ID properly
    // TODO: implement delete by ID
    // TODO: implement type-ID composite ID
    // TODO: implement delete by composite ID
    public int id;
    public int sphereTypeId;

    public AudioSource audioSource;
    public SphereCollider sphereCollider;
    public JackSourceSend jackSourceSend;
    public Rigidbody rigidBody;
    //public WWW www;
    public UnityWebRequest www;


    private void Awake()
    {
        base.Awake();

        sphereCollider = gameObject.GetComponent<SphereCollider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        jackSourceSend = gameObject.GetComponent<JackSourceSend>();
        rigidBody = gameObject.GetComponent<Rigidbody>();

        // TODO: load this in a different way, faster, have multiplexer object stored somewhere
        jackSourceSend.multiplexer = FindObjectOfType<JackMultiplexer>();
    }

    public void Init(SphereType sphereType)
    {
        sphereTypeId = sphereType.id;

        UpdateScale(sphereType.scale);
        UpdateBounciness(sphereType.bounciness);
        UpdateMass(sphereType.mass);
        UpdateAudioFile(sphereType.audio_file);
    }

    IEnumerator GetAudioClip(string audioFile, AudioType audioType)
    {
        var uri = new Uri(audioFile);
        using (www = UnityWebRequestMultimedia.GetAudioClip(uri, audioType))
        //using (www = UnityWebRequestMultimedia.GetAudioClip("file://" + audioFile, audioType))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www != null && www.isDone) {
                    AudioClip c = DownloadHandlerAudioClip.GetContent(www);
                    audioSource.clip = c;
                }
            }
        }
    }
    public void UpdateScale(float scale)
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void UpdateBounciness(float bounciness)
    {
        sphereCollider.sharedMaterial.bounciness = bounciness;
    }

    public void UpdateMass(float mass)
    {
        rigidBody.mass = mass;
    }

    public void UpdateAudioFile(string audio_file)
    {
        if (audio_file != null)
        {
            // if updated clip is new
            if ((audioSource.clip == null) || (audioSource.clip != null && audio_file != audioSource.clip.name))
            {

                app.Notify(Notification.Log, "Updating to audio file: " + audio_file);
                StartCoroutine(GetAudioClip(audio_file, GetAudioType(audio_file)));

                //www = new WWW("file:///" + audio_file);

                //if (www.error != null)
                //{
                //    app.Notify(Notification.LogError, www.error);
                //}
                //else
                //{
                //    LoadAudioFile(audio_file);
                //}
            }
        }
        else
        {
            app.Notify(Notification.LogError, "Audio file name error.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // pass current sphere and collision data
        var data = new object[] { collision, gameObject };

        // notify app in case other controllers want this information too
        app.Notify(Notification.SphereCollision, data);
        PlaySample(collision);
    }

    private void PlaySample(Collision collision)
    {
        if (collision.gameObject.tag == "surface")
        {
            // TODO: check how audio channel data is handled coming from audio source
            // TODO: check if audio is playing, then create another jackSourceSend component
            // that deletes itself when done
            int track = collision.gameObject.GetComponent<Surface>().id;
            jackSourceSend.trackNumber = track;
            audioSource.Play();
        }
    }

    public void ShootSphere(float speed)
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * speed;
    }

    public void DestroySphere()
    {
        Destroy(gameObject);
    }

    AudioType GetAudioType(string audioFile)
    {
        string fileExtension = Path.GetExtension(audioFile);

        if (fileExtension.Equals(".ogg"))
        {
            return AudioType.OGGVORBIS;
        }
        else if (fileExtension.Equals(".mp3"))
        {
            return AudioType.MPEG;
        }
        else if (fileExtension.Equals(".wav"))
        {
            return AudioType.WAV;
        }
        else
        {
            return AudioType.UNKNOWN;
        }
    }

    //public void LoadAudioFile(string audio_file)
    //{
    //    //AudioClip c = Resources.Load<AudioClip>(sphereType.audio_file);
    //    //audioSource.clip = c;
    //    string fileExtension = Path.GetExtension(audio_file);

    //    if (fileExtension.Equals(".ogg"))
    //    {
    //        audioSource.clip = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
    //    }
    //    else if (fileExtension.Equals(".mp3"))
    //    {
    //        audioSource.clip = www.GetAudioClip(false, false, AudioType.MPEG);
    //    }
    //    else if (fileExtension.Equals(".wav"))
    //    {
    //        audioSource.clip = www.GetAudioClip(www, true, false, AudioType.WAV);
    //        //audioSource.clip = www.GetAudioClip(false, false, AudioType.WAV);
    //    }
    //    else
    //    {
    //        audioSource.clip = www.GetAudioClip(false, false, AudioType.UNKNOWN);
    //    }

    //    StartWait();
    //}

    //IEnumerator StartWait()
    //{
    //    if (audioSource.clip.loadState != AudioDataLoadState.Loaded)
    //    {
    //        app.Notify(Notification.Log, "Waiting for audio file to load.");

    //        yield return new WaitForSeconds(10f);

    //        if (audioSource.clip.loadState != AudioDataLoadState.Loaded)
    //        {
    //            app.Notify(Notification.LogError, "Audio file taking too long to load.");
    //        }
    //    }
    //}
}