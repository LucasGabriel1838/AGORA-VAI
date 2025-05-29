using UnityEngine;

public class subir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public Transform molaTransform; 
    public Transform ballTransform; 
    public Rigidbody2D ballRb; 
    public float maxPullDistance = 1f;
    public float launchForce = 500f;
    private Vector3 initialPosition;
    private Vector3 ballInitialPosition;
    private bool isPulling = false;

    void Start()
    {
        initialPosition = molaTransform.localPosition;
        ballInitialPosition = ballTransform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isPulling = true;
            // Move para baixo visualmente
            molaTransform.localPosition = Vector3.Lerp(
                molaTransform.localPosition,
                initialPosition - Vector3.up * maxPullDistance,
                Time.deltaTime * 10f
            );
  
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && isPulling)
        {
            isPulling = false;
            // Volta para posi��o original
            molaTransform.localPosition = initialPosition;
            // Aplica for�a na bola
            ballTransform.localPosition = ballInitialPosition;
            ballRb.AddForce(Vector2.up * launchForce);
            
        }
    }
}
