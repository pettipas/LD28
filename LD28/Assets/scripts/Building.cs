using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

    public float health;
    public GameObject destroyedBuilding;
    public bool destroyed;
    public List<Transform> spawns = new List<Transform>();
    public GameObject person;

    public IEnumerator Death() {
        List<Vector3> points = GetListOfPoints();

        int num = Random.Range(1, 3);

        for (int i = 0; i < points.Count; i++) {
            GameObject g = Instantiate(person, points[i], Quaternion.identity) as GameObject;
            g.name = person.name;
            yield return new WaitForSeconds(0.2f);
        }
    }


    public List<Vector3> GetListOfPoints() {
        List<Vector3> list = new List<Vector3>();
        spawns.ForEach(p => list.Add(p.position));
        return list;
    }
	void Update () {
        if (!destroyed && health <= 0) {
            destroyed = true;
            GetComponentInChildren<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Instantiate(destroyedBuilding,transform.position,Quaternion.identity);
            StartCoroutine(Death());
        }
	}
}
