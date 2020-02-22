using System;

[System.Serializable]
public class PlayerData  
{
    public int gold;
    public int diamond;

    public PlayerData()
    {
        gold = 500;
        diamond = 50;
    }

    public void ChangeGold(int amount)//can be negative number
    {     
        gold += amount;     
    }

    public void ChangeDiamond(int amount)
    {
        System.Console.WriteLine(amount);
        diamond += amount;
    }
}
