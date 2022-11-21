using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private int life = 4;
    private int fullLife = 4;
    MeshRenderer meshRenderer;
    float timeToLive = 0f;

    void Start()
    {
        timeToLive = Utils.GetRandomTimeToLive();
    }
    
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public bool TakeLifePoint()
    {
        if (life > 1)
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material.SetColor("_BaseColor", Colors.GetColor(--life));
            return false;
        }
        else
        {
            life--;
            return true;
        }
    }

    public void InitAsteroid()
    {
        gameObject.SetActive(true);
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_BaseColor", Colors.GetColor(0));
        timeToLive = Utils.GetRandomTimeToLive();
    }
    public void RespawnAsteroid()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        gameObject.SetActive(true);
        transform.position = Utils.GetRandomPosition();
        transform.rotation = Utils.GetRandomRotation();
        timeToLive = Utils.GetRandomTimeToLive();

        if(life == 0)
        {
            meshRenderer.material.SetColor("_BaseColor", Colors.GetColor(0));
            life = fullLife;
        }
    }
}
