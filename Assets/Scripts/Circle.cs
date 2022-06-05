using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float _maxSize;
    [SerializeField] private float _lifeTime;

    private SpriteRenderer spRenderer;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;

        spRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < _maxSize && transform.localScale.y < _maxSize)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
        else
        {
            _lifeTime -= Time.deltaTime;
            Color newColor = new Color(1f, 0f, 0.9f, Mathf.Lerp(0, 1, _lifeTime));
            spRenderer.color = newColor;
        }

        if (_lifeTime <= 0)
        {
            Deadge();
        }
    }

    private void OnMouseDown()
    {
        if (!gameManager.IsGameOver() && !gameManager.IsPause() && !gameManager.IsWinGame() && gameManager.IsStart())
        {
            Destroy(gameObject);

            // TODO: increase score
            Score._score += Mathf.RoundToInt(_lifeTime * (1 + (_maxSize - transform.localScale.x)));
        }
    }

    private void Deadge()
    {
        Destroy(gameObject);
        gameManager.GameOver();
    }
}
