using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    float runSpeed = 40f;
    [SerializeField]
    private ParticleManager pM;
    [SerializeField]
    private BulletPool bullets;
    [SerializeField]
    private ObjectPool targets;
    [SerializeField]
    ParticleSystem particle;

    bool isCoroutineRuninng;


    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetMouseButtonDown(0))
        {
            if (!isCoroutineRuninng)
                   StartCoroutine(Shoot());
        }


    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,false);

    }

    private IEnumerator Shoot()
    {
        isCoroutineRuninng = true;

            RocketController bullet = bullets.GetPooledObject();
            GameObject target = targets.GetPooledObject();
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 fixedTargetPosition = new Vector3(targetPosition.x, targetPosition.y, 5);
            if (bullet != null)
            {
                target.transform.position = fixedTargetPosition;
                target.SetActive(true);
                bullet.SetStartPosition(transform.position);
                bullet.SetTargetPosition(fixedTargetPosition);
                bullet.targetCursor = target;
                bullet.transform.position = transform.position;
                bullet.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
            }
        isCoroutineRuninng = false;
    }
        private void OnCollisionEnter(Collision collision)
    {
        particle.Play();
    }
}
