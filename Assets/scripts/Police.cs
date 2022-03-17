using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    NavMeshAgent agent;

    //agent en déplacement ou pause
    bool isBusy;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBusy)
        {
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {

        isBusy = true;

        //Trouver une destination
        Vector3 destination = GetRandomDestination();

        //S'y déplacer
        agent.SetDestination(destination);

        //tant qu'on est en déplacement, on ne fait rien
        while(agent.pathPending || agent.remainingDistance > 0.5f)
        {
            yield return null;
        }

        //prendre ensuite une pause de random secondes
        yield return new WaitForSeconds(Random.Range(1f, 5f));

        //Je ne suis plus occupé
        isBusy = false;
    }

    //retourne une position dans les limites du batiment
    Vector3 GetRandomDestination()
    {
        //-11.3 à 7.3
        float limitxleft = -11.3f;
        float limityright = 7.3f;
        float limitz = 11.3f;

        float x = Random.Range(limitxleft, limityright);
        float z = Random.Range(-limitz, limitz);

        return new Vector3(x, 0.6f, z);
    }
}
