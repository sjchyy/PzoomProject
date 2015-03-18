using ProCommon.ProEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProCommon.Extensions;

namespace ProjectDemo.Menu
{
   public  class MenuMain
    {
       public MenuMain()
       {
           MenuSource = new MenuView();
       }
        public MenuView MenuSource{ get; set; }
        public Dictionary<EModule,MenuItem> MenuItemDictionary { get; set; }

        public  void InitMenuView(List<EModule> modules, string userName, EModuleLevel level)
        {
            MenuItemDictionary = new Dictionary<EModule, MenuItem>();
            MenuSource.UserName = userName;
            InitMenuItems(modules,level);

   
        }


        private void InitMenuItems(List<EModule> modules, EModuleLevel level)
       {
            switch (level)
            {
                   case  EModuleLevel.Once:
                    InitMenuItemsByOnce(modules);
                    break;
                    case EModuleLevel.Double:
                    InitMenuItemByDouble(modules);
                    break;
            }
       }

       private void InitMenuItemsByOnce(List<EModule> modules)
       {
           for (int i = 0; i < modules.Count; i++)
           {
               EModule module = modules[i];
               MenuItem item = new MenuItem() { Text =module.GetModuleName(),Module = module};
               MenuItemDictionary.Add(module, item);
               MenuSource.MenuItemSource.Add(item);
           }
       }

       private void InitMenuItemByDouble(List<EModule> modules)
       {
           Dictionary<string, MenuItem> mainDictionary = new Dictionary<string, MenuItem>();

           foreach (EModule module in modules)
           {
               string parent = module.GetModuleParentName();
               if (!string.IsNullOrEmpty(parent) &&!mainDictionary.ContainsKey(parent) )
               {
                   MenuItem item = new MenuItem() { Text =parent};
                   mainDictionary.Add(parent, item);
                   MenuSource.MenuItemSource.Add(item);
               }
           }
           foreach (EModule module in modules)
           {
                MenuItem item;
                string parent = module.GetModuleParentName();
                if (!string.IsNullOrEmpty(parent) && mainDictionary.ContainsKey(parent))
               {
                   item = new MenuItem() { Text = module.GetModuleName(), Parent = mainDictionary[parent], Module = module };
                   mainDictionary[parent].Children.Add(item);
               }
               else
               {
                   item = new MenuItem() { Text = module.GetModuleName(), Module = module };
                   MenuSource.MenuItemSource.Add(item);
               }
               MenuItemDictionary.Add(module, item);
           }
       }
        public void SetCurrentMenu(EModule type)
        {
            MenuSource.SetCurrentModule(MenuItemDictionary[type]);
        }
    }
}
