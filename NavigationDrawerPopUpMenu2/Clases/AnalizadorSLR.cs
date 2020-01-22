using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class AnalizadorSLR
    {
        public Stack<Object> pila;
        public List<Token> tokens = new List<Token>();
        int nerror = 0;
        int idtk = 0;
        int estado;
        char e;
        int n;


        public void PonerTKreconocidos() {

        }

        public void Analizador() {
            pila.Push(0); //guardar en la pila
do {
                PonerTKreconocidos(); //el lexico al terminar podria guardar este simbolo de finalizacion al final de los tokens reconocidos
                estado = -1;
                e =' '; //e es el sinónimo
               // n = APSLR[estado, e];

    if (n >= 0 && n < 200) {//aqui es el desplazarse del algoritmo
                    pila.Push(e);
                    pila.Push(n);
                    idtk++;
                }
                else if(n < 0)
    {//aqui es reconocimiento de regla
                    int regla = -n; //cambiamos de signo para que busque la regla 
                   // int m= Gramatica.der(regla);
                  //  int a = Gramatica.izq(regla);
                  //  for (int i = 1; i <= 2 * m; i++)
                  //  {
                  //      pila.Pop();
                  //  }
                  ////  estado = APSLR[cimadepIla(), a];

                 //   pila.Push(a);
                    pila.Push(estado);
                    //AQUI LLAMAREMOS AL SEMÁNTICO ENVIANDOLE EL NÚMERO DE REGLA
                    //semantico(regla);
                    //ó se guardará en listaReglasReconocidos(regla);
                }
                else if(n == 999)
    {//aqui aceptar
                    break;
                }
	else{//aqui error
                  //  presentarMensajeError(n);
                    nerror++;
                }
            } while (nerror <= 5);
            if (n == 999 && nerror == 0) {
              //  presentarMensaje("programa fuente reconocido sin errores sintácticos");
            } else {
              //  presentarMensaje("programa fuente con errores sintácticos");
            }



        }
        //public int siguiente(int n, char c) {
            
        //    int n= 0
             





        




    }
}
