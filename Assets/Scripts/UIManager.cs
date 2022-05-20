using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("PauseMenu Manager")]
    [SerializeField] GameObject pauseMenu;
    [Header("Health Manager")]
    [SerializeField] private List<BuildingBehavior> buildings = new List<BuildingBehavior>();
    [SerializeField] Slider slider;
    int numberOfBuildings;
    [Header("GameOver Manager")]
    [SerializeField] GameObject gameOverWindow;
    float damageValue;
    [SerializeField]
    BulletPool bulletPool;
    float numberOfBullets;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1f;
    }


    void Start()
    {
        Time.timeScale = 1f;
        this.slider.value = 1f;
        numberOfBuildings = buildings.Count;
        damageValue = slider.value / numberOfBuildings;
    }

    public void OnBuildingDestroyed()
    {
        slider.value -= damageValue;
    }
    public float GetSliderValue()
    {
        return slider.value;
    }
}
