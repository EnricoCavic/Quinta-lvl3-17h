// bibliotecas / libs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// iniciando a classe
public class MovePersonagem : MonoBehaviour
{
    // declarar var com tipo e nome
    Animator meuAnimator;
    Rigidbody rb;

    public Vector2 inputVector;

    public float velocidade;
    public float velocidade_giro;

    // ocorre uma vez ao iniciar o projeto
    void Start()
    {
        // popular a var
        meuAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        inputVector = new Vector2();
        
        // EXEMPLO NÃO COPIEM
        Debug.Log(transform.up);
    }


    // ocorre uma vez por frame (fps)
    // game loop
    void Update()
    {
        // registrar os inputs do jogador
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        // passando os inputs para o Animator
        meuAnimator.SetFloat("Vertical", inputVector.y);

        float vel_final = velocidade * inputVector.y;
        Vector3 dir = transform.forward * vel_final;
        rb.AddForce(dir, ForceMode.Force);

        float giro_final = velocidade_giro * inputVector.x;
        Vector3 dir_giro = transform.up * giro_final;
        rb.AddTorque(dir_giro, ForceMode.Force);

    }
}

