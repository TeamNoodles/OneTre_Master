using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/*UI動作時の処理を記述します*/
public class TitleUIController : MonoBehaviour {
    // Scene>TitleのCanvasを全て取得
    Canvas TitleCanvas, OptionCanvas,ExplanationCanvas;


    // TitleCanvas関連
    Button StartButton, ExplanationButton;


    // OptionCanvas関連
    // SoundManagerのキャッシュ
    private SoundManager soundManager;
    // SoundVolumeクラス これをSoundManagerのvolumeに設定する
    private SoundVolume soundVolume;
    Slider BGMSlider, SESlider;
    Button ToTitleButton;


	// Use this for initialization
	void Start () {
        // Canvas取得
        TitleCanvas = GameObject.Find("TitleCanvas").GetComponent<Canvas>();
        OptionCanvas = GameObject.Find("OptionCanvas").GetComponent<Canvas>();
        ExplanationCanvas = GameObject.Find("ExplanationCanvas").GetComponent<Canvas>();

        //Title関連の参照を取得
        StartButton = GameObject.Find("StartButton").GetComponent<Button>();
        ExplanationButton = GameObject.Find("ExplanationButton").GetComponent<Button>();

        // Option関連の参照を取得
        soundManager = SoundManager.Instance;
        soundVolume = new SoundVolume();
        BGMSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        SESlider = GameObject.Find("SESlider").GetComponent<Slider>();
	}

    public void OnButtonClicked(int type)
    {
        switch (type)
        {
            //Start
            case 0:
                GameController.Instance.ToPlay();
                soundManager.FadeBGM("Plan8");
                break;
            //option
            case 1:
                OptionCanvas.enabled = true;
                break;
            //Explanation
            case 2:
                ExplanationCanvas.enabled = true;
                break;
            //optionTotitle
            case 3:
                OptionCanvas.enabled = false; ;
                break;
            //4
            case 4:
                ExplanationCanvas.enabled = false;
                break;
            default:
                Debug.LogError("ButtonType not Attached!!");
                return;
        }
    }



    /// <summary>
    /// OptionCanvas>Sliders
    /// 
    /// SoundVolumeより音量を設定するクラス
    /// </summary>
    public void SetVolume()
    {
        this.soundVolume.BGMVolume = this.BGMSlider.value;
        this.soundVolume.SEVolume = this.SESlider.value;
        this.soundManager.volume = this.soundVolume;
        this.soundManager.OnBGMVolumeChanged();
        Debug.Log("BGM : " + this.soundVolume.BGMVolume + "\nSE : " + this.soundVolume.SEVolume);
    }


}
