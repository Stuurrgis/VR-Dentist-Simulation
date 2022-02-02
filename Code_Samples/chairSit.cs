using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


public class chairSit : MonoBehaviour
{
    [SerializeField]
    private InteractionSourcePressType pressType = InteractionSourcePressType.None;

    [SerializeField]
    private PositionChanger changer;
    bool nearChair = false;
    bool onChair = false;
    public Animator dentist;
    public List<GameObject> enableObjects;
    public List<GameObject> disableObjects;


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            print("chairSit");
            nearChair = true;
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            InteractionManager.InteractionSourcePressed += InteractionSourcePressed;
#endif
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            InteractionManager.InteractionSourcePressed -= InteractionSourcePressed;
#endif
        }
        nearChair = false;
 

    }


#if UNITY_WSA && UNITY_2017_2_OR_NEWER
    private void InteractionSourcePressed(InteractionSourcePressedEventArgs obj)
    {
        if (obj.pressType == pressType && nearChair)
        {
            if (!onChair)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                changer.ChangePosition("sit dental chair");
                onChair = true;
                dentist.SetBool("onChair", true);
                foreach (var item in enableObjects)
                {
                    item.SetActive(true);
                }
                foreach (var item in disableObjects)
                {
                    item.SetActive(false);
                }

            }
            else
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                changer.ChangePosition("get off dental chair");
                onChair = false;

            }
        }
    }
#endif



    private void enableAll()
    {
        foreach (var item in enableObjects)
        {
            item.SetActive(true);
        }
    }
}
