using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 targetPosition;
    public float speed=5f;
    public GameObject targetCursor;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject mesh;

    public void SetStartPosition(Vector3 startPos)
    {
        startPosition = startPos;
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }

    private void StartMoving()
    {
        if (!gameObject.activeSelf)
            return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            mesh.SetActive(false);
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        explosion.SetActive(true);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        mesh.SetActive(true);
        explosion.SetActive(false);
    }
    private void Update()
    {
        StartMoving();

    }
}
