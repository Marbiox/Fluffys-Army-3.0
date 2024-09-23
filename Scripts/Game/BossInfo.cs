using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossInfo : MonoBehaviour
{

    [SerializeField] GameObject healthBar;
    [SerializeField] TextMeshProUGUI timeLeftText;
    Slider slider;
    bool spawned = false;

    void Start()
    {
        EventManager.AddListener(EventName.bossSpawned, Spawned);
        EventManager.AddListener(EventName.updateHealthBar, UpdateHealthBar);
        EventManager.AddListener(EventName.updateTimeLeft, TimeLeft);
        slider = healthBar.GetComponent<Slider>();
    }

    void Update()
    {
        if (!spawned)
        {
            healthBar.SetActive(false);
            timeLeftText.text = "";
        }
    }

    void UpdateHealthBar(int health)
    {
        slider.value = health;
        if (health == 0) spawned = false;
    }

    void TimeLeft(int timeLeft)
    {
        timeLeftText.text = timeLeft.ToString();
        if (timeLeft == 0) spawned = false;
    }

    void Spawned()
    {
        healthBar.SetActive(true);
        spawned = true;
        slider.maxValue = ConfigurationUtils.BossHealth;
        slider.minValue = 0;
        slider.value = ConfigurationUtils.BossHealth;
        timeLeftText.text = ConfigurationUtils.BossTime.ToString();
    }
}
