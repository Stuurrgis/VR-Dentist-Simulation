using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class MouthMiniGame : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
    [SerializeField]
    private string timerName;
    private GameObject timer;
    [SerializeField]
    private InteractionSourcePressType pressType = InteractionSourcePressType.None;
    [SerializeField]
    private float holdDuration;
    private float lastPress;
    private Animator dentist;
    private bool instructions = false;
    private bool operation = true;
    private bool operFin = false;
    private GameObject instructionBox;
    private GameObject operationBox;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        dentist = animator;
        timer = animator.transform.GetChild(10).gameObject;
        instructionBox = animator.transform.GetChild(11).GetChild(0).gameObject;
        operationBox = animator.transform.GetChild(11).GetChild(1).gameObject;
        InteractionManager.InteractionSourcePressed += InteractionSourcePressed;
        animator.transform.GetChild(11).gameObject.SetActive(true);
        instructionBox.SetActive(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        InteractionManager.InteractionSourcePressed -= InteractionSourcePressed;
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}


#if UNITY_WSA && UNITY_2017_2_OR_NEWER
    private void InteractionSourcePressed(InteractionSourcePressedEventArgs obj)
    {
        if (obj.pressType == pressType && !instructions)
        {
            instructions = instructionBox.GetComponent<chairBoxUI>().updateTextBool();
        }
        else if (obj.pressType == pressType && operation && !operFin)
        {
            InteractionManager.InteractionSourceReleased += InteractionSourceReleased;
            instructionBox.SetActive(false);
            timer.SetActive(true);
            lastPress = Time.time;
            timer.GetComponent<timerTwo>().BeginCountdown();
        }
        else if (obj.pressType == pressType && !operation)
        {
            operation = operationBox.GetComponent<chairBoxUI>().updateTextBool();
            if (operation)
            {
                operFin = true;
            }
        }
        else if(obj.pressType == pressType)
        {
            operationBox.SetActive(false);
            dentist.SetBool("MouthGameFinish", true);
        }
    }
#endif

#if UNITY_WSA && UNITY_2017_2_OR_NEWER
    private void InteractionSourceReleased(InteractionSourceReleasedEventArgs obj)
    {
        if (obj.pressType == pressType)
        {
            Debug.Log(Time.time - lastPress >= holdDuration);
            if(Time.time - lastPress >= holdDuration)
            {
                operation = false;
                timer.SetActive(false);
                operationBox.SetActive(true);
                InteractionManager.InteractionSourceReleased -= InteractionSourceReleased;
            }
            else
            {
                timer.GetComponent<timerTwo>().RestartCountdown();
            }
         
        }
    }
#endif

}
