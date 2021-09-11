using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajoPractico2.Models
{
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private int edad;
        private string direccion;
        private string telefono;
        private string puesto;
        private DateTime fechaIngreso;
        private int antiguedad;
        private double salario;
        private const float sueldoBasico = 20000;

        //public static List<Empleado> listaEmpleados = new List<Empleado>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad;}
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public int Antiguedad { get => antiguedad;}
        public double Salario { get => salario;}
        public static float SueldoBasico => sueldoBasico;

        public Empleado(string nombre, string apellido, DateTime fechaNacimiento, string direccion, string telefono, string puesto, DateTime fechaIngreso)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.puesto = puesto;
            this.fechaIngreso = fechaIngreso;

            edad = calcularEdad(fechaNacimiento);
            antiguedad = calcularAntiguedad(fechaIngreso);
            salario = calcularSalario(antiguedad);
        }

        public int calcularEdad(DateTime fechaNac)
        {
            DateTime fechaActual = DateTime.Today;

            int edad = fechaActual.Year - fechaNac.Year;
            if (fechaNac.Month > fechaActual.Month)
            {
                --edad;
            }

            return edad;
        }

        public int calcularAntiguedad(DateTime fechaIng)
        {
            DateTime fechaActual = DateTime.Today;

            int antig = fechaActual.Year - fechaIng.Year;
            if (fechaIng.Month > fechaActual.Month)
            {
                --antig;
            }

            return antig;
        }

        public double calcularSalario(int antiguedad)
        {
            float descuento = (15 / 100) * sueldoBasico;

            float adicional;
            if(antiguedad < 20)
            {
                adicional = (1 / 100) * antiguedad;
            }
            else
            {
                adicional = 25 / 100;
            }

            salario = sueldoBasico + (adicional * sueldoBasico) - (descuento * sueldoBasico);

            return salario;
        }

    }
}
