# Descrición

Escena donde el jugador puede controlar a un personaje y un zombie lo persigue. Si el zombie se acerca a un NPC este sale huyendo.

# Título principal

**Zombie Scene**

## Subtítulo

Incluye las siguientes funciones:

- El *personaje del jugador* puede moverse hacia delante y atras con **W** y **S**, rotar a los lados con **A** y **D** y moverse a izquierda y derecha con **<-** y **->**.
- Hay un *zombie* que persigue automáticamente al jugador y se gira para observarle continuamente.
- Hay un *NPC* que observa los movimientos del zombie y si el zombie se acerca a el sale huyendo automáticamente mirando hacia el lado contrario.

[Ligazón](https://exemplo.com)

```csharp
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

```


```csharp
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    //Objetivo a perseguir
    public GameObject goal;
    Vector3 direction;
    public float speed = 4f;

    private void LateUpdate() {
        //Calcula la direccion en base a la posicion del personaje y su objetivo.
        direction = goal.transform.position - this.transform.position;
        //Gira al personaje
        this.transform.LookAt(goal.transform.position);
        //Si la distancia es menos de 2 se mueve
        if(direction.magnitude > 2){
            //Calcula la velocidad y lo mueve de posicion
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        }
    }
}

```


```csharp
using UnityEngine;

public class ShaggyMove : MonoBehaviour
{
    //Objetivo a perseguir
    public GameObject danger;
    Vector3 direction;
    public float speed = 6f;

    private void LateUpdate() {
        //Calcula la direccion en base a la posicion del personaje y el peligro.
        direction = this.transform.position - danger.transform.position ;
        //Evita que pueda huir en el eje y
        direction.y=0;

        //Si la distancia es menos de 6 escapa
        if(direction.magnitude < 6){
            //Gira al personaje si el peligro esta cerca
            this.transform.LookAt(this.transform.position + direction);
            //Calcula la velocidad y lo mueve de posicion
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        } else if (direction.magnitude > 6) {
            //Si el peligro esta a mas de 6 de distancia, mira hacia el
            this.transform.LookAt(danger.transform.position);          
        }
    }
}

```