using DplicacionNomina.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DplicacionNomina.DAL
{
    class EmpleadoDAL
    {
        ConexionDAL conexion;
       
        public EmpleadoDAL() 
        { 
            conexion = new ConexionDAL();
        
        }

        public bool AgregarEmpleado(EmpleadoBLL oempleadoBll) 
        {
            try 
            {
                conexion.EjecutarComandosSinRetorno("insert into TBL_EMPLOYEES values('" + oempleadoBll.birth_date + "','" + oempleadoBll.first_name + "','" + oempleadoBll.hire_date.ToString("yyyy/MM/dd") + "','" + oempleadoBll.gender.Substring(0, 1) + "')");
                return true;
            

            }
            catch (Exception e) 
            {
                Console.WriteLine("Error en el registro" + e);
                return false;
            
            }
            
        
        }

    }
}
