using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AnimWalkVFX : MonoBehaviour
{
    // private List<GameObject> spawnedObjects = new List<GameObject>();
    // [SerializeField] private GameObject WalkVFXPrefab;
    // [SerializeField] private Transform transformVFXWalk;
    // private GameObject animWalkVFX; 
    // private Animator animator;
    // private PlayerControl playerControl;
    // private  bool MoveButtonDown, isMove = false; 

    // private string Anim;
    // const string WALK = "Entry";
    // private void Awake() {
    //     animator = GetComponent<Animator>();
    //     playerControl =new PlayerControl();
    // }
    //     private void OnEnable() {
    //         playerControl.Enable();
    // }
    // private void Start() {
    //            playerControl.Movement.Move.started +=_=>MoveSpam();
    //            playerControl.Movement.Move.canceled +=_=>StopMoveSpam();
    // }
    // private void Update() {
    //     WalkVFX();
    // }
    // private void WalkVFX(){    
    //     if(MoveButtonDown && !isMove){ 
    //         animator.Play(WALK);
    //         animWalkVFX= Instantiate(WalkVFXPrefab, transformVFXWalk.position, quaternion.identity);
    //         animWalkVFX.transform.parent = transform.parent;
    //         spawnedObjects.Add(animWalkVFX);

    //     if (spawnedObjects.Count > 1)
    //     {
    //         GameObject oldObject = spawnedObjects[0];
    //         spawnedObjects.RemoveAt(0);
    //         Destroy(oldObject);
    //     }}    


    // }  

    // private void MoveSpam(){
    //     MoveButtonDown = true;
    // }
    // private void StopMoveSpam(){
    //     MoveButtonDown = false;
    // }
}
