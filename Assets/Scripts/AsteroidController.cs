using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private int life = 4;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.material.SetColor("_BaseColor", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1));
        meshRenderer.material.SetColor("_BaseColor", Colors.GetColor(4));
        //Debug.Log(meshRenderer.material.GetColor("_BaseColor"));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.5f * Vector3.up, Space.Self);
    }
    public void TakeLifePoint()
    {
        if (life > 1)
        {
            meshRenderer.material.SetColor("_BaseColor", Colors.GetColor(--life));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
