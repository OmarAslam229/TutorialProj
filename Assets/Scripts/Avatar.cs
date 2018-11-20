using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Avatar : MonoBehaviour {

	public ParticleSystem shape, trail, burst;

	private Player player;

	float deathCountdown = 3f;

    public Animator Cam;

    bool about_to_die = false;

    public Image Health;
 
	private void Awake () {
		player = transform.root.GetComponent<Player>();
	}

	private void OnTriggerEnter (Collider collider) {

        

        if (deathCountdown >= 1f)
            {
            collider.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.63f);
            deathCountdown--;
            StartCoroutine(AnimatorSetFire());
        }
        print(deathCountdown);
        Health.fillAmount = deathCountdown / 3;

        if (deathCountdown <=0f) {

            collider.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.63f);

            about_to_die = true;
			shape.enableEmission = false;
			trail.enableEmission = false;
			burst.Emit(burst.maxParticles);
			deathCountdown = burst.startLifetime;

            StartCoroutine(AnimatorSetFire());

            
		}

       
    }

    private IEnumerator AnimatorSetFire()
    {
        Cam.SetBool("Apply_Jerk", true);
       yield return new WaitForSeconds(0.55f);
        Cam.SetBool("Apply_Jerk", false);
    }

    private void Update () {
		if (deathCountdown >= 0f && about_to_die) {
            

            deathCountdown -= Time.deltaTime;
			if (deathCountdown <= 0f) {
				deathCountdown = -1f;
				shape.enableEmission = true;
				trail.enableEmission = true;
				player.Die();
			}
		}
        
    }
}