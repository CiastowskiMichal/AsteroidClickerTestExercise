using UnityEngine;

public static class RandomTransforms
{
    public static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-8, 9), Random.Range(-4, 5), Random.Range(-2, 2));
    }
    public static Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }
}
