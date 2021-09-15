using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayControll : MonoBehaviour
{
    public ObjectClicker objectClick;
    public GameSetControll gamesetcontroll;
    public Player player;
    public Enemy enemy;

    public Animator animText;
    public Text text1;
    public Text text2;

    public int PlayerLeft;
    public int EnemyLeft;

    public int enemySeleceTarget;

    public string end;

    void Start()
    {
        objectClick = GetComponent<ObjectClicker>();
        gamesetcontroll = GetComponent<GameSetControll>();
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();

        animText = GameObject.Find("/Canvas/Animation Move").GetComponent<Animator>();
        text1 = GameObject.Find("/Canvas/Animation Move/Text1Move/Text1").GetComponent<Text>();
        text2 = GameObject.Find("/Canvas/Animation Move/Text2Move/Text2").GetComponent<Text>();
    }

    public void gameStart()
    {
        StartCoroutine(DelayBeforStart());
    }

    public IEnumerator DelayBeforStart()
    {
        yield return new WaitForSeconds(0.5f);
        text1.text = "MISSION";
        text2.text = "START";
        animText.SetTrigger("Play");
        yield return new WaitForSeconds(1.0f);
        callStartFuntion();
    }

    public void callStartFuntion()
    {
        for (int i = 0; i < DataCharacterSet.numberPlayerCharacter; i++)
        {
            StartCoroutine(PlayerLoopToDoSomething(player.character[i].AttackDelay,i));
        }

        for (int i = 0; i < DataCharacterSet.numberEnemyCharacter; i++)
        {
            StartCoroutine(EnemyLoopToDoSomething(enemy.character[i].AttackDelay, i));
        }
    }

    public IEnumerator PlayerLoopToDoSomething(float AttackDelay,int whatCharacter)
    {

        do
        {
            yield return new WaitForSeconds(AttackDelay);

            if (player.character[whatCharacter].HP > 0)
            {
                ReAim("player");

                playAnimation("player", "Live", whatCharacter);

                enemy.character[objectClick.whatSelece].HP -= player.character[whatCharacter].ATK;
                enemy.character[objectClick.whatSelece].slider.value -= player.character[whatCharacter].ATK;
                checkTargetDead("player", whatCharacter);
            }
        }
        while (player.character[whatCharacter].HP > 0 && player.character[whatCharacter].useSkill == false && EnemyLeft != 0);

    }
    public IEnumerator EnemyLoopToDoSomething(float AttackDelay, int whatCharacter)
    {


        do
        {
            yield return new WaitForSeconds(AttackDelay);


            if (enemy.character[whatCharacter].HP > 0)
            {
                ReAim("enemy");

                playAnimation("enemy", "Live", whatCharacter);

                player.character[enemySeleceTarget].HP -= enemy.character[whatCharacter].ATK;
                player.character[enemySeleceTarget].slider.value -= enemy.character[whatCharacter].ATK;
                checkTargetDead("enemy", enemySeleceTarget);
            }

            
            
        }
        while (enemy.character[whatCharacter].HP > 0 && enemy.character[whatCharacter].useSkill == false && PlayerLeft != 0);

        if (enemy.character[whatCharacter].HP <= 0)
        {
            playAnimation("enemy", "Dead", whatCharacter);
        }
    }

    public void playAnimation(string whatCall,string whatStatus,int whatCharacter)
    {
        if (whatCall == "player")
        {
            if (whatStatus == "Live")
            {
                if (player.character[whatCharacter].whatCharacter == "Warrior")
                {
                    player.character[whatCharacter].animCharacter.SetTrigger("Slash");
                }
                else if (player.character[whatCharacter].whatCharacter == "Archer")
                {
                    player.character[whatCharacter].animCharacter.SetTrigger("Shoot");
                }
            }
            else if (whatStatus == "Dead")
            {
                player.character[whatCharacter].animCharacter.SetTrigger("Death");
            }
        }
        else if(whatCall == "enemy")
        {
            if (whatStatus == "Live")
            {
                if (enemy.character[whatCharacter].whatCharacter == "Monster")
                {
                    enemy.character[whatCharacter].animCharacter.SetTrigger("Fire Ball");
                }
            }
            else if (whatStatus == "Dead")
            {
                enemy.character[whatCharacter].animCharacter.SetTrigger("Death");
            }
        }
    }

    public void ReAim(string whatCall)
    {

        if (whatCall == "player")
        {
            while (enemy.character[objectClick.whatSelece].HP <= 0 && EnemyLeft != 0)
            {
                if (objectClick.whatSelece == 0)
                {
                    objectClick.whatSelece = 1;
                    objectClick.seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[1].transform.position;
                }
                else if (objectClick.whatSelece == 1)
                {
                    objectClick.whatSelece = 2;
                    objectClick.seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[2].transform.position;
                }
                else if (objectClick.whatSelece == 2)
                {
                    objectClick.whatSelece = 0;
                    objectClick.seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[0].transform.position;
                }


            }
        }
        else if (whatCall == "enemy")
        {
            while (player.character[enemySeleceTarget].HP <= 0 && PlayerLeft != 0)
            {
                if (enemySeleceTarget == 1)
                {
                    enemySeleceTarget = 0;
                }

                enemySeleceTarget++;
            }
        }
        
    }

    public void checkTargetDead(string whatCall,int whatCharacter)
    {
        if (whatCall == "player")
        {
            if (enemy.character[objectClick.whatSelece].HP == 0)
            {
                EnemyLeft--;
                playAnimation("enemy", "Dead", whatCharacter);
            }

            if (EnemyLeft <= 0 && end == "")
            {
                end = "Player Win";
                StartCoroutine(DelayBeforEnd());
            }
        }
        else if (whatCall == "enemy")
        {
            if (player.character[enemySeleceTarget].HP == 0)
            {
                PlayerLeft--;
                playAnimation("player", "Dead", whatCharacter);
            }

            if (PlayerLeft <= 0 && end == "")
            {
                end = "Enemy Win";
                StartCoroutine(DelayBeforEnd());
            }
        }
    }

    public IEnumerator DelayBeforEnd()
    {
        if (end == "Player Win")
        {
            text2.text = "COMPLET";
        }
        else if (end == "Enemy Win")
        {
            text2.text = "Fail";
        }
        yield return new WaitForSeconds(0.5f);
        animText.SetTrigger("Play");
        yield return new WaitForSeconds(1.0f);
    }

    
}
