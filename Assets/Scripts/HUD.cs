using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	public Text distanceLabel, velocityLabel,speed_up;

	public void SetValues (float distanceTraveled, float velocity) {
		distanceLabel.text = ((int)(distanceTraveled * 10f)).ToString();
		velocityLabel.text = ((int)(velocity * 10f)).ToString();
	}
    public void Speed_Up_Text()
    {
        StartCoroutine(Speed_up());
    }

    private IEnumerator Speed_up()
    {
        speed_up.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        speed_up.gameObject.SetActive(false);
    }
}