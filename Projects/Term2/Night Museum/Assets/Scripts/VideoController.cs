using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoController : MonoBehaviour {

	public VideoPlayer video;
	public Sprite buttonPlay;
	public Sprite buttonPause;
	public Button myButton;

	void Start(){
		//myButton = GetComponent<Button>();
	}

	public bool IsPlaying{
		get { return video.isPlaying;}
	}

	public bool IsLooping{
		get { return video.isLooping; }
	}

	public bool IsPrepared{
		get { return video.isPrepared; }
	}
		
	public void PlayVideo(){
		if (video.isPlaying) {
			video.Pause ();
			myButton.image.overrideSprite = buttonPlay;
		}
		else {
			video.Play ();
			myButton.image.overrideSprite = buttonPause;
		}
	}
}
