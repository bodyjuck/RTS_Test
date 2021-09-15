using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetControll : MonoBehaviour
{
    public POSCharacter posPlayer;
    public POSCharacter posEnemy;

    public PrefabCharacterModel prefabCharacterModel;
    public CharacterModel playerCharacterModel;
    public CharacterModel enemyCharacterModel;

    public Reset reset;

    public GamePlayControll gameplaycontroll;
    public Player player;
    public Enemy enemy;

    void Start()
    {
        // Simulation get data form previous
        DataCharacterSet.numberPlayerCharacter = 2;
        DataCharacterSet.playerCharacter = new string[DataCharacterSet.numberPlayerCharacter];
        DataCharacterSet.playerCharacter[0] = "Warrior";
        DataCharacterSet.playerCharacter[1] = "Archer";

        DataCharacterSet.numberEnemyCharacter = 3;
        DataCharacterSet.enemyCharacter = new string[DataCharacterSet.numberEnemyCharacter];
        DataCharacterSet.enemyCharacter[0] = "Monster";
        DataCharacterSet.enemyCharacter[1] = "Monster";
        DataCharacterSet.enemyCharacter[2] = "Monster";
        // Simulation get data form previous

        gameplaycontroll = GetComponent<GamePlayControll>();
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();

        posPlayer.Pos = new GameObject[DataCharacterSet.numberPlayerCharacter];
        playerCharacterModel.model = new GameObject[DataCharacterSet.numberPlayerCharacter];
        //player.character = new CharacterStatus[DataCharacterSet.numberPlayerCharacter];

        gameplaycontroll.PlayerLeft = DataCharacterSet.numberPlayerCharacter;

        for (int i = 0; i < DataCharacterSet.numberPlayerCharacter; i++)
        {
            posPlayer.Pos[i] = GameObject.Find("/Player/Player POS " + (i+1));

            modelSelece("Player",i);
            
            playerCharacterModel.model[i].transform.SetParent(posPlayer.Pos[i].transform);
            playerCharacterModel.model[i].transform.localPosition = reset.resetTranform;
            playerCharacterModel.model[i].transform.localRotation = reset.resetRotate;

            
        }

        posEnemy.Pos = new GameObject[DataCharacterSet.numberEnemyCharacter];
        enemyCharacterModel.model = new GameObject[DataCharacterSet.numberEnemyCharacter];
        //enemy.character = new CharacterStatus[DataCharacterSet.numberEnemyCharacter];

        gameplaycontroll.EnemyLeft = DataCharacterSet.numberEnemyCharacter;

        for (int i = 0; i < DataCharacterSet.numberEnemyCharacter; i++)
        {
            posEnemy.Pos[i] = GameObject.Find("/Enemy/Enemy POS " + (i + 1));

            modelSelece("Enemy", i);

            enemyCharacterModel.model[i].transform.SetParent(posEnemy.Pos[i].transform);
            enemyCharacterModel.model[i].transform.localPosition = reset.resetTranform;
            enemyCharacterModel.model[i].transform.localRotation = reset.resetRotate;
        }

        gameplaycontroll.gameStart();
    }

    void modelSelece(string whatCall,int i)
    {
        if (whatCall == "Player")
        {
            if (DataCharacterSet.playerCharacter[i] == "Warrior")
            {
                playerCharacterModel.model[i] = (GameObject)Instantiate(prefabCharacterModel.model[0]);

                player.character[i].whatCharacter = "Warrior";
                player.character[i].HP = DataCharacterWarrior.HP;
                player.character[i].ATK = DataCharacterWarrior.ATK;
                player.character[i].AttackDelay = DataCharacterWarrior.AttackDelay;
                player.character[i].slider = GameObject.Find("/Canvas/Player HP " + (i + 1)).GetComponent<Slider>();
                player.character[i].animCharacter = playerCharacterModel.model[i].GetComponent<Animator>();
            }
            else if (DataCharacterSet.playerCharacter[i] == "Archer")
            {
                playerCharacterModel.model[i] = (GameObject)Instantiate(prefabCharacterModel.model[1]);

                player.character[i].whatCharacter = "Archer";
                player.character[i].HP = DataCharacterArcher.HP;
                player.character[i].ATK = DataCharacterArcher.ATK;
                player.character[i].AttackDelay = DataCharacterArcher.AttackDelay;
                player.character[i].slider = GameObject.Find("/Canvas/Player HP " + (i + 1)).GetComponent<Slider>();
                player.character[i].animCharacter = playerCharacterModel.model[i].GetComponent<Animator>();
            }
        }
        else if (whatCall == "Enemy")
        {
            
            if (DataCharacterSet.enemyCharacter[i] == "Monster")
            {
                enemyCharacterModel.model[i] = (GameObject)Instantiate(prefabCharacterModel.model[2]);

                enemy.character[i].whatCharacter = "Monster";
                enemy.character[i].HP = DataCharacterMonster.HP;
                enemy.character[i].ATK = DataCharacterMonster.ATK;
                enemy.character[i].AttackDelay = DataCharacterMonster.AttackDelay;
                enemy.character[i].slider = GameObject.Find("/Canvas/Enemy HP " + (i + 1)).GetComponent<Slider>();
                enemy.character[i].animCharacter = enemyCharacterModel.model[i].GetComponent<Animator>();
            }
        }
    }

}
