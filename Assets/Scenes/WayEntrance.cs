using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayEntrance : MonoBehaviour
{
    [SerializeField] private string TransitionName;
    private void Start(){
        if(TransitionName == SceneManagement.Instance.SceneTransitionName)
        {
            CharacterControl.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
            UINextState.Instance.FadeToSofter();
        }
    }
}
