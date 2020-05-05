using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JackAudio;

public class Sphere : PECModel
{
    // TODO : set ID properly
    // TODO: implement delete by ID
    // TODO: implement type-ID composite ID
    // TODO: implement delete by composite ID
    public int id;

    public SphereType sphereType;

    public AudioSource audioSource;
    public SphereCollider sphereCollider;
    public JackSourceSend jackSourceSend;
    public Rigidbody rigidBody;
    public WWW www;


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

    public void Init()
    {
        UpdateScale(sphereType.scale);
        UpdateBounciness(sphereType.bounciness);
        UpdateMass(sphereType.mass);
        UpdateAudioFile(sphereType.audio_file);
    }

    public void UpdateAudioFile(string audio_file)
    {
        app.Notify(Notification.Log, "Updating audio file: " + audio_file);

        if (audio_file != null)
        {
            www = new WWW(audio_file);

            if (www.error != null)
            {
                app.Notify(Notification.Error, www.error);
            }
            else
            {
                LoadAudioFile(audio_file);
            }
        }
    }

    public void UpdateMass(float mass)
    {
        rigidBody.mass = mass;
    }

    public void UpdateScale(float scale)
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void UpdateBounciness(float bounciness)
    {
        sphereCollider.sharedMaterial.bounciness = bounciness;
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
        }

        audioSource.Play();
    }

    public void ShootSphere(float speed)
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * speed;
    }

    public void DestroySphere()
    {
        Destroy(gameObject);
    }

    public void LoadAudioFile(string audio_file)
    {
        if (!(audio_file is null))
        {
            //AudioClip c = Resources.Load<AudioClip>(sphereType.audio_file);
            //audioSource.clip = c;

            string extension = audio_file.Substring(audio_file.Length - 4);

            if (extension.Equals(".ogg"))
                audioSource.clip = www.GetAudioClip(false, false, AudioType.OGGVORBIS);
            else if (extension.Equals(".mp3"))
                audioSource.clip = www.GetAudioClip(false, false, AudioType.MPEG);
            else if (extension.Equals(".wav"))
                audioSource.clip = www.GetAudioClip(false, false, AudioType.WAV);
            else
                audioSource.clip = www.GetAudioClip(false, false, AudioType.UNKNOWN);

            if (audioSource.clip.loadState != AudioDataLoadState.Loaded)
            {
                StartWait();
            }
        } else {
            app.Notify(Notification.Error, "Error in audio file name " + audio_file + ".");
        }
    }

    IEnumerator StartWait()
    {
        app.Notify(Notification.Log, "Waiting for audio file to load.");

        yield return new WaitForSeconds(5);

        if (audioSource.clip.loadState != AudioDataLoadState.Loaded)
        {
            app.Notify(Notification.Error, "Audio file taking too long to load.");
        }
    }
}