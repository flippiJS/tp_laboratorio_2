using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        #region Atributos

        protected string _nombre;
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;

        #endregion

        #region Propiedades


        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    _nombre = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    _apellido = value;
            }
        }

        public int DNI
        {
            get { return _dni; }
            set
            {
                _dni = ValidarDni(Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public string StringToDNI
        {
            set
            {
                _dni = ValidarDni(Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");
            str.Append("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\n");
            str.Append("NACIONALIDAD: " + this.Nacionalidad.ToString() + "\n\n");
            return str.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            try
            {
                if ((dato < 1 || dato > 89999999) && !(nacionalidad.Equals(ENacionalidad.Argentino)))
                {
                    throw new DniInvalidoException();
                }
            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine("La nacionalidad no se condice con el numero de DNI");
                return -1;
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        private string ValidarNombreApellido(string dato)
        {
            string retorno = null;

            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
                retorno = dato;

                return retorno;
        }

        #endregion

        #region Enumerados

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
