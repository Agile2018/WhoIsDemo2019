using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    class HearUserPresenter
    {
        #region variables        
        IDisposable subscriptionUser;        
        private List<int> idVideos = new List<int>();
        public Subject<Person> subjectUser = new Subject<Person>();
        
        public List<int> IdVideos { get => idVideos; set => idVideos = value; }

        #endregion

        #region methods

        public HearUserPresenter()
        {           
            SubscriptionReactive();
        }

        private void SubscriptionReactive()
        {
            subscriptionUser = HearUser.Instance.subjectUser.Subscribe(
                usr => LaunchUser(usr), 
                () => Console.WriteLine("Operation Completed."));
        }

        private void LaunchUser(string user)
        {
            Person person;
            try
            {
                
                person = JsonConvert.DeserializeObject<Person>(user);
                if (person != null)
                {
                    int idVid = Convert.ToInt16(person.Params.Client);

                    if (idVideos.Count > 0 && idVideos.Contains(idVid))
                    {
                        subjectUser.OnNext(person);
                    }
                }                                                             
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EnableObserverUser()
        {

            if (!AipuFace.Instance.IsObserverUser())
            {
                AipuFace.Instance.EnableObserverUser();
            }

        }

        #endregion
    }
}
