using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PECModel
{
    public float shootSpeed;
    public float navigationSpeed;

    public Player()
    {
        shootSpeed = 10f;
        navigationSpeed = 10f;
    }

    public void RotateRight()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * navigationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;

    }

    public void RotateLeft()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * navigationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;

    }

    public void TranslateRight()
    {
        transform.Translate(new Vector3(navigationSpeed * Time.deltaTime, 0, 0));
    }

    public void TranslateLeft()
    {
        transform.Translate(new Vector3(-navigationSpeed * Time.deltaTime, 0, 0));
    }

    public void TranslateUp()
    {
        transform.Translate(new Vector3(0, navigationSpeed * Time.deltaTime, 0));
    }

    public void TranslateDown()
    {
        transform.Translate(new Vector3(0, -navigationSpeed * Time.deltaTime, 0));
    }

    public void TranslateBack()
    {
        transform.Translate(new Vector3(0, 0, -navigationSpeed * Time.deltaTime));
    }

    public void TranslateForward()
    {
        transform.Translate(new Vector3(0, 0, navigationSpeed * Time.deltaTime));
    }
}
