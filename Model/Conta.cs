﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Model
{
    public class Conta
    {
        private int numero;
        private int agencia;
        private int tipo;
        private string titular = string.Empty;
        private decimal saldo;

        /*Construtor criado com crtl + . */
        public Conta(int numero, int agencia, int tipo, string titular, decimal saldo)
        {
            this.numero = numero;
            this.agencia = agencia;
            this.tipo = tipo;
            this.titular = titular;
            this.saldo = saldo;
        }
        /* Area Para Criar metodos, aqui primeiro os get e set */

        public int GetNumemero()
        {
            return numero;
        }
        public void SetNumero(int numero)
        {
            this.numero = numero;
        }

        public int GetAgencia()
        {
            return agencia;
        }
        public void SetAgencia(int agencia)
        {
            this.agencia = agencia;
        }

        public int GetTipo()
        {
            return tipo;
        }
        public void SetTipo(int tipo)
        {
            this.tipo = tipo;
        }

        public string GetTitular()
        {
            return titular;
        }
        public void SetTitular(string titular)
        {
            this.titular = titular;
        }

        public decimal GetSaldo()
        {
            return saldo;
        }
        public void SetSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }

        public bool Sacar(decimal valor)
        {
            if (this.GetSaldo() < valor)
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.SetSaldo(this.saldo - valor);
            return true;
        }

        public void Depositar(decimal valor)
        {
            this.SetSaldo(this.saldo + valor);
        }

        public void Visualizar()
        {


            string tipo = "";

            switch (this.tipo)
            {
                case 1:
                    tipo = "Conta Corrente";
                    break;
                case 2:
                    tipo = "Conta Poupança";
                    break;
            }

            Console.WriteLine("\n\n*********************************************************************");
            Console.WriteLine("Dados da Conta:");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("Numero da Conta: " + this.numero);
            Console.WriteLine("Agência: " + this.agencia);
            Console.WriteLine("Tipo da Conta: " + tipo);
            Console.WriteLine("Titular: " + this.titular);
            Console.WriteLine("Saldo: " + (this.saldo).ToString("C"));

        }


    }
}