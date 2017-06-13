using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private EEstadoCuenta _estadoCuenta;
        private Universidad.EClases _claseQueToma;

        #endregion

        #region Constructores

        public Alumno() : base() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder("");

            texto.Append(base.MostrarDatos());
            texto.Append("ESTADO DE CUENTA: " + this._estadoCuenta + "\n");
            texto.Append(this.ParticiparEnClase());

            return texto.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma + "\n";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a._estadoCuenta.Equals(EEstadoCuenta.Deudor)) && a._claseQueToma.Equals(clase));
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a._claseQueToma.Equals(clase));
        }

        #endregion

        #region Enumerados

        public enum EEstadoCuenta
        {
            Becado,
            Deudor,
            AlDia
        }

        #endregion
    }
}
