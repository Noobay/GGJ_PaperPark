using UnityEngine;
using UnityEngine.UI;


public class FlipPage : MonoBehaviour {

	public  float drawSpeed;

	private Quaternion baseRotation;

	private RectTransform rectTransform;

	
	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		baseRotation = rectTransform.rotation;
	}



	public void Draw()
	{
		rectTransform.rotation = Quaternion.Euler(baseRotation.eulerAngles.x, DragDrawerBy(Input.GetAxis("Mouse X")*drawSpeed),baseRotation.eulerAngles.z);
	}

	float DragDrawerBy(float by)
	{
		float angle = 0f;
		float dragAmount = by+rectTransform.eulerAngles.y;

		angle = Mathf.Clamp (dragAmount,0f,180f);

		return angle;
	}




}
