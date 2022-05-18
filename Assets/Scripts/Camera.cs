using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    //vectores para limitar la posicion de la camara en los e3jes x e y
    public Vector2 limitX;
    public Vector2 limitY;

    public float interpolationRatio;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Posicion deseada de la camara
        Vector3 desiredPosition = target.position + offset;
        // limitamos el movimiento en el eje horizontal
        float limitedXPosition = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);
        // limitamos el movimiento en el hejo vertical
        float limitedYPosition = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);
        //construimos un vector3 con los limites que hemos creado
        Vector3 limitedPosition = new Vector3(limitedXPosition, limitedYPosition, desiredPosition.z);
        //interpolamos la posicion
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, limitedPosition, interpolationRatio);

        transform.position = lerpedPosition;
    }
}