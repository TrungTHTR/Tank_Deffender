using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    private GameObject audioManager;
    private AudioManager _audioManager;
   
    public Slider _volumeslider;
    public void Awake()
    {
        audioManager = GameObject.FindWithTag("GameSound");
        _audioManager = audioManager.GetComponent<AudioManager>();
    }

    public void Start()
    {
        _audioManager.PlayMusic("MainMenu");     
    }
    public void ToggleVolume()
    {
       /* AudioManager.Instance.ToggleMusic();
        AudioManager.Instance.ToggleSFX();*/

        _audioManager.ToggleMusic();
        _audioManager.ToggleSFX();
    }




    public void SettingVolume()
    {
        
        /*AudioManager.Instance.MusicVolume(_volumeslider.value);
        AudioManager.Instance.SFXVolume(_volumeslider.value);*/

        _audioManager.MusicVolume(_volumeslider.value);
        _audioManager.SFXVolume(_volumeslider.value);
    }
    public void StartGame()
    {
        /*AudioManager.Instance.StopMusic("MainMenu");
        AudioManager.Instance.PlayMusic("GamePlay");*/
        _audioManager.StopMusic("MainMenu");
        _audioManager.PlayMusic("GamePlay");
        SceneManager.LoadScene("GameScenes");
    }
    public void Level1()
    {
        _audioManager.StopMusic("MainMenu");
        _audioManager.PlayMusic("GamePlay");
        SceneManager.LoadScene("GameScenes");
    }
    public void Level2()
    {
        _audioManager.StopMusic("MainMenu");
        _audioManager.PlayMusic("GamePlay");
        SceneManager.LoadScene("GameScene2");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
