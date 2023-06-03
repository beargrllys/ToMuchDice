using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turn;

    public Ally m_ally;
    public Enemy m_enemy;
    public DiceDeque m_dice;
    public CardDeque m_card;
    private void Start()
    {
        m_ally = GameObject.FindGameObjectWithTag("ALLY").GetComponent<Ally>();
        m_enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
        m_card = GameObject.FindGameObjectWithTag("CARD").GetComponent<CardDeque>();
    }


}
