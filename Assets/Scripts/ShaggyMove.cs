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
