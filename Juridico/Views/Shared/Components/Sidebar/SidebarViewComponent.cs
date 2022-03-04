using System.Collections.Generic;
using Juridico.Models;
using Juridico.Services;
using Microsoft.AspNetCore.Mvc;

namespace Juridico.Views.Shared.Components.Sidebar
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;

        public SidebarViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public IViewComponentResult Invoke()
        {
            var itemsMenu = _menuService.LoadMenuItems();
            var controller = ViewContext.RouteData.Values["controller"].ToString();
            var accion = ViewContext.RouteData.Values["action"].ToString();

            foreach (var menuItem in itemsMenu)
            {
                if (menuItem.SubMenu)
                {
                    foreach (var subMenuItem in menuItem.SubMenuItems)
                    {
                        if (subMenuItem.Controlador == controller && subMenuItem.Accion == accion)
                        {
                            menuItem.Activo = true;
                            subMenuItem.Activo = true;
                        }
                    }
                } else
                {
                    if (menuItem.Controlador == controller)
                    {
                        menuItem.Activo = true;
                    }
                }
            }

            return View(itemsMenu);
        }
    }
}