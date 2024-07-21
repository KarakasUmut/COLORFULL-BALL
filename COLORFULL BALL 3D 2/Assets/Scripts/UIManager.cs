using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Video;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public SoundManager Sounds;

    public Image whiteeffectimage;
    private int effectcontrol = 0;
    private bool radialshine;

    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinisLine;

    public Animator LayoutAnimator;

    public Text coin_text;
    // Butonlar
    public GameObject settings_open;
    public GameObject settings_close;
    public GameObject layout_background;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject Vibration_On;
    public GameObject Vibration_Off;
    public GameObject iap;
    public GameObject information;

    public GameObject intro_Hand;
    public GameObject taptomove_Text;
    public GameObject noAds;
    public GameObject shop_Button;

    public GameObject RestartScreen;
    // oyun sonu ekraný
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject nextLevel;
    
   


    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false) 
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false) 
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        CoinTextUpdate();
    }

    public void Update()
    {
        if (radialshine== true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0,0,15f*Time.deltaTime));
        }

        FillRateImage.fillAmount = ((Player.transform.position.z*100) / (FinisLine.transform.position.z))/100;

    }





    public void FirsTtocuh()
    {
        intro_Hand.SetActive(false);
        taptomove_Text.SetActive(false);
        noAds.SetActive(false);
        shop_Button.SetActive(false);
        settings_open.SetActive(false);
        settings_close.SetActive(false);
        sound_on.SetActive(false);
        sound_off.SetActive(false);
        Vibration_On.SetActive(false);
        Vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
        layout_background.SetActive(false);
    }
    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }


    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }
   
    public void RestartScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnPreCull()
    {
        Application.OpenURL("https://www.youtube.com");

    }
    public void TermOfUse()
    {
        Application.OpenURL("https://www.youtube.com");
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        
        radialshine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.6f);
        Sounds.CompleteSound();
        complete.SetActive(true);
        yield return new WaitForSecondsRealtime(0.6f);
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        Sounds.CompleteSound();
        nextLevel.SetActive(true);  
       

    }

  






    //Buton fonksiyonlarý
    public void Settings_open()
    {
        settings_open.SetActive(false);
        settings_close.SetActive(true);
        LayoutAnimator.SetTrigger("slide_Ýn");
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_on.SetActive(true);
            sound_off.SetActive(false);
            AudioListener.volume = 1;

        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            Vibration_Off.SetActive(true);
            Vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2) 
        {
            Vibration_Off.SetActive(false);
            Vibration_Off.SetActive(true);
        }

    }





    public void Settings_close()
    {
        settings_open.SetActive(true);
        settings_close.SetActive(false);
        LayoutAnimator.SetTrigger("slide_out");
    }


    public void Sound_on()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void Sound_off()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }


    public void vibration_On()
    {
        Vibration_On.SetActive(false);
        Vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    
    public void Vibraiton_Off()
    {
        Vibration_Off.SetActive(true);
        Vibration_Off.SetActive(false); 
        PlayerPrefs.SetInt("Vibration", 1);
    }


























    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b,1))
            {
                effectcontrol = 1;
            }

        }

        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b,0)) 
            {
                effectcontrol= 2;
            }
        }
        if (effectcontrol == 2)
        {
            Debug.Log("efekt bitti");
        }
    }
}
