using System;

class Cuenta
{
    double saldo = 0;
    bool estado = true;
    string name;
    string iD;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string ID
    {
        get
        {
            return iD;
        }

        set
        {
            iD = value;
        }
    }

    public double Depositar
    {
        get
        {
            return saldo;
        }

        set
        {
            saldo += value;
        }
    }

    public double Retirar
    {
        get
        {
            return saldo;
        }
        set
        {
            saldo -= value;
        }
    }

    public double Saldo
    {
        get
        {
            return saldo;
        }
    }

    public bool Estado
    {
        get
        {
            return estado;
        }

        set
        {
            estado = value;
        }
    }

    public void MostrarDatos()
    {
        Console.WriteLine("\nNombre: {0}", name);
        Console.WriteLine("Identificación: {0}", iD);
        Console.WriteLine("Saldo: {0}\n", saldo);
    }
}