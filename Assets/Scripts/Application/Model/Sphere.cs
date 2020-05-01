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

    private void Awake()
    {
        base.Awake();
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        jackSourceSend = gameObject.GetComponent<JackSourceSend>();

        // TODO: load this in a different way, faster, have multiplexer object stored somewhere
        jackSourceSend.multiplexer = FindObjectOfType<JackMultiplexer>();

    }

    public void Init()
    {
        LoadAudioFile();
        UpdateScale(sphereType.scale);
        UpdateBounciness(sphereType.bounciness);
    }

    private void Update()
    {
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

    public void LoadAudioFile()
    {
        if (!(sphereType.audio_file is null))
        {
            AudioClip c = Resources.Load<AudioClip>(sphereType.audio_file);
            audioSource.clip = c;
        }
    }
}