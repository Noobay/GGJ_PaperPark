using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawPanel : MonoBehaviour {

	public  float drawDistance;
	public  float drawSpeed;

	private Vector2 basePosition;

	private RectTransform rectTransform;


	void Start()
	{
		//DrawOut
		rectTransform = GetComponent<RectTransform>();
		basePosition = rectTransform.anchoredPosition;
	}



	void DrawOut(float distance)
	{
		rectTransform.anchoredPosition = new Vector2(DragDrawerBy(Input.GetAxis ("Mouse X")*drawSpeed, drawDistance),basePosition.y);
	}

	float DragDrawerBy(float by,float maxDraw)
	{
		return Mathf.Clamp(by+rectTransform.anchoredPosition.x, basePosition.x, basePosition.x+maxDraw);
	}
	public void DrawDrawer()
	{
		DrawOut (drawDistance);
	}



}
