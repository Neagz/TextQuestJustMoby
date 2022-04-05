using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool keyPressAlpha1 = false; // Button press counter number 1
    private bool keyPressAlpha2 = false; // Button press counter number 2
    private bool keyBlock = false; // Second button press counter number 1

    void Start()
    {
        Tavern();
    }

    private void Update()
    {
        First_Action();
    }

    void Tavern()
    {
        Debug.Log("<color=yellow>Комната 1. Таверна</color>");
        StartCoroutine(Room());
    }

    void First_Action()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (keyPressAlpha1 == false)
            {
                StartCoroutine(Talk());
                Debug.Log("Бродяга отвечает: \n " +
                          "- Вот возьми всё что у меня есть, только не трогай меня");
                keyPressAlpha1 = true;
                StartCoroutine(Choice());
                keyPressAlpha2 = true;
            }

            else if (keyBlock == false && keyPressAlpha1 == true)
            {
                Debug.Log("<color=green>Получены предметы от бродяги - медальон и 50 монет</color>");
                Debug.Log("Бродяга отвечает: \n - Я теперь умру с голоду");
                keyBlock = true;
                keyPressAlpha2 = false;
                Start();
            }
            
            else if (keyBlock == true && keyPressAlpha1 == true)
            {
                Debug.Log("Бродяга отвечает: \n - У меня больше ничего нет!");
                Start();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (keyPressAlpha2 == false)
            {
                Debug.Log("<i>«Золотой Осетр» является одной из самых известных таверн в Новиграде; " +
                          "где, в основном, любят останавливаться моряки и рабочие порта. \n " +
                          "В таверне часто происходят шумные застолья, а также драки.</i>");
                Start();
            }
            
            else if (keyPressAlpha2 == true)
            {
                Debug.Log("<color=red>Бродяга всадил Вам нож в спину как только Вы отвернулись</color>");
                Destroy(gameObject);
            }

        }
    }

    IEnumerator Room()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Чтобы поговорить с бродягой - <b>Нажмите кнопку (1)</b>");
        Debug.Log("Чтобы осмотреть окрестность - <b>Нажмите кнопку (2)</b>");
    }

    IEnumerator Talk()
    {
        Debug.Log("Разговор с бродягой начался: \n - Жизнь или смерть, грязный бродяга!");
        yield return new WaitForSeconds(2);
    }

    IEnumerator Choice()
    {
        yield return new WaitForSeconds(6);
        Debug.Log("Чтобы забрать всё что у него есть - <b>Нажмите кнопку (1)</b>");
        Debug.Log("Чтобы оставить бродягу в покое - <b>Нажмите кнопку (2)</b>");
    }

}
