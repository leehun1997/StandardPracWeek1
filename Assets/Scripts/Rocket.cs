using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    protected RocketEnergySystem rocketEnergySystem;
    protected GameObject fuelImage;
    public float fuel = 100f;

    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    private void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
        rocketEnergySystem = GetComponent<RocketEnergySystem>();
        fuelImage = GameObject.Find("Front");
    }

    private void Update()
    {
        rocketEnergySystem.FuelRecover();
        fuelImage.GetComponent<Image>().fillAmount = fuel / 100;
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel > 10)
        {
            fuel -= FUELPERSHOOT;
            _rb2d.AddForce(transform.up * SPEED);
        }
        else
            Debug.Log("Not Enough Fuel");
    }

    public void ReStartBTN()
    {
        GetComponent<RocketDashBoard>().SaveHighScore();
        SceneManager.LoadScene("RocketLauncher");
    }
}
