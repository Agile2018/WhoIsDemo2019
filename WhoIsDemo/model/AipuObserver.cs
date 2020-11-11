﻿using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Aipu2NetLib;

namespace WhoIsDemo.model
{
    public class AipuObserver: IDisposable
    {
        #region variables
        private AipuNet aipu;
        private string errorBiometrics;
        private string userJson;
        
        private IObservable<string> observableError;
        private IObservable<string> observableUser;
        
        IDisposable subscriptionUser;
        IDisposable subscriptionError;
        
        bool isHearObserverUser = false;
        
        public string ErrorBiometrics
        {
            get
            {
                return errorBiometrics;
            }

            set
            {
                errorBiometrics = value;
                OnError(errorBiometrics);
            }
        }

        public string UserJson
        {
            get
            {
                return userJson;
            }

            set
            {
                userJson = value;
                OnUser(userJson);
            }
        }        

        public bool IsHearObserverUser { get => isHearObserverUser; set => isHearObserverUser = value; }
        
        public delegate void MessageErrorDelegate(string error);
        public event MessageErrorDelegate OnError;
        public delegate void UserJsonDelegate(string dataUser);
        public event UserJsonDelegate OnUser;
        

        #endregion

        #region methods
        public AipuObserver(AipuNet workAipu)
        {
            this.aipu = workAipu;
            ObserverError();
            
            
        }

        ~AipuObserver()
        {
            this.aipu = null;
        }

        public void EnableObserverUser()
        {
            ObserverUser();            
            isHearObserverUser = true;
        }

        private void ObserverError()
        {
            observableError = Observable.Create<string>(async observer =>
            {
                observer.OnNext(await GetErrorAsync());
                
            });
            subscriptionError = observableError
                .Where(res => res != ErrorBiometrics && res != null)
                .Delay(TimeSpan.FromSeconds(1))
                .Repeat()
                .Subscribe(
                    res => ErrorBiometrics = res
                );
        }

        private Task<string> GetErrorAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    return aipu.GetError;
                }


                catch(System.NullReferenceException ex)
                {
                    Console.WriteLine("ERROR NULL AIPU " + ex.Message);
                }
                return null;
            });

        }

        private void ObserverUser()
        {
            observableUser = Observable.Create<string>(async observer =>
            {
                observer.OnNext(await GetUserAsync());
            });
            subscriptionUser = observableUser
                .Where(res => !string.IsNullOrEmpty(res))      // res != UserJson &&
                .Delay(TimeSpan.FromMilliseconds(5))
                .Repeat()
                .Subscribe(
                    res => UserJson = res
                ); //.Concat(Observable.Empty<string>().Delay(TimeSpan.FromSeconds(0.2)))

        }

        private Task<string> GetUserAsync()
        {
            return Task.Run(() =>
            {
                return aipu.GetUser;
            });
        }

        public void Dispose()
        {
            
            if (isHearObserverUser)
            {
                subscriptionUser.Dispose();
               
            }
            
            subscriptionError.Dispose();            
        }


        #endregion
    }
}
