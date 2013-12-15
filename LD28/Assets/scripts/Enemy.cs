using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour {
    public float speed;
    public MeshFilter filter;
	public EnemyLauncher launcher;
    public GameObject deathExplosion;
    public float health = 5;
    public List<Transform> expoints = new List<Transform>();
    bool deathStarted;

	void Awake(){
		launcher = GetComponentInChildren<EnemyLauncher>();
	}
	
	void Start () {
		launcher.target = Control.instance.gameObject;
	}


    public void Update() {
        if (health <= 0 && !deathStarted) {
            deathStarted = true;
            StartCoroutine(Death());
        }

        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    public IEnumerator Death() {
        List<Vector3> points = GetListOfPoints();
        for (int i = 0; i < points.Count; i++) {
            Instantiate(deathExplosion, points[i], Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(gameObject);
    }
  

    public List<Vector3> GetListOfPoints() {
        List<Vector3> list = new List<Vector3>();
        expoints.ForEach(p => list.Add(p.position));
        return list;
    }
	
}
