using UnityEngine;
using UnityEngine.UI;


public class DrawPanel : MonoBehaviour {

	public  float drawDistance;
	public  float drawSpeed;

	private Vector2 basePosition;

	private RectTransform rectTransform;


	void Awake()
	{
		NameIntPair.ShufflePair (GameData.PavementType,5);

	}
	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		basePosition = rectTransform.anchoredPosition;
	}



	void DrawDown(float distance)
	{
		rectTransform.anchoredPosition = new Vector2(basePosition.x, DragDrawerBy(Input.GetAxis ("Mouse Y")*(-drawSpeed),drawDistance));
	}

	float DragDrawerBy(float by,float maxDraw)
	{
		return Mathf.Clamp(by+rectTransform.anchoredPosition.y, basePosition.y+drawDistance, basePosition.y);
	}
	public void DrawDrawer()
	{
		DrawDown (drawDistance);
	}



}
