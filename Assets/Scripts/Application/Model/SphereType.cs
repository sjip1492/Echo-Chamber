using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereType
{
    public int id;
    public float scale;
    public float bounciness;
    public string audio_file;


    public SphereType(int id, float scale, float bounciness, string audio_file)
    {
        this.id = id;
        this.scale = scale;
        this.bounciness = bounciness;
        this.audio_file = audio_file;
    }

    public SphereType()
    {
        this.id = 1;
        this.scale = 1.0f;
        this.bounciness = 1.0f;
        this.audio_file = null;

        // TODO: implement envelopes
        //this.envelope = envelope;
    }
}

