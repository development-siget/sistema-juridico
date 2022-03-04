using System.Collections.Generic;
using Juridico.Models;

namespace Juridico.Services
{
    public interface IMenuService
    {
        public List<MenuItem> LoadMenuItems();
    }
}