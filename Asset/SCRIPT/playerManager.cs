using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isItemTaken;

    [Header("Assign UI yang ingin ditampilkan")]
    public GameObject uiElement;

    private void Awake()
    {
        isGameOver = false;
        isItemTaken = false; // Inisialisasi item belum diambil
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            gameOverScreen.SetActive(true);
        }

        // Jika item sudah diambil, maka tampilkan UI
        else if (isItemTaken == true)
        {
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Ini dibuat matiin UI ketika player menekan tombol continue
    public void OraNampak()
    {
        isItemTaken = false;
        uiElement.SetActive(false);
    }
}
