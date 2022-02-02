using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PauseMenu : MonoBehaviour
{
    private float m_TimeScaleRef = 1f;
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
    [SerializeField]
    private InteractionSourcePressType pressType = InteractionSourcePressType.None;
    [SerializeField]
    private InteractionSourcePressType endType = InteractionSourcePressType.None;
    [SerializeField]
    private GameObject pauseMenu;
#endif
    bool inPause = false;

    [SerializeField]
    public List<GameObject> lights;


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
        InteractionManager.InteractionSourcePressed += InteractionSourcePressed;
       // InteractionManager.InteractionSourceReleased += InteractionSourceReleased;
#endif
    }

#if UNITY_WSA && UNITY_2017_2_OR_NEWER
    private void InteractionSourcePressed(InteractionSourcePressedEventArgs obj){
        if (obj.pressType == pressType && !inPause)
        {
            pauseMenu.SetActive(true);
            StartPause();
            inPause = true;
        }
        else if (obj.pressType == endType && inPause)
        {
            print("time to end game");
            print(obj.pressType);
            EndGame();
        }
        else if (obj.pressType == pressType) ;
        {
            EndPause();
        }
    }
#endif



     private void StartPause()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;
    }

    private void EndPause()
    {
        Time.timeScale = m_TimeScaleRef;

        pauseMenu.SetActive(false);
    }

    private void EndGame()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

}
