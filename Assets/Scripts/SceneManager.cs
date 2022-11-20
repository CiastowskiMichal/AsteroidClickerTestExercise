using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    AsteroidController asteroidBase;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(asteroidBase, RandomTransforms.GetRandomPosition(), RandomTransforms.GetRandomRotation());
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickDetection();
    }
    void MouseClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Asteroid")
                {
                    hit.collider.GetComponent<AsteroidController>().TakeLifePoint();
                }
            }
        }
    }
}
