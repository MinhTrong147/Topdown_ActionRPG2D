using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private float roamchangeDirFloat = 2f;
    private enum State{
        Roaming
    }
    private State state;
    private EnemiesFinding enemiesFinding;

    private void  Awake() {
        enemiesFinding = GetComponent<EnemiesFinding>();
        state = State.Roaming;
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine(){
        while(state == State.Roaming)
        {  
            Vector2 randomPosition = GetRoamingPosition();
            enemiesFinding.MovePoint(randomPosition);
            yield return new WaitForSeconds(roamchangeDirFloat);
                  
                  
        }
    }
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
    }
}
