using UnityEngine;
using UnityEngine.UI;


public class FlipPage : MonoBehaviour {

	public  float drawAngle;
	public  float drawSpeed;

	private Quaternion baseRotation;

	private RectTransform rectTransform;

	
	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		baseRotation = rectTransform.rotation;
	}



	void DrawDown(float distance)
	{
		rectTransform.rotation = Quaternion.Euler(baseRotation.eulerAngles.x, DragDrawerBy(Input.GetAxis("Mouse X")*drawSpeed),baseRotation.eulerAngles.z);
	}

	float DragDrawerBy(float by)
	{
		return (by+rectTransform.rotation.eulerAngles.y);
	}
	public void DrawDrawer()
	{
		DrawDown (drawAngle);
	}



}
