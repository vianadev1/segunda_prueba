using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dislove_controladodesdeScrit : MonoBehaviour
{
    [Header("disve")] // esto que es  un encabezado  que sale  en el inspector  
    [SerializeField] private float _disolveSpeed = 1;
    [SerializeField] private float _disolveWait = 1;

    [Header("Referens")] // esto que es  un encabezado  que sale  en el inspector  
    [SerializeField] private Material _disolvematerial ;
    //variables del efecto 
    private bool _isdisolvin;  //  para evitar romper el efecto

    private float _disolveValue = 0; // modificar el slider 
    private float _valuestart = 1; // modificar el slider 
    private float _valueEnd = 0; // modificar el slider 
   


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !_isdisolvin)
        {
            StartCoroutine(makedisolve());
           // viana  ejecutar efecto 
        }
    }
    private IEnumerator makedisolve()
    {
        _disolveValue = _valuestart;
        _isdisolvin = true;

        while(_disolveValue > _valueEnd) ///RESTAR ELL VALOR DEL DISOLVE 
        {
            _disolveValue -= Time.deltaTime * _disolveSpeed;
            _disolvematerial.SetFloat("_DISSOLVE", _disolveValue); // interactuando con el shader 
            yield return null; 
            /*  yield para esperar   se utiliza en una corutina para pausar
            la ejecución de la corutina y permitir que el motor de Unity 
            actualice la escena y procese otros eventos en el jueg*/
        }

        _disolveValue = _valueEnd;

        Debug.Log($"color=green><b> CHANGE! <b></color");

        yield return new WaitForSeconds(_disolveWait);

        while (_disolveValue < _valuestart) ///RESTAR ELL VALOR DEL DISOLVE 
        {
            _disolveValue += Time.deltaTime * _disolveSpeed;
            _disolvematerial.SetFloat("", _disolveValue); // interactuando con el shader 
            yield return null;
            /*  yield para esperar   se utiliza en una corutina para pausar
            la ejecución de la corutina y permitir que el motor de Unity 
            actualice la escena y procese otros eventos en el jueg*/
        }

        _isdisolvin = false;
    }
}
