using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Réglages")]
    public float duration = 3f;
    public float pauseDuration = 0.5f;

    [Header("Objet")]
    public Transform obstacle;

    private void Start()
    {
        StartCoroutine(Translation(pointA.position, pointB.position));
    }

    IEnumerator Translation(Vector3 _startPoint, Vector3 _endPoint)
    {
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            obstacle.position = Vector3.Lerp(_startPoint, _endPoint, elapsedTime / duration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(pauseDuration);

        StartCoroutine(Translation(_endPoint, _startPoint));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
