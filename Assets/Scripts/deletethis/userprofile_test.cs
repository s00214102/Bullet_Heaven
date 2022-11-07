using System.Collections;
using System.Collections.Generic;
using System;

[Serializable] //old C# thing, this marks to be saveable, and can be dispalyed in unity inspector
public class userprofile_test
{
    public string m_username;
    public float m_health;
    public float m_energy;
    public int m_lives;

    public userprofile_test(string username, float health, float energy, int lives)
    {
        username = m_username;
        health = m_health;
        energy = m_energy;
        lives = m_lives;
    }
}
