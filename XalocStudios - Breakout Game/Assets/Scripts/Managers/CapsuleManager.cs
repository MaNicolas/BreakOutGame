using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleManager : MonoBehaviour
{
    #region Main Methods

    //Instantiate a capsule according to a probability (can be set in the Inspector)
    public void CreateCapsule(Vector3 brickLocation)
    {
        float randomNumber = Random.Range(0f, 100f);
        if (randomNumber <= _probability)
        {
            GameObject capsule = _capsuleList[Random.Range(0, _capsuleList.Count)];
            GameObject CapsuleToSpawn = Instantiate(capsule, brickLocation, Quaternion.identity);
        }
    }

    #endregion

    #region Methods

    private void Start()
    {
        _ball = FindObjectOfType<BallMovement>();
    }

    void Update()
    {
        if (!_ball.InPlay)
        {
            //Destroy all capsules if ball is lost
            CapsuleArray = GameObject.FindGameObjectsWithTag("Capsule");
            foreach (GameObject capsule in CapsuleArray)
            {
                Destroy(capsule);
            }
        }
    }

    #endregion

    #region Private Members

    private BallMovement _ball;
    private Bricks _bricks;
    private GameObject[] CapsuleArray;

    [SerializeField]
    private List<GameObject> _capsuleList = new List<GameObject>();

    [SerializeField]
    [Range(0f, 100f)]
    private float _probability = 20;

    #endregion
}