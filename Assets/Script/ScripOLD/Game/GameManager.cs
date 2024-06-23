using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesToDestroy = 10;
    private int destroyedEnemies = 0;
    private bool isLevelCompleted = false;

    private TextMeshProUGUI enemiesToDestroyText;
    private TextMeshProUGUI destroyedEnemiesText;
    private GameObject thanksForplay;
    private void Start()
    {
        // Tìm Text UI elements trong Canvas và lưu vào biến
        enemiesToDestroyText = GameObject.Find("EnemiesToDestroyText").GetComponent<TextMeshProUGUI>();
        destroyedEnemiesText = GameObject.Find("DestroyedEnemiesText").GetComponent<TextMeshProUGUI>();
        // Cập nhật giá trị ban đầu cho Text UI elements
        UpdateUIText();
    }
    // Hàm này được gọi khi một enemy bị tiêu diệt
    public void EnemyDestroyed()
    {
        destroyedEnemies++;
        UpdateUIText();

        // Kiểm tra nếu đã tiêu diệt đủ số lượng enemy để hoàn thành màn
        if (destroyedEnemies >= enemiesToDestroy && !isLevelCompleted)
        {
            isLevelCompleted = true;
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        // Thực hiện các hành động khi hoàn thành màn (scene) ở đây

        // Ví dụ: Chuyển đến màn (scene) mới sau khi hoàn thành
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            PausedMenu pausedMenu = FindObjectOfType<PausedMenu>();
            pausedMenu.ThanksForPlay();
        }

    }
    private void UpdateUIText()
    {
        // Hiển thị giá trị enemiesToDestroy và destroyedEnemies lên Text UI elements
        enemiesToDestroyText.text = enemiesToDestroy.ToString();
        destroyedEnemiesText.text = destroyedEnemies.ToString();
    }
}
