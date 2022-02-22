using System;
using System.Collections;

class Programa
{
    public static void Main()
    {
        Console.Title = "Tarea 7";
        Hashtable cuentas = new Hashtable(10);
        string iD;
        Cuenta ob = new Cuenta();
        int linea;
        bool continuar = true;

        while (continuar == true)
        {

            Console.WriteLine("\n--- APLICACIÓN: CUENTAS BANCARIAS ---\n");

            Console.Write("Ingrese su Identificación: ");
            iD = Console.ReadLine();

            Console.WriteLine("\nOPCIONES:\n");
            Console.WriteLine("\n1. Crear/Reactivar cuenta");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Retirar");
            Console.WriteLine("4. Consultar saldo");
            Console.WriteLine("5. Inactivar");
            Console.WriteLine("6. Cancelar\n");

            Console.Write("Selecciona una opción: ");
            linea = int.Parse(Console.ReadLine());
            


            switch (linea)
            {
                //  Crear/Reactivar cuenta

                case 1: if (cuentas.ContainsKey(iD))                //Revisa si la cuenta ya existe
                    {
                        Console.Clear();
                        Console.WriteLine("\nREACTIVAR CUENTA ---\n");
                        ob = (Cuenta)cuentas[iD];                   //asigna el objeto
                        switch (ob.Estado)                          //revisa si esta activa/inactiva
                        {
                            //Ya existe/Activa
                            case true:Console.WriteLine("Su cuenta está activa!");
                                break;
                            
                            //Inactiva
                            case false:ob.Estado = true;            //cambia el estado a "activo"
                                Console.WriteLine("Su cuenta ha sido activada correctamente.\n");
                                ob.MostrarDatos();
                                break;
                        }
                    }
                    else                                            //En este caso no existe
                    {
                        if (cuentas.Count < 10)
                        {
                            Console.Clear();
                            Console.WriteLine("\nCREAR CUENTA ---\n");
                            ob = new Cuenta();                          //crea una nueva cuenta
                            Console.Write("Ingrese su nombre: ");
                            ob.Name = Console.ReadLine();
                            ob.Estado = true;                           //activa la cuenta
                            ob.ID = iD;
                            cuentas.Add(iD, ob);                        //agrega la cuenta al diccionario de cuentas
                            ob.MostrarDatos();
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nNo es posible crear una nueva cuenta.");
                            Console.WriteLine("Tope de cuentas alcanzado!");
                        }
                    }

                    break;

                //  Depositar
                
                case 2:                  
                    switch (cuentas.ContainsKey(iD))                //revisa si la cuenta existe
                    {

                        case true:
                            Console.Clear();
                            Console.WriteLine("\nDEPOSITOS ---\n");
                            Console.Write("Ingrese el valor a depositar: ");
                            double deposito = double.Parse(Console.ReadLine());
                            ob = (Cuenta)cuentas[iD];        //asigna la cuenta a ob
                            ob.Depositar = deposito;               //hace el deposito
                            Console.WriteLine("Transacción realizada correctamente.\n");
                            ob.MostrarDatos();
                            break;

                        case false:
                            Console.Clear();
                            Console.WriteLine("Usted no tiene una cuenta!\n");
                            break;
                    }

                    break;

                //  Retirar

                case 3:
                    switch (cuentas.ContainsKey(iD))
                    {
                        case true:
                            Console.Clear();
                            Console.WriteLine("\nRETIROS ---\n");
                            Console.Write("Ingrese el valor a retirar: ");
                            double retiro = double.Parse(Console.ReadLine());
                            ob = (Cuenta)cuentas[iD];
                            if (retiro > ob.Saldo)
                            {
                                Console.WriteLine("Saldo insuficiente!");
                            }
                            else
                            {
                                ob.Retirar = retiro;
                                ob.MostrarDatos();
                            }
                            
                            break;

                        case false:
                            Console.Clear();
                            Console.WriteLine("Usted no tiene una cuenta!\n");
                            break;
                     
                    }

                    break;
                
                //Consultar saldo

                case 4: switch (cuentas.ContainsKey(iD))
                    {
                        case true:
                            Console.Clear();
                            Console.WriteLine("\nSALDO ---\n");
                            ob = (Cuenta)cuentas[iD];
                            ob.MostrarDatos();
                            break;

                        case false:
                            Console.Clear();
                            Console.WriteLine("Usted no tiene una cuenta!");
                            break;
                    }

                    break;

             
                //  Inactivar

                case 5: switch (cuentas.ContainsKey(iD))
                    {
                        case true:ob = (Cuenta)cuentas[iD]; //En caso de que la cuenta exista
                            if (ob.Saldo == 0)              //Verifica que el saldo sea 0
                            {
                                Console.Clear();
                                ob.Estado = false;          //Inactiva la cuenta
                                Console.WriteLine("Su cuenta ha sido inactivada correctamente.");
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Su saldo debe ser igual a $0 para inactivar la cuenta!\n");
                            }

                            break;


                        case false:
                            Console.Clear();
                            Console.WriteLine("Usted no tiene una cuenta!\n"); //la cuenta no existe
                            break;
                    }

                    break;
                
                //  Cancelar

                case 6: switch (cuentas.ContainsKey(iD))
                    {
                        case true:ob = (Cuenta)cuentas[iD];     //En caso de que la cuenta exista
                            if (ob.Saldo == 0)
                            {
                                Console.Clear();
                                cuentas.Remove(iD);             //Elimina la cuenta
                                Console.WriteLine("La cuenta ha sido eliminada correctamente.\n");
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Su saldo debe ser igual a $0 para cancelar la cuenta!\n");
                            }

                            break;

                        case false:
                            Console.Clear();
                            Console.WriteLine("Usted no tiene una cuenta!\n");
                            break;
                    }

                    break;
            }

            // continuar?

            Console.Write("\nDesea hacer alguna otra acción? (s/n): ");
            string rpta = Console.ReadLine();
            Console.Clear();

            if (rpta == "s" || rpta == "S")
            {
                continuar = true;
            }

            else
            {
                continuar = false;
            }

        }

        Console.WriteLine("\n   Que tenga un feliz día.");
        Console.ReadLine();
    }
}