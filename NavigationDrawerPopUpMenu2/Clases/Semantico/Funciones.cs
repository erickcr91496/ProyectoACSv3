using NavigationDrawerPopUpMenu2.Clases.Sintactico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationDrawerPopUpMenu2.Clases.Semantico
{
    class Funciones
    {



        List<TDS> listaTDS = winLexical.Tabla;//traer la tabla de simbolos del lexico

        Stack<Atributos> PilaSemantica = new Stack<Atributos>();

        public int ntupla = 0;
        public int ntemporal = 0;
        Cuadruplos cdplo = new Cuadruplos();
        List<Produccion> reglasReconocidas = winSintactico.ReglaReco1;

        public Funciones()
        {
        }


        //Metodo para mostrar las reglas reconocidas del sintactico en el ListBox


        public void compararTipos(Atributos atr1, Atributos atr2)
        {
            int t1, t2;
            if (atr1.tipo == 0) // los dos son identificadores
            {
                t1 = buscarTipoTDS(atr1.valor.ToString());
                atr1.tipo = t1;
            }
            else
            {
                t1 = atr1.tipo;

            }
            if (atr2.tipo == 0)
            {
                t2 = buscarTipoTDS(atr2.valor.ToString());
                atr2.tipo = t2;
            }
            else
            {
                t2 = atr2.tipo;
            }
            if (t1 > 2 || t2 > 2)
            {
                MessageBox.Show("ERROR: no se puede realizar operaciones con char, string o bool");
            }
            else
            {
                if (t1 != t2)
                {
                    MessageBox.Show("ERROR TIPOS NO COMPATIBLES!!");
                    //mensaje de error tipos no compatibles                       
                }
            }
        }



        public int Next()
        {
            ntupla++;
            cdplo.numbertupla = ntupla;
            cdplo.CodigoIntermedio.Add(cdplo);
            return ntupla;
        }

        public string DameTemporal(int tipo)
        {
            ntemporal++;

            string temporal = "T" + ntemporal.ToString();
            //guardar en TDS el temporal con el simbolo
            TDS variable = new TDS();
            variable.nombre = temporal;
            variable.nToken = listaTDS.Count + 1;
            variable.tipo = tipo;
            switch (tipo)
            {
                case 1: variable.size = 4; break;
                case 2: variable.size = 8; break;
                case 3: variable.size = 1; break;
                case 4: variable.size = 80; break;
                case 5: variable.size = 1; break;
            }

            variable.valor = null;
            listaTDS.Add(variable);
            return temporal;
        }

        //Metodo que busca en la tabla de simbolos 
        public int buscarTipoTDS(string valor)
        {

            for (int i = 0; i < listaTDS.Count; i++)
            {
                if (listaTDS[i].nombre == valor)
                {
                    return listaTDS[i].tipo;
                }
            }
            return 0;
        }




        public void Gen(string operador, string operando1, string operando2, string resultado)
        {
            cdplo.CodigoIntermedio[ntupla - 1].operador = operador;
            cdplo.CodigoIntermedio[ntupla - 1].operando1 = operando1;
            cdplo.CodigoIntermedio[ntupla - 1].operando2 = operando2;
            cdplo.CodigoIntermedio[ntupla - 1].resultado = resultado;
        }

        public void GenerarCodigoCuadruplos()
        {
            Atributos atr = new Atributos();
            Atributos atr1 = new Atributos();
            Atributos atr2 = new Atributos();


            for (int i = 0; i < winSintactico.ReglaReco1.Count(); i++)
            {

                int nregla = winSintactico.ReglaReco1[i].n;

                switch (nregla)
                {


                    case (1):
                        break;
                    case (2)://D->U : <declarar> -> <undeclare>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "declarar";
                        PilaSemantica.Push(atr);
                        break;
                    case (3):
                       
                        
                        break;
                    case (4):
                        break;
                    case (5):
                        break;
                    case (6):
                        break;
                    case (7):
                        break;
                    case (8):
                        break;
                    case (9):
                        break;
                    case (10):
                        break;
                    case (11):
                        break;
                    case (12):
                        break;
                    case (13):
                        break;
                    case (14):
                        break;
                    case (15):
                        break;
                    case (16)://I->X : <instrucciones> -> <instrucción>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        var Nombre = "instrucciones";
                        PilaSemantica.Push(atr);
                        break;
                    case (17)://<instrucciones> : <instruccion><instrucciones>

                        break;
                    case (18)://X->Y : <instrucción> -> <if>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (19)://X->W : <instrucción> -> <while>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (20)://X->S : <instrucción> -> <for>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (21)://X->V : <instrucción> -> <escribir>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (22)://X->R : <instrucción> -> <leer>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (23)://X->O : <instrucción> -> <do>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (24)://X->M : <instrucción> -> <incremento>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (25)://X->A : <instrucción> -> <asigna>
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "instrucción";
                        PilaSemantica.Push(atr);
                        break;
                    case (26):
                        break;
                    case (27):
                        break;
                    case (28):
                        break;
                    case (29):
                        break;
                    case (30): //W -> x(X)(I)   while -> while(<condicion>){<instrucciones>} 
                               // atr1 = PIlaSemantica.Pop() // aqui esta el valor del no terminal de I
                               // atr2 = PIlaSemantica.Pop() aqui esta el valor de no terminal de Z
                               //BackPatch(atr2.Principio,atr1.Verdadero)
                               //BackPatch(atr2.Siguiente,atr1.Falso)


                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "While";
                        PilaSemantica.Push(atr);
                        break;
                    case (31):
                        break;
                    case (32):
                        break;
                    case (33):
                        break;
                    case (34):
                        break;
                    case (35):
                        break;
                    case (36):
                        break;
                    case (37):
                        break;
                    case (38):
                        break;
                    case (39)://A->i:E;     : <expresion> -> <expresion> + <termino>
                        
                        
                        break;
                    case (40): // Z -> EBE
                       // atr = new 
                        break;
                    case (41): // B -> |    : <operel> -> ||    (OR)
                       // atr = new Atributos();
                       // atr.noterminal = reglasReconocidas[i].izq;
                       // atr.nombre ="operel";
                       // atr. valor = "||"
                        // atr.tipo = art1.tipo;
                        //PilaSemantica.Push(atr);
                                               
                        break;
                    case (42):
                        break;
                    case (43):
                        break;
                    case (44):
                        break;
                    case (45):
                        break;
                    case (46):
                        break;
                    case (47):
                        break;
                    case (48):
                        break;
                    case (49):      //E->E+T: <expresion> -> <expresion> + <termino>
                        atr1 = PilaSemantica.Pop();// es igual a lo que tenfgo de factor
                        atr2 = PilaSemantica.Pop(); // es igual a termino
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;

                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        atr.valor = DameTemporal(atr1.tipo);

                        Gen("*", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "expresion";
                        PilaSemantica.Push(atr);
                        break;
                    case (50): //E->E - T : <expresion> -> <expresion> - <termino>

                        atr1 = PilaSemantica.Pop(); //esto es igual a lo que tengo de factor 
                        atr2 = PilaSemantica.Pop();// esto es igual a termino                       
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        atr.valor = DameTemporal(atr1.tipo);
                        Gen("-", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "expresion";
                        PilaSemantica.Push(atr);
                        break;
                    case (51)://E->T : <expresion> -> <termino>
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "expresion";
                        PilaSemantica.Push(atr);
                        break;


                    case (52)://t->f: termino -> <factor>

                        atr1 = PilaSemantica.Pop();// es igual a lo que tenfgo de factor
                        atr2 = PilaSemantica.Pop(); // es igual a termino
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;

                        //if (buscarTipoTDS(atr1.valor.ToString() == buscarTipoTDS(atr2.valor.ToString())
                        //{
                        //    //mensaje de error tipos no compatibles
                        //}
                        atr.valor = DameTemporal(0);
                        Gen("*", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "termino";
                        PilaSemantica.Push(atr);
                        break;
                    case (53)://T->T/F : <termino> -> <termino> / <factor>
                        atr1 = PilaSemantica.Pop(); //esto es igual a lo que tengo de factor 
                        atr2 = PilaSemantica.Pop();// esto es igual a termino                       
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        atr.valor = dameTemporal(atr1.tipo);
                        Gen("/", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "termino";
                        PilaSemantica.Push(atr);
                        break;

                    case (54)://T->T^F : <termino> -> <termino> ^ <factor>

                        atr1 = PilaSemantica.Pop(); //esto es igual a lo que tengo de factor 
                        atr2 = PilaSemantica.Pop();// esto es igual a termino                       
                        compararTipos(atr1, atr2);
                        atr.principio = Next();
                        atr.siguiente = atr.principio + 1;
                        atr.valor = DameTemporal(atr1.tipo);
                        Gen("^", atr1.valor.ToString(), atr2.valor.ToString(), atr.valor.ToString());
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "termino";
                        PilaSemantica.Push(atr);
                        break;
                    case (55)://t->f: termino -> <factor>

                        atr = PilaSemantica.Pop();

                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "termino";
                        atr.valor = reglasReconocidas[i].dato;
                        PilaSemantica.Push(atr);
                        break;


                    case (56):
                        atr = new Atributos();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = reglasReconocidas[i].dato;
                        PilaSemantica.Push(atr);
                        break;


                    case (57):
                        atr = new Atributos();
                        atr = PilaSemantica.Pop();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = reglasReconocidas[i].dato;
                        PilaSemantica.Push(atr);
                        break;
                    case (58)://F->a : <factor> -> literal
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = reglasReconocidas[i].dato;
                        if (reglasReconocidas[i].tipo == "literalentero")
                        {
                            atr.tipo = 1;
                        }
                        else if (reglasReconocidas[i].tipo == "literalreal")
                        {
                            atr.tipo = 2;
                        }
                        else if (reglasReconocidas[i].tipo == "literalcadena")
                        {
                            atr.tipo = 4;
                        }
                        else if (reglasReconocidas[i].tipo == "literalchar")
                        {
                            atr.tipo = 3;
                        }
                        PilaSemantica.Push(atr);
                        break;

                    case (59)://F->v : <factor> -> true

                        atr = new Atributos();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = false;
                        PilaSemantica.Push(atr);
                        break;

                    case (60)://F->f : <factor> -> falso

                        atr = new Atributos();
                        atr.noterminal = reglasReconocidas[i].izq;
                        atr.name = "factor";
                        atr.valor = false;
                        PilaSemantica.Push(atr);
                        break;
                }
            }
        }
        public void BackPatch(int dir, List<int> lista)
        {
            //relena en la direcciones de la lista de cuadruplos con esa direccion colocandola en la ultimatupla que sera el resultado
            foreach (int v in lista)
                    {
                cdplo.CodigoIntermedio[v].resultado = "Goto:" + dir.ToString();

            }
        }
        public List<int> MakeList(int valor)
        {
            List<int> tList = new List<int>();
            tList.Add(valor);
            return (tList);
        }
        public List<int> Merge(List<int> l1, List<int> l2)
        {
            List<int> lr = new List<int>();
            foreach (var v in l1)
            {
                lr.Add(v);


            }
            foreach (var u in l2)
            {
                lr.Add(u);


            }
            return lr;
        }


    }
}
