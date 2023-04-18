using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class GameMasterTutorial : MonoBehaviour
{
    public GameObject player, UI, enemyNormal, enemyTough, enemyNimble, scoreDetector, critRight, senseiStick, AKey, DKey, EKey, SpaceKey;
    public List<string> dialouge;
    public int state;
    public Animator animator;

    private SpriteRenderer aSprite, dSprite, eSprite, spaceSprite;
    private GameObject nuEnemy, exampleEnemy;
    private TutorialUICntrl uiCntrl;
    private Image scoreArrow, heartArrow, comboArrow, indicArrow;
    private ScoreCollector scoreCollector;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        state = -1;
        TextToArray();
        uiCntrl = GetComponent<TutorialUICntrl>();

        aSprite        = AKey.GetComponent<SpriteRenderer>();
        dSprite        = DKey.GetComponent<SpriteRenderer>();
        eSprite        = EKey.GetComponent<SpriteRenderer>();
        spaceSprite    = SpaceKey.GetComponent<SpriteRenderer>();
        animator       = senseiStick.GetComponent<Animator>();
        playerHealth   = player.GetComponent<PlayerHealth>();
        scoreCollector = scoreDetector.GetComponent<ScoreCollector>();
        heartArrow     = UI.transform.GetChild(6).gameObject.GetComponent<Image>();
        comboArrow     = UI.transform.GetChild(7).gameObject.GetComponent<Image>();
        scoreArrow     = UI.transform.GetChild(8).gameObject.GetComponent<Image>();
        indicArrow     = UI.transform.GetChild(9).gameObject.GetComponent<Image>();

        aSprite.enabled = false;
        dSprite.enabled = false;
        eSprite.enabled = false;
        spaceSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Select"))
        {
            switch (state)
            {
                case 0:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 1:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 2:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 3:
                    state++;
                    heartArrow.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 4:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 5:
                    state++;
                    heartArrow.enabled = false;
                    scoreArrow.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 6:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 7:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 8:
                    state++;
                    scoreArrow.enabled = false;
                    comboArrow.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 9:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 10:
                    state++;
                    comboArrow.enabled = false;
                    indicArrow.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 11:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 12:
                    state++;
                    indicArrow.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 13:
                    state++;
                    eSprite.enabled = false;
                    aSprite.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    //Spawn in an enemy on the left
                    nuEnemy = Instantiate(enemyNormal, new Vector3(-18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<Haz>().speed = 1000;
                    nuEnemy.GetComponent<Haz>().limit = 2;
                    break;
                case 14:
                    //Only progress past this state when the enemy has been hit and killed
                    break;
                case 15:
                    state++;
                    scoreCollector.score = 0;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 16:
                    state++;
                    eSprite.enabled = false;
                    dSprite.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    //Spawn in an enemy on the right
                    nuEnemy = Instantiate(enemyNormal, new Vector3(18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<Haz>().speed = -1000;
                    nuEnemy.GetComponent<Haz>().limit = 2;
                    break;
                case 17:
                    //Only progress past this state when the enemy has been hit and killed
                    break;
                case 18:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 19:
                    state++;
                    eSprite.enabled = false;
                    aSprite.enabled = true;
                    scoreCollector.score = 0;
                    uiCntrl.setDialouge(dialouge[state]);
                    //Spawn in an enemy on the left that doesn't move in perfect range
                    nuEnemy = Instantiate(enemyNormal, new Vector3(-3.41f, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<Haz>().speed = 1000;
                    nuEnemy.GetComponent<Haz>().limit = 0;
                    break;
                case 20:
                    //only progress past this state when the enemy has been hit and killed
                    break;
                case 21:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 22:
                    state++;
                    player.GetComponent<PlayerStrike>().combo = 10;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 23:
                    state++;
                    spaceSprite.enabled = true;
                    eSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    //Spawn in six enemies around the player
                    spawnSix();
                    break;
                case 24:
                    //Dont progress PAST this state until the player hits space
                    break;
                case 25:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 26:
                    state++;
                    exampleEnemy = Instantiate(enemyNormal, new Vector3(5.5f, -1.5f, 0), Quaternion.identity);
                    exampleEnemy.GetComponent<Haz>().speed = -1000;
                    scoreCollector.score = 0;
                    player.GetComponent<PlayerStrike>().combo = 0;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 27:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 28:
                    state++;
                    eSprite.enabled = false;
                    dSprite.enabled = true;
                    exampleEnemy.GetComponent<Haz>().limit = 1;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 29:
                    //Don't progress past this point untill the player has killed the enemy
                    break;
                case 30:
                    state++;
                    scoreCollector.score = 0;
                    player.GetComponent<PlayerStrike>().combo = 0;
                    exampleEnemy = Instantiate(enemyTough, new Vector3(5.5f, -1.5f, 0), Quaternion.identity);
                    exampleEnemy.GetComponent<HazTough>().speed = -1000;
                    exampleEnemy.GetComponent<HazTough>().travelingLeft = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 31:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 32:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 33:
                    state++;
                    eSprite.enabled = false;
                    dSprite.enabled = true;
                    exampleEnemy.GetComponent<HazTough>().limit = 1;
                    critRight.GetComponent<BoxCollider2D>().enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 34:
                    //Don't progress past this point until the players has killed the enemy
                    break;
                case 35:
                    state++;
                    scoreCollector.score = 0;
                    player.GetComponent<PlayerStrike>().combo = 0;
                    exampleEnemy = Instantiate(enemyNimble, new Vector3(5.5f, -1.5f, 0), Quaternion.identity);
                    exampleEnemy.GetComponent<HazTest>().speed = -1000;
                    exampleEnemy.GetComponent<HazTest>().travelingLeft = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 36:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 37:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 38:
                    state++;
                    eSprite.enabled = false;
                    dSprite.enabled = true;
                    exampleEnemy.GetComponent<HazTest>().limit = 1;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 39:
                    //Don't progress until the player has defeated the enemy
                    break;
                case 40:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 41:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 42:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 43:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 44:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 45:
                    state++;
                    uiCntrl.setDialouge(dialouge[state]);
                    break;
                case 46:
                    SceneManagerSF.instance.LoadScene(SceneManagerSF.Scene.LevelSelect);
                    break;
                default:
                    break;
            }
        }

        switch (state)
        {
            case 0:
                eSprite.enabled = true;
                break;
            case 14:
                if (scoreCollector.score > 0)
                {
                    state++;
                    eSprite.enabled = true;
                    aSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                if (playerHealth.health < 3)
                {
                    playerHealth.health = 3;
                    //spawn in another enemy
                    nuEnemy = Instantiate(enemyNormal, new Vector3(-18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<Haz>().speed = 1000;
                    nuEnemy.GetComponent<Haz>().limit = 2;
                }
                break;
            case 17:
                if (scoreCollector.score > 0)
                {
                    state++;
                    eSprite.enabled = true;
                    dSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                if (playerHealth.health < 3)
                {
                    playerHealth.health = 3;
                    //spawn in another enemy
                    nuEnemy = Instantiate(enemyNormal, new Vector3(18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<Haz>().speed = -1000;
                    nuEnemy.GetComponent<Haz>().limit = 2;
                }
                break;
            case 20:
                if (scoreCollector.score > 0)
                {
                    state++;
                    eSprite.enabled = true;
                    aSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                break;
            case 24:
                player.GetComponent<PlayerStrike>().combo = 10;
                if (Input.GetButtonDown("Jump"))
                {
                    state++;
                    spaceSprite.enabled = false;
                    eSprite.enabled = true;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                break;
            case 29:
                if(scoreCollector.score > 0)
                {
                    state++;
                    eSprite.enabled = true;
                    dSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                if (playerHealth.health < 3)
                {
                    playerHealth.health = 3;
                    //spawn in another enemy
                    nuEnemy = Instantiate(enemyNormal, new Vector3(18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<Haz>().speed = -1000;
                    nuEnemy.GetComponent<Haz>().limit = 2;
                }
                break;
            case 34:
                if (scoreCollector.score > 0)
                {
                    state++;
                    eSprite.enabled = true;
                    dSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                if (playerHealth.health < 3)
                {
                    playerHealth.health = 3;
                    //spawn in another enemy
                    nuEnemy = Instantiate(enemyNormal, new Vector3(18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<HazTough>().speed = -1000;
                    nuEnemy.GetComponent<HazTough>().travelingLeft = true;
                    nuEnemy.GetComponent<HazTough>().limit = 2;
                }
                break;
            case 39:
                if (scoreCollector.score > 0)
                {
                    state++;
                    eSprite.enabled = true;
                    dSprite.enabled = false;
                    uiCntrl.setDialouge(dialouge[state]);
                    animator.SetBool("Suprise", true);
                }
                if (playerHealth.health < 3)
                {
                    playerHealth.health = 3;
                    //spawn in another enemy
                    nuEnemy = Instantiate(enemyNormal, new Vector3(18, -1.5f, 0), Quaternion.identity);
                    nuEnemy.GetComponent<HazTest>().speed = -1000;
                    nuEnemy.GetComponent<HazTest>().travelingLeft = true;
                    nuEnemy.GetComponent<HazTest>().limit = 2;
                }
                break;
            default:
                break;
        }
    }

    void TextToArray()
    {
        string strIn;
        string path = "Assets/Resources/TutorialDialouge.txt";

        //Read the text from directly from the Beats.txt file
        StreamReader reader = File.OpenText(path);

        while ((strIn = reader.ReadLine()) != null)
        {
            dialouge.Add(strIn);
        }

        reader.Close();
    }

    public void setDiaOption(int i)
    {
        uiCntrl.setDialouge(dialouge[i]);
    }

    private void spawnSix()
    {
        nuEnemy = Instantiate(enemyNormal, new Vector3(-4, -1.5f, 0), Quaternion.identity);
        nuEnemy.GetComponent<Haz>().speed = 1000;
        nuEnemy.GetComponent<Haz>().limit = 0;

        nuEnemy = Instantiate(enemyNormal, new Vector3(-6, -1.5f, 0), Quaternion.identity);
        nuEnemy.GetComponent<Haz>().speed = 1000;
        nuEnemy.GetComponent<Haz>().limit = 0;

        nuEnemy = Instantiate(enemyNormal, new Vector3(-8, -1.5f, 0), Quaternion.identity);
        nuEnemy.GetComponent<Haz>().speed = 1000;
        nuEnemy.GetComponent<Haz>().limit = 0;

        nuEnemy = Instantiate(enemyNormal, new Vector3(4, -1.5f, 0), Quaternion.identity);
        nuEnemy.GetComponent<Haz>().speed = -1000;
        nuEnemy.GetComponent<Haz>().limit = 0;

        nuEnemy = Instantiate(enemyNormal, new Vector3(6, -1.5f, 0), Quaternion.identity);
        nuEnemy.GetComponent<Haz>().speed = -1000;
        nuEnemy.GetComponent<Haz>().limit = 0;

        nuEnemy = Instantiate(enemyNormal, new Vector3(8, -1.5f, 0), Quaternion.identity);
        nuEnemy.GetComponent<Haz>().speed = -1000;
        nuEnemy.GetComponent<Haz>().limit = 0;
    }
}
