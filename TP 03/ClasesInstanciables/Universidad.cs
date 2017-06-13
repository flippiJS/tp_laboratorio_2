using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Jornada> jornada;
        private List<Profesor> profesores;
        private List<Alumno> alumnos;

        #endregion

        #region Propiedades

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }
        }

        #endregion

        #region Constructores

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool Guardar(Universidad gim)
        {
            StreamWriter texto = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", false);
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            try
            {
                xml.Serialize(texto, gim);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                texto.Close();
            }

            return true;
        }

        public static Universidad Leer()
        {
            StreamReader texto = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            Universidad universidad = (Universidad)xml.Deserialize(texto);

            texto.Close();

            return universidad;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder texto = new StringBuilder("");

            foreach (Alumno alumno in gim.Alumnos)
            {
                texto.Append(alumno.ToString());
            }

            foreach (Jornada jornada in gim.Jornadas)
            {
                texto.Append(jornada.ToString());
            }

            foreach (Profesor profesor in gim.Instructores)
            {
                texto.Append(profesor.ToString());
            }

            return texto.ToString();
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    retorno = true;
            }

            return retorno;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                    retorno = profesor;
            }
            return retorno;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                    retorno = profesor;
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            try
            {
                if (g != a)
                {
                    g.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
                return g;
            }
            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profe = (g == clase);
            List<Alumno> alumnos = new List<Alumno>();
            Jornada jornada = null;

            if (!(Object.Equals(profe, null)))
            {
                jornada = new Jornada(clase, profe);
            }
            if (!(Object.Equals(jornada, null)))
            {
                foreach (Alumno al in g.Alumnos)
                {
                    if (al == clase)
                        jornada = jornada + al;
                }

                g.Jornadas.Add(jornada);
            }

            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            try
            {
                if (g != i)
                {
                    g.Instructores.Add(i);
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }

            return g;
        }

        #endregion

        #region Enumeradores

        public enum EClases
        {
            Programacion,
            Laboratorio,
            SPD,
            Legislacion
        }

        #endregion
    }
}

