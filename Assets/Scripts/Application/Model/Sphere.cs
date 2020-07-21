using System.Collections;
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
    public UnityWebRequest req;
    int NumChannelSend = 2;

    private new void Awake()
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

    IEnumerator GetAudioClip(string audioFile)
    {
        var formattedAudioFile = FormatAudioFile(audioFile);
        AudioType audioType = GetAudioType(audioFile);

        using (req = UnityWebRequestMultimedia.GetAudioClip(formattedAudioFile, audioType))
        {
            yield return req.SendWebRequest();

            if (req.isNetworkError)
            {
                app.Notify(Notification.LogError, req.error);
            }
            else
            {
                if (req != null && req.isDone) {
                    AudioClip c = DownloadHandlerAudioClip.GetContent(req);
                    audioSource.clip = c;
                } else
                {
                    app.Notify(Notification.LogError, "Download of audio clip unsuccessful.");
                }
            }
        }
    }

    Uri FormatAudioFile(string audioFile)
    {
        // TODO: something less bad that would work on windows and anything not on MHD
        if (audioFile.StartsWith("Macintosh HD:"))
        {
            audioFile = audioFile.Replace("Macintosh HD:", "");
        }

        var uri = new Uri(audioFile);

        return uri;
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

    public void UpdateAudioFile(string audioFile)
    {
        if (audioFile != null)
        {
            if ((audioSource.clip == null) || (audioSource.clip != null && audioFile != audioSource.clip.name))
            {
                app.Notify(Notification.Log, audioFile);
                StartCoroutine(GetAudioClip(audioFile));
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
            // that deletes itself when done?
            int track = collision.gameObject.GetComponent<Surface>().id;
            jackSourceSend.trackNumber = track * NumChannelSend;
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
            app.Notify(Notification.LogError, "Unsupported audio file type.");
            return AudioType.UNKNOWN;
        }
    }
}
