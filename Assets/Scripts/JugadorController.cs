using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Las 3 líneas anteriores hacen referencia al conjunto de librerías que usará nuestro script

//Declaro el nombre de la clase, que "hereda" todo de una clase superior, llamada MonoBehaviour
//Ámbito: pública se puede usar en cualquier lugar del proyecto, referenciándola adecuadamente
//Tipo: Class
//Nombre: JugadorController
//Herencia: MonoBehaviour
public class JugadorController : MonoBehaviour {

	//Declaro una variable de tipo RigidBody que luego asociaremos a nuestro Jugador
	//Ámbito: privada (solo se puede usar en este script) y no sería necesario ponerlo
	//Tipo: Rigidbody
	//Nombre: rb
	private Rigidbody rb;
    //Declaro la variable pública velocidad para poder modificarla desde la Inspector window
    public float velocidad;
    //Declaro e inicializo el contador de coleccionables recogidos
    private int contador = 0;
    //Declaro variables para los textos
    public Text textoContador, textoGanar;

	// Use this for initialization
	void Start () {
		
		//Capturo esa variable al iniciar el juego
		rb = GetComponent<Rigidbody>();
        //Actualizo el texto del contador por pimera vez
        setTextoContador();
        //Inicio el texto de ganar a vacío
        textoGanar.text = "";

	}
	
	// Para que se sincronice con los frames de física del motor
	void FixedUpdate () {
		
		//Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");

		//Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
		Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

		//Asigno ese movimiento o desplazamiento a mi RigidBody
		rb.AddForce(movimiento * velocidad);

	}

    //Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pickup")){
            other.gameObject.SetActive (false);
            contador = contador + 1;
            //Muestro en la consola de depuración el número de coleccionables recogidos
            Debug.Log("Coleccionables recogidos: " + contador);
            //Actualizo el texto del contador
            setTextoContador();
        }
    }

    //Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)
    void setTextoContador(){

    //Para encadenar un texto con una variable, el texto va entre comillas y la variable se encadena con el signo + 
    textoContador.text = "Contador: " + contador.ToString();
    
    //Para comparar si dos valores son iguales, utilizamos ==
    if (contador == 8){
        textoGanar.text = "¡Ganaste!";
        }

    }
}