using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTaskScript : MonoBehaviour
{
    public List<string> tools;
    public GameObject arrow;
    public List<GameObject> remove;
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private GameObject completeRepetition;
    [SerializeField]
    private GameObject enableChairCircle;
    [SerializeField]
    private GameObject taskText;
    [SerializeField]
    private GameObject toysTumba;
    public Animator dentist;
    public AudioClip audioClippy;
    public AudioSource audioSourcy;
    // Start is called before the first frame update
    public void doTask(string toolName)
    {
        if (toolName == "tutorialbrush")
        {
            dialogueBox.SetActive(true);
            audioSourcy.clip = audioClippy;
            audioSourcy.Play();
            return;
        }

        if (tools.Count > 0 && toolName == tools[tools.Count - 1])
        {
            audioSourcy.clip = audioClippy;
            audioSourcy.Play();
            KeepScore.totalScore += 1000;
            if ((tools.Count - 1) % 4 == 0 && tools.Count != 0)
            {
                arrow.transform.position -= new Vector3(0, 0, 0.5f);
            }
            tools.RemoveAt(tools.Count - 1);
        }
        if (tools.Count == 0)
        {
            arrow.SetActive(false);
            gameObject.SetActive(false);
            taskText.SetActive(false);
            dentist.SetBool("finishedTools", true);
            completeRepetition.SetActive(true);
            enableChairCircle.SetActive(true);
            toysTumba.SetActive(true);

            foreach (var item in remove)
            {
                item.SetActive(false);
            }
        }
    }
}
