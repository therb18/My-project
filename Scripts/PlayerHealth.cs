using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    public float _maxValue;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();

    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<Playercontroller>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotatoin>().enabled = false;
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    // Start is called before the first frame update
    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
