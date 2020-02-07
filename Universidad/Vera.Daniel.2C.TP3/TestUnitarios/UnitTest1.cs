using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Archivos;
using ClasesInstanciables;

namespace TestUnitarios
{
     
    [TestClass]
    public class UnitTest1
    {
        //agrego con dni texto invalido
        [TestMethod]
        public void DniInvalidoException()
        {

            // CASO 1 DNI solo texto
            try
            {
                string dni = "asdjklasdjkl";
                Alumno alumno = new Alumno(1, "Juan", "Lopez",dni ,
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dni);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e,typeof(DniInvalidoException));
            }

            // CASO 2 DNI con numero y texto
            try
            {
                string dniMixto = "37149q11";
                Alumno alumno = new Alumno(1, "Juan", "Lopez",dniMixto,
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniMixto);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            // CASO 3 DNI con COMA            
            try
            {
                string dniComa = "30.999,999";
                Alumno alumno = new Alumno(1, "Juan", "Lopez", dniComa,
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniComa);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

        }
        [TestMethod]
        public void DniBajo()
        {
            // CASO 1 DNI menor a 1
            string dniPrimero = "0";
            try
            {
                Alumno alumno = new Alumno(1, "Juan", "Lopez", dniPrimero,
                 EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                 Alumno.EEstadoCuenta.Becado);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                return;
            }
            Assert.Fail("Sin excepción para DNI inválido: {0}.", dniPrimero);
        }

        //Comprobar los rangos de DNI para Argentinos
        //puedo hacer lo mismo para los exatranjeros
        [TestMethod]
        public void ValorNumerico()
        {
            // CASO 1 DNI al azar
            string dniMedio = new Random().Next(1, 89999999).ToString();
            Alumno alumno = new Alumno(1, "Juan", "Lopez", dniMedio,
                 EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                 Alumno.EEstadoCuenta.Becado);
            // Cargó OK?
            Assert.AreEqual(alumno.DNI.ToString(), dniMedio);

            // CASO 2 primer DNI válido
            string dniPrimero = "1";
            Alumno alumnoPrimero = new Alumno(1, "Juan", "Lopez", dniPrimero,
                 EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                 Alumno.EEstadoCuenta.Becado);
            // Cargó OK?
            Assert.AreEqual(alumnoPrimero.DNI.ToString(), dniPrimero);

            // CASO 3 último DNI válido
            string dniUltimo = "89999999";
            Alumno alumnoUltimo = new Alumno(1, "Juan", "Lopez", dniUltimo,
                 EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                 Alumno.EEstadoCuenta.Becado);
            // Cargó OK?
            Assert.AreEqual(alumnoUltimo.DNI.ToString(), dniUltimo);
        }

        //Que no haya Atributos NULOS
        [TestMethod]
        public void ValorNULL()
        {
            //lista alumnos !=NULL
            Universidad gim = new Universidad();
            Assert.IsNotNull(gim.Alumnos);

            //lista jornadas !=NULL
            Universidad gim2 = new Universidad();
            Assert.IsNotNull(gim2.Jornadas);

            //lista Instructores !=NULL
            Universidad gim3 = new Universidad();
            Assert.IsNotNull(gim3.Instructores);

        }
    }
}
