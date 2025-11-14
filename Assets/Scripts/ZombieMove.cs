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
