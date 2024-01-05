using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public TextMeshProUGUI playerHpText;

    public static bool isGameOver;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {   
        playerHpText.text = "+" + playerHP;
        if (isGameOver)
        {
            // game over screen or sumn
        }
    }

    public static void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0) 
        { 
            isGameOver = true;
        }
    }
}
