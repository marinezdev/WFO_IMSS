using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.IU
{
    public class Comun
    {
        public void CargaInicialdllTipoNomina(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Clear();
            dropdownlist.Items.Insert(0, new ListItem("Seleccionar", "00"));
            dropdownlist.Items.Insert(1, new ListItem("ACTIVOS", "AA"));
            dropdownlist.Items.Insert(2, new ListItem("ESTATUTO MANDO", "EA"));
            dropdownlist.Items.Insert(3, new ListItem("JUBILADOS", "JJ"));
            dropdownlist.Items.Insert(4, new ListItem("MANDO", "MM"));
        }

        public void CargaRechazosPromotorias(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Clear();
            dropdownlist.Items.Insert(0, new ListItem("Seleccionar Motivo Rechazos Inmediato", "0"));
            dropdownlist.Items.Insert(1, new ListItem("Archivo Dañado o con Formato Incorrecto.", "1"));
            dropdownlist.Items.Insert(2, new ListItem("Archivo(s) incluyen dos o más Nóminas", "2"));
            dropdownlist.Items.Insert(3, new ListItem("Documentación Incompleta", "3"));
            dropdownlist.Items.Insert(4, new ListItem("Seleccionar Motivo Rechazo Promotorías", "4"));
            dropdownlist.Items.Insert(5, new ListItem("Datos ilegibles en carta de instrucción", "5"));
            dropdownlist.Items.Insert(6, new ListItem("Sin datos y / o sello de la promotoria", "6"));
            dropdownlist.Items.Insert(7, new ListItem("Sin póliza o póliza incorrecta", "7"));
            dropdownlist.Items.Insert(8, new ListItem("Sin importes en la carta de instrucción en descuento y / o suma asegurada", "8"));
            dropdownlist.Items.Insert(9, new ListItem("Sin matrícula o matrícula incorrecta", "9"));
            dropdownlist.Items.Insert(10, new ListItem("Sin nombre del asegurado", "10"));
            dropdownlist.Items.Insert(11, new ListItem("Tachaduras", "11"));
            dropdownlist.Items.Insert(12, new ListItem("Firma y/ o datos de la identificación oficial ilegibles o no corresponden con la carta.", "12"));
            dropdownlist.Items.Insert(13, new ListItem("Importe no coincide alta/ modificación", "13"));
            dropdownlist.Items.Insert(14, new ListItem("Formato de Carta de Instrucción No Valido", "14"));
        }

        public void CargaRechazosValidacionImss(ref DropDownList dropdownlist)
        {
            dropdownlist.Items.Clear();
            dropdownlist.Items.Insert(0, new ListItem("Seleccionar Motivo Rechazo Validación Imss", "0"));
            dropdownlist.Items.Insert(1, new ListItem("Empleado no encontrado y/ o sustituto baja", "1"));
            dropdownlist.Items.Insert(2, new ListItem("Importe no coincide baja", "2"));
            dropdownlist.Items.Insert(3, new ListItem("No existe póliza no procede baja", "3"));
            dropdownlist.Items.Insert(4, new ListItem("Tipo de nómina no corresponde baja", "4"));
            dropdownlist.Items.Insert(5, new ListItem("El trabajador no tiene capacidad de crédito suficiente", "5"));
            dropdownlist.Items.Insert(6, new ListItem("Empleado no encontrado y/ o sustituto alta/ modificación", "6"));
            dropdownlist.Items.Insert(7, new ListItem("No existe póliza no procede modificación", "7"));
            dropdownlist.Items.Insert(8, new ListItem("Póliza con Descuento Correcto no procede modificación", "8"));
            dropdownlist.Items.Insert(9, new ListItem("Tipo de nómina no corresponde alta / modificación", "9"));
            dropdownlist.Items.Insert(10, new ListItem("Ya existe póliza no procede alta", "10"));
        }




    }
}
