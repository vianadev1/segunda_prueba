using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveDesdeScript : MonoBehaviour
{
    [Header("disve")] // esto que es  un encabezado  que sale  en el inspector  
    [SerializeField] private float _disolveSpeed = 1;
    [SerializeField] private float _disolveWait = 1;
    [Space]
    [SerializeField] private bool _useIndex; // el qu e esta en ellindice deñ ,es 
    [SerializeField] private MeshRenderer _disolveMesh ; // el mes que vamosa modificar ose la maya 
    [SerializeField] private int _disolveMeshIndex; //  espacios del mesh 


    [Header("Referens")] // esto que es  un encabezado  que sale  en el inspector  
    [SerializeField] private Material _disolvematerial;
    //variables del efecto 
    private bool _isdisolvin;  //  para evitar romper el efecto

    private float _disolveValue = 0; // modificar el slider 
    private float _valuestart = 3.8f; // modificar el slider 
    private float _valueEnd = -1.8f; // modificar el slider 


    //covertir la cadena de texto _Disolve en numeros ;
    private int hash_Disolve = Shader.PropertyToID("_DISSOLVE");


    private void Start()
    {
        // esta setiendo el material  shader material es el shader que tiene el material lo podemos modificar el porpio material 
        // materials  crea una instaci de un material 
        if (_useIndex) _disolvematerial = _disolveMesh.materials[_disolveMeshIndex]; // se la pasa de indixe para modificar el materil de la lista 
        _disolvematerial.SetFloat(hash_Disolve, _valuestart);

    }

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

        while (_disolveValue > _valueEnd) ///RESTAR ELL VALOR DEL DISOLVE 
        {
            _disolveValue -= Time.deltaTime * _disolveSpeed;
            _disolvematerial.SetFloat(hash_Disolve, _disolveValue); // interactuando con el shader   _disolvematerial.SetFloat("_DISSOLVE", _disolveValue); SE OPTIMIZA RECURSOS  UTILA HASH DISOLVE 
            yield return null;
            /*  yield para esperar   se utiliza en una corutina para pausar
            la ejecución de la corutina y permitir que el motor de Unity 
            actualice la escena y procese otros eventos en el jueg*/
        }

        _disolveValue = _valueEnd;

        Debug.Log($"color=green><b> CHANGE! <b></color"); // jaja es un mendaje lolo

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
