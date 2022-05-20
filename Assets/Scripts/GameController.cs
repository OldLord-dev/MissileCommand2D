using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public Texture2D cursorTexture;
    [SerializeField]
    private ObjectPool asteroids;
    [SerializeField]
    UIManager uiManager;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private Vector2 target;
    [SerializeField]
    private Collider asteroidSpawner;


    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, curMode);
    }

    void Update()
    {
        StartCoroutine(Spawn());
        if (Input.GetKey(KeyCode.Escape))
        {
            uiManager.Pause();
        }
        if (uiManager.GetSliderValue() == 0)
        {
            uiManager.GameOver();
        }
    }

    public IEnumerator Spawn()
    {
        GameObject asteroid = asteroids.GetPooledObject();
        if (asteroid != null)
                {
        Vector3 bottomLeft = new Vector3(asteroidSpawner.bounds.min.x, asteroidSpawner.bounds.min.y, 5f);
        Vector3 bottomRight = new Vector3(asteroidSpawner.bounds.max.x, asteroidSpawner.bounds.min.y, 5f);
        asteroid.transform.position = Vector3.Lerp(bottomLeft, bottomRight, UnityEngine.Random.value);
            yield return new WaitForSeconds(2);
            asteroid.SetActive(true);
        yield return new WaitForSeconds(10);
                }
    }


}




