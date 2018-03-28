using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 600;

    public static int lives;
    public int startLives = 20;

    public static int rounds;

    void Start()
    {
        Money = startMoney;
        lives = startLives;

        rounds = 0;
    }
    
}
