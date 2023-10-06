using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    private float waitToLoadTime = 1f;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<CharacterControl> ()) 
        {
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            UINextState.Instance.FadeToDarkness();
            StartCoroutine(LoadSceneRoutine());
        }
    }
    private IEnumerator LoadSceneRoutine(){
        // while (waitToLoadTime >=0){
        //     waitToLoadTime -= Time.deltaTime;
        //     yield return null;
        // }
        yield return new WaitForSeconds(waitToLoadTime);
        SceneManager.LoadScene(sceneToLoad);            
    }

}
