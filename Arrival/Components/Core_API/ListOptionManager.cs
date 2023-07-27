using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class ListOptionManager : BaseManager
    {
        private Dictionary<string, List<OptionList>> dicListOptions;
        private static ListOptionManager _instance;
        //private ListCrudFactory crudCustomer;

        private ListOptionManager()
        {
            LoadDictionary();
            //crudCustomer = new ListCrudFactory();
        }

        //nivel y seccion datables
        //Listar transportistas
        public static ListOptionManager GetInstance()
        {
            if (_instance == null)
                _instance = new ListOptionManager();

            return _instance;
        }


        private void LoadDictionary()
        {
            dicListOptions = new Dictionary<string, List<OptionList>>();

            var crudListOption = new ListOptionCrudFactory();

            var lists = crudListOption.RetrieveAll<OptionList>();

            var lstId = lists[0].ListId;
            var lstOptions = new List<OptionList>();

            for (int i = 0; i < lists.Count; i++)
            {
                var l = lists[i];
                lstOptions.Add(new OptionList { ListId = l.ListId, ListValue = l.ListValue, ListDesc = l.ListDesc });


                if (i == lists.Count - 1 || !lists[i + 1].ListId.Equals(l.ListId))
                {
                    dicListOptions[l.ListId] = lstOptions;
                    lstOptions = new List<OptionList>();
                    lstId = l.ListId;
                }

            }
        }

        public List<OptionList> RetrieveById(OptionList option)
        {
            try
            {
                if (option.ListId.Equals("LST_NIVELES"))
                {
                    var crudNivel = new NivelCrudFactory();
                    var lst = crudNivel.RetrieveAll<Nivel>();

                    var lstResult = new List<OptionList>();

                    foreach (var c in lst)
                    {
                        var newOption = new OptionList { ListId = option.ListId, ListValue = c.IdNivel, ListDesc = c.Nombre };

                        lstResult.Add(newOption);
                    }
                    return lstResult;
                }
                else if (option.ListId.Equals("LST_SECCIONES"))
                {
                    var crudSeccion = new SeccionCrudFactory();
                    var lst = crudSeccion.RetrieveAll<Seccion>();

                    var lstResult = new List<OptionList>();

                    foreach (var c in lst)
                    {
                        var newOption = new OptionList { ListId = option.ListId, ListValue = c.IdSeccion, ListDesc =  c.Nombre };
                        lstResult.Add(newOption);
                    }
                    return lstResult;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return new List<OptionList>(); ;
        }


    }
}
