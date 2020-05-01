using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PECController
{
    public Player player;

    public override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        ControlCameraMovement();
        ControlGameObjects();
    }

    public override void OnNotification(string p_event_path, params object[] p_data)
    {
        switch (p_event_path)
        {
            case Notification.PlayerShootSpeedOsc:
                Debug.Log("Received Osc message: " + Notification.PlayerShootSpeedOsc);
                UpdateShootSpeedOsc((OscMessage)p_data[0]);
                break;

            case Notification.PlayerShootSpeed:
                UpdateShootSpeed((float)p_data[0]);
                break;

            //case Notification.SphereShoot:
            //    ShootSphere(playerController.player.shootSpeed);
            //    break;

            default:
                break;
        }
    }

    public void UpdateShootSpeedOsc(OscMessage message)
    {
        float speed = message.GetFloat(0);
        player.shootSpeed = speed;
    }

    public void UpdateShootSpeed(float shootSpeed)
    {
        player.shootSpeed = shootSpeed;
    }

    void ControlGameObjects()
    {
        UnityEngine.KeyCode GEN_BALL = KeyCode.Space;
        UnityEngine.KeyCode DEL_BALL = KeyCode.X;

        if (Input.GetKeyDown(GEN_BALL))
        {
            app.Notify(Notification.SphereShoot, this);
        }

        if (Input.GetKeyDown(DEL_BALL))
        {
            app.Notify(Notification.SphereDelete, this);
        }
    }

    void ControlCameraMovement()
    {
        UnityEngine.KeyCode ROT_RIGHT = KeyCode.D;
        UnityEngine.KeyCode ROT_LEFT = KeyCode.A;
        UnityEngine.KeyCode TRANS_FORW = KeyCode.UpArrow;
        UnityEngine.KeyCode TRANS_BACK = KeyCode.DownArrow;
        UnityEngine.KeyCode TRANS_UP = KeyCode.W;
        UnityEngine.KeyCode TRANS_DOWN = KeyCode.S;
        UnityEngine.KeyCode TRANS_LEFT = KeyCode.LeftArrow;
        UnityEngine.KeyCode TRANS_RIGHT = KeyCode.RightArrow;

        if (Input.GetKey(ROT_RIGHT))
        {
            player.RotateRight();
        }

        if (Input.GetKey(ROT_LEFT))
        {
            player.RotateLeft();
        }

        if (Input.GetKey(TRANS_RIGHT))
        {
            player.TranslateRight();
        }

        if (Input.GetKey(TRANS_LEFT))
        {
            player.TranslateLeft();
        }

        if (Input.GetKey(TRANS_UP))
        {
            player.TranslateUp();
        }

        if (Input.GetKey(TRANS_DOWN))
        {
            player.TranslateDown();
        }

        if (Input.GetKey(TRANS_BACK))
        {
            player.TranslateBack();
        }

        if (Input.GetKey(TRANS_FORW))
        {
            player.TranslateForward();
        }
    }

}
