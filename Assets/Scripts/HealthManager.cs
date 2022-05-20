using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private List<BuildingBehavior> buildings =  new List<BuildingBehavior>();
    [SerializeField] Slider slider;
    int numberOfBuildings;
    float damageValue;
    void Start()
    {
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
