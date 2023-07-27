using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_API
{   //TODO: ApplicationMessage debe cargarse en el proyecto Exception
    public class ApplicationMessageManager : BaseManager
    {
        private Dictionary<int, List<ApplicationMessage>> dicApplicatioMessages;
        private static ApplicationMessageManager _instance;

        //private ApplicationMessageCrudFactory crudApplicationMessage;

        public ApplicationMessageManager()
        {
            LoadDictionary();
            //crudApplicationMessage = new ApplicationMessageCrudFactory();
        }

        public static ApplicationMessageManager GetInstance()
        {
            if (_instance == null)
                _instance = new ApplicationMessageManager();

            return _instance;
        }

        private void LoadDictionary()
        {
            dicApplicatioMessages = new Dictionary<int, List<ApplicationMessage>>();
            
            var crudApplicationMessage = new ApplicationMessageCrudFactory();

            var lists = crudApplicationMessage.RetrieveAll<ApplicationMessage>();

            var lstId = lists[0].Id;
            var applicationMessage = new List<ApplicationMessage>();

            for (int i = 0; i < lists.Count; i++)
            {
                var l = lists[i];
                applicationMessage.Add(new ApplicationMessage { Id = l.Id, MessageText = l.MessageText });

                if (i == lists.Count - 1 || !lists[i + 1].Id.Equals(l.Id))
                {
                    dicApplicatioMessages[l.Id] = applicationMessage;
                    applicationMessage = new List<ApplicationMessage>();
                    lstId = l.Id;
                }

            }
        }

        public List<ApplicationMessage> RetrieveById(ApplicationMessage message)
        {
            try
            {
                if (dicApplicatioMessages.ContainsKey(message.Id))
                {
                    return dicApplicatioMessages[message.Id];
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return new List<ApplicationMessage>(); ;
        }

    }
}
