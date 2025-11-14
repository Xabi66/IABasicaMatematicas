using UnityEngine;

public class LuffyMove : MonoBehaviour
{
    //Velocidad del jugador
    public float speed = 10.0f;
    //Velocidad de rotación del jugador
    public float rotationSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        float translationX = (Input.GetKey("left") ? -1 : Input.GetKey("right") ? 1 :0) * speed * Time.deltaTime;
        float translationZ = (Input.GetKey("w") ? 1 : Input.GetKey("s") ? -1 :0) * speed * Time.deltaTime;
        float rotation = (Input.GetKey("a") ? -1 : Input.GetKey("d") ? 1 :0) * rotationSpeed * Time.deltaTime;

        transform.Translate(translationX, 0, translationZ);
        transform.Rotate(0, rotation, 0);
    }
}
