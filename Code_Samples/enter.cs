using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enter : MonoBehaviour
{
    public List<GameObject> enableObjects;
    public List<GameObject> disableObjects;
    public GameObject player;
    public AudioClip audioClippy;
    public AudioSource audioSourcy;
    public GameObject headsetCamera;
    public int score;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("MixedRealityCameraParent");
        headsetCamera = GameObject.Find("MixedRealityCamera");
    }

    private void Update()
    {
       
    }


    private void collided()
    {
        foreach(var item in enableObjects)
        {
            item.SetActive(true);
        }
        foreach (var item in disableObjects)
        {
            item.SetActive(false);
        }

    }


    private double calcxzDistance(Vector3 position1, Quaternion rotation,Vector3 position2)
    {
        double x = position1.x - 0.5 * Math.Cos(rotation.y);
        double z = position1.z - 0.5 * Math.Sin(rotation.y);
        //double x = position1.x - cameraPos.x;
        //double z = position1.z - cameraPos.z;
        double pos = Math.Sqrt(Math.Pow(x - position2.x, 2) + Math.Pow(z - position2.z, 2));
        //double camera_pos = Math.InvCos(position1.y) + Math.Sin(position1.y);
        return pos;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioSourcy.clip = audioClippy;
            collided();
            KeepScore.totalScore += score;
            gameObject.SetActive(false);
            audioSourcy.Play();
        }
    }
}
