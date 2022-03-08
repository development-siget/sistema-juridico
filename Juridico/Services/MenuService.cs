using System.Collections.Generic;
using Juridico.Controllers;
using Juridico.Models;

namespace Juridico.Services
{
    public class MenuService : IMenuService
    {
        public List<MenuItem> LoadMenuItems()
        {
            var itemsMenu = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Nombre = "Home", Icono = "fa-home", Accion = "Index", Controlador = "Home" },
                new MenuItem() { Id = 2, Nombre = "Correspondencia", Icono = "fa-envelope-open", SubMenu = true, SubMenuItems = new List<SubMenuItem>()
                {
                    new SubMenuItem(){Id = 1, Nombre = "Lista", Controlador = "Correspondencia", Accion = "Index"},
                    new SubMenuItem(){Id = 1, Nombre = "Ingresar correspondencia", Controlador = "Correspondencia", Accion = "IngresarCorrespondencia"},
                }},
                new MenuItem() { Id = 2, Nombre = "Personas", Icono = "fa-users", SubMenu = true, SubMenuItems = new List<SubMenuItem>()
                {
                    new SubMenuItem(){Id = 1, Nombre = "Lista", Controlador = "Persona", Accion = "Index"},
                    new SubMenuItem(){Id = 1, Nombre = "Nueva persona", Controlador = "Persona", Accion = "Create"},
                }},
                new MenuItem() { Id = 3, Nombre = "Remitentes", Icono = "fa-address-card", SubMenu = true, SubMenuItems = new List<SubMenuItem>()
                {
                    new SubMenuItem(){Id = 1, Nombre = "Lista", Controlador = "Remitentes", Accion = "Index"},
                    new SubMenuItem(){Id = 1, Nombre = "Nueva persona", Controlador = "Remitentes", Accion = "Create"},
                }},
                new MenuItem() { Id = 4, Nombre = "Catálogos", Icono = "fa-list", SubMenu = true, SubMenuItems =  new List<SubMenuItem>()
                {
                    new SubMenuItem(){Id = 1, Nombre = "Empleados", Controlador = "DatosEmpleados", Accion = "Index"},
                    new SubMenuItem(){Id = 2, Nombre = "Roles", Controlador = "Roles", Accion = "Index"},
                    new SubMenuItem(){Id = 3, Nombre = "Acciones", Controlador = "Acciones", Accion = "Index"},
                    new SubMenuItem(){Id = 4, Nombre = "Estados", Controlador = "Estados", Accion = "Index"},
                    new SubMenuItem(){Id = 5, Nombre = "Procesos", Controlador = "Proceso", Accion = "Index"},
                    new SubMenuItem(){Id = 6, Nombre = "Anexos", Controlador = "Anexos", Accion = "Index"},
                    new SubMenuItem(){Id = 7, Nombre = "Requerimientos", Controlador = "Requerimiento", Accion = "Index"},
                    new SubMenuItem(){Id = 8, Nombre = "Tipo Acción", Controlador = "TipoAccion", Accion = "Index"},
                    new SubMenuItem(){Id = 9, Nombre = "Tipo Archivo", Controlador = "TipoArchivo", Accion = "Index"},
                    new SubMenuItem(){Id = 10, Nombre = "Tipo Documento", Controlador = "TipoDocumentoRemitente", Accion = "Index"},
                    new SubMenuItem(){Id = 11, Nombre = "Tipo Entidad", Controlador = "TipoEntidad", Accion = "Index"},
                    new SubMenuItem(){Id = 12, Nombre = "Tipo Estado", Controlador = "TipoEstado", Accion = "Index"},
                    new SubMenuItem(){Id = 13, Nombre = "Tipo Remitente", Controlador = "TipoRemitente", Accion = "Index"},
                    new SubMenuItem(){Id = 14, Nombre = "Empleados Requerimiento", Controlador = "EmpleadosRequerimiento", Accion = "Create"},
                }}
            };
            return itemsMenu;
        }
    }
}