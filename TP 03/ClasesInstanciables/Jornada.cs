using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada : Texto
    {
        #region Atributos

        private Universidad.EClases _clase;
        private Profesor _instructor;
        private List<Alumno> _alumnos;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }

        public Profesor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }

        #endregion

        #region Constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Metodos

        public string Leer()
        {
            string retorno = "";

            Texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out retorno);

            return retorno;
        }

        public static bool Guardar(Jornada jornada)
        {
            return Texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }

        public override string ToString()
        {
            StringBuilder texto = new StringBuilder("");

            texto.Append("JORNADA: \n");
            texto.Append("CLASE DE " + this.Clase + "\n");

            foreach (Alumno alumno in this.Alumnos)
            {
                texto.Append(alumno.ToString());
            }

            texto.Append(this.Instructor.ToString());
            texto.Append("<--------------------------------------------->\n");

            return texto.ToString();
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in j._alumnos)
            {
                if (alumno == a)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);

            return j;
        }

        #endregion

    }
}

