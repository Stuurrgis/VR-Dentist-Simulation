using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;

    // OnClick functions will only work with certain parameters. Believe it only accepts one
    public virtual void ChangePosition(string place)
    {
        float y = camera.transform.position.y;
        if(place == "dental")
        {
            camera.transform.position = new Vector3(-3, y, 3);
        }

        if (place == "tutorial")
        {
            GameObject.Find("MixedRealityCameraParent").transform.position = new Vector3(-5.39f, 2.191f, 7.34f);
        }

        if(place =="help screen")
        {
            GameObject.Find("MixedRealityCameraParent").transform.position = new Vector3(0, 0, 1094);
            GameObject.Find("MixedRealityCameraParent").transform.Rotate(0, 180, 0);
        }

        if(place == "start")
        {
            GameObject.Find("MixedRealityCameraParent").transform.position = new Vector3(0, 0, 2309);
            GameObject.Find("MixedRealityCameraParent").transform.Rotate(0, 180, 0);
        }

        if(place == "sit dental chair")
        {
            print("on");
            GameObject.Find("MixedRealityCameraParent").transform.position = new Vector3(3.605f, y, -1.53f);
            GameObject.Find("MixedRealityCameraParent").transform.rotation = Quaternion.Euler(-30, 0, 0);
        }

        if (place == "get off dental chair")
        {
            print("off");
            GameObject.Find("MixedRealityCameraParent").transform.position = new Vector3(3.6f, y, -2.829f);
            GameObject.Find("MixedRealityCameraParent").transform.Find("MixedRealityCamera").transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
