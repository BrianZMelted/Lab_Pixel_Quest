using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{   private Rigidbody2D _rigidbody2D;
    public Transform _respawnPoint;
    private AudioSourceController _audioSourceController;
    private UIController uIController;


    public int _playerLife = 3; // sets player life 
    private float _maxHealth = 3.0f;
    public int _playerCoin = 0;


    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSourceController = GameObject.FindAnyObjectByType<AudioSourceController>();
        uIController = GameObject.FindAnyObjectByType<UIController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)// when collide with object tagged "death" send to respawn point
    {
        string colTag = collision.tag;

        switch (colTag)
        {

            case Structs.Tags.deathTag:
                {   //take dmg
                    _rigidbody2D.velocity = Vector2.zero;
                    transform.position = _respawnPoint.position;
                    _playerLife--; //takes away life
                    uIController.HeartImageUpdate(_playerLife / _maxHealth);
                    _audioSourceController.CreateSFX(Structs.SoundEffects.death);
                    if (_playerLife <= 0)
                    {
                        string SceneName = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(SceneName);
                    }
                    return;
                }
            case Structs.Tags.healthTag:
                {
                    //gain life
                    if (_playerLife >= 3) {return; }
                    _playerLife++; //adds life
                    uIController.HeartImageUpdate(_playerLife / _maxHealth);
                    _audioSourceController.CreateSFX(Structs.SoundEffects.heart);
                    Destroy(collision.gameObject);//gets rid of it after use
                    return;
                }
            case Structs.Tags.coinTag:
                {
                    //gain coin
                    _playerCoin++; //adds coin
                    uIController.CoinTextUpdate(_playerCoin);
                    _audioSourceController.CreateSFX(Structs.SoundEffects.coin);
                    Destroy(collision.gameObject);//gets rid of it after use
                    return;
                }
            case Structs.Tags.respawnTag:
                {

                    _audioSourceController.CreateSFX(Structs.SoundEffects.checkpoint);
                    _respawnPoint = collision.gameObject.transform.Find(Structs.Tags.respawnTag).transform;  //sets spawn point at object with respawntag after touch
                    return;
                }
            case Structs.Tags.finishTag:
                {
                    string nextLevel = collision.GetComponent<EndLevel>().nextLevel;    
                    SceneManager.LoadScene(nextLevel);//when hitting object with finishtag, loads the next scene
                    
                    return;
                }
        }
    }
}
