using UnityEngine;
public static class Colors
{
    static Color Grey = Color.gray;
    static Color Red = Color.red;
    static Color Green = Color.green;
    static Color Blue = Color.blue;

    public static Color GetColor(int value)
    {
        switch (value)
        {
            case 3:
                return Red;
            case 2:
                return Blue;
            case 1:
                return Green;
            case 0:
                return Grey;
            default:
                return Grey;

        }
    }
}
