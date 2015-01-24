using UnityEngine;
using System.Collections;

public class FadeGroup : MonoBehaviour {

	public CanvasGroup fadeCanvas;

	public float fadeSpeed,fadeTo;
	private float fadeFrom, smooth;

	private delegate void FadeDelegate();
	private FadeDelegate fadeMethods;

	void Start()
	{
   		if(fadeCanvas == null)
		{
			fadeCanvas = this.GetComponent<CanvasGroup>();
		}
	}

	void Update()
	{
		if(Input.GetKeyDown (KeyCode.I))
		{
			smooth=0;
			BeginFade (fadeCanvas.alpha>=0.8f? 0f : 1f);
		}
		if(fadeMethods != null)
		{
			fadeMethods();
		}
	}


	public void BeginFade(float to)
	{
		fadeFrom = fadeCanvas.alpha;
		fadeTo   = to;

		fadeMethods += FadeCanvasEffect;
	}

	public void FadeCanvasEffect()
	{
		smooth += Time.deltaTime/fadeSpeed;
		if(smooth<=1f)
		{
			fadeCanvas.alpha = Mathf.Lerp (fadeFrom,fadeTo,smooth);
		}
		else
		{
			smooth = 0f;
			fadeMethods -= FadeCanvasEffect;
		}

	}

}
