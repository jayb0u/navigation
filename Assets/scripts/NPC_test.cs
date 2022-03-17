using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_test : MonoBehaviour
{
    public Camera mainCamera;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //si le joueur à cliqué
        if (Input.GetMouseButtonDown(0))
        {
            //trouvé la position du clic
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out RaycastHit hit))
            {
                //Déplacer le PNJ vers la position
                agent.SetDestination(hit.point);
            }

            
        }

    }
}
