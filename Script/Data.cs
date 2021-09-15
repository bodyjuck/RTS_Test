using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterStatus 
{
    public string whatCharacter;
    public int HP;
    public int ATK;
    public float AttackDelay;
    public bool useSkill;
    public Slider slider;
    public Animator animCharacter;
}

[System.Serializable]
public class POSCharacter
{
    public GameObject[] Pos;
}

[System.Serializable]
public class CharacterModel
{
    public GameObject[] model;
}

[System.Serializable]
public class PrefabCharacterModel
{
    public GameObject[] model;
}

[System.Serializable]
public class Reset
{
    public Vector3 resetTranform;
    public Quaternion resetRotate;
}

public class DataCharacterSet
{
    static public int numberPlayerCharacter;
    static public string[] playerCharacter;

    static public int numberEnemyCharacter;
    static public string[] enemyCharacter;
}

public class DataCharacterWarrior
{
    static public int HP = 20;
    static public int ATK = 1;
    static public float AttackDelay = 2.5f;
}
public class DataCharacterArcher
{
    static public int HP = 20;
    static public int ATK = 1;
    static public float AttackDelay = 1.5f;
}
public class DataCharacterMonster
{
    static public int HP = 10;
    static public int ATK = 1;
    static public float AttackDelay = 2.5f;
}
