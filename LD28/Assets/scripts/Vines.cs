using UnityEngine;
using System.Collections;

public class Vines : MonoBehaviour {

    public Transform finalPos;
	public AudioSource rumble;
	
    public void OnEnable() {
		rumble = GetComponent<AudioSource>();
        StartCoroutine(Move(new Vector3(transform.localPosition.x, Random.Range(-4.0f, -1.0f), transform.localPosition.z), 10));
    }

    public IEnumerator Move(Vector3 newPlace, float time) {
		if(!rumble.isPlaying){
			rumble.Play();
		}
        float d = 0.0f;
        float dx = 1.0f / time;
        Vector3 start = transform.localPosition;
        while (Vector3.Distance(transform.localPosition, newPlace) > 0.5f) {
            d += Time.deltaTime * dx;
            transform.localPosition = Vector3.Lerp(start, newPlace, d);
            yield return null;
        }
		rumble.Stop();
        transform.localPosition = newPlace;
        yield break;
    }
}
