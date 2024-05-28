using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ToggleMenu : MonoBehaviour
{
    private ControlMap controlMap;
    private bool isactive = false;
    
    [Header("GameObjects")]
    public GameObject returnbtn;

    public GameObject restartbtn;

    public GameObject scoretxt;
    public GameObject speedtxt;
    private void Start()
    {
        controlMap = new ControlMap();
        controlMap.Menu.Enable();
    }

    private void Update()
    {
        if (controlMap.Menu.ToggleMenu.triggered)
        {
            isactive = !isactive;
            if (isactive)
            {
                controlMap.Player.Disable();
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                returnbtn.SetActive(true);
                restartbtn.SetActive(true);
                speedtxt.SetActive(false);
                scoretxt.SetActive(false);
            }
            else
            {
                controlMap.Player.Enable();
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                returnbtn.SetActive(false);
                restartbtn.SetActive(false);
                speedtxt.SetActive(true);
                scoretxt.SetActive(true);
            }
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
