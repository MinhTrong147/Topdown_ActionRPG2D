using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UINextState : Singleton<UINextState>
{
    [SerializeField] private Image fadeSrceen;
    [SerializeField] private float fadeSpeed = 1f;
    private IEnumerator fadeRoutine;
    public void FadeToDarkness(){
        if(fadeRoutine != null){
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }
    public void FadeToSofter (){
        if(fadeRoutine != null){
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }
    private IEnumerator FadeRoutine(float targetAlpha){
        while(!Mathf.Approximately(fadeSrceen.color.a, targetAlpha)){
            float alpha = Mathf.MoveTowards(fadeSrceen.color.a,targetAlpha, fadeSpeed* Time.deltaTime);
            fadeSrceen.color = new Color(fadeSrceen.color.r, fadeSrceen.color.g,fadeSrceen.color.b, alpha);
            yield return null;
        }
    }
}
