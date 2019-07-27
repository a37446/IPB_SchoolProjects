using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using System.IO;
using EFCoreBloodBank.Classes;
using System.Collections.ObjectModel;
using A.pages;

namespace A.ViewModel
{
    public class Authentication
    {
        StorageFolder localFolder = ApplicationData.Current.LocalCacheFolder;
       // public bool flaG;
       public HomePage home { get; set; }


        private async Task<ObservableCollection<User>> getCurrentUser()
        {
            try
            {
                StorageFile user = await localFolder.GetFileAsync("Session.txt");
                string serializedUser = await FileIO.ReadTextAsync(user);
                ObservableCollection<User> deserializedUser = JsonConvert.DeserializeObject<ObservableCollection<User>>(serializedUser);
                return deserializedUser;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
            catch (IOException e)
            {
                return null;
            }
        }
        /*
        public int? getCurrentUserId()
        {
            Task<ObservableCollection<User>> currentUserTask = Task.Run(() => this.getCurrentUser());
            ObservableCollection<User> currentUser = currentUserTask.Result;
            int? currentUserId = currentUser != null ? currentUser.UserId : -1;
            return currentUserId;
        }

        public bool isCurrentUserAdmin()
        {
            Task<User> currentUserTask = Task.Run(() => this.getCurrentUser());
            User currentUser = currentUserTask.Result;
            return currentUser.isAdmin;
        }
        */

     
        private async Task<bool> writeSession(string serializedUser)
        {
            try
            {
                StorageFile user = await localFolder.CreateFileAsync("Session.txt", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(user, serializedUser);
                return true;
            }
            catch (FileNotFoundException e)
            {
                return false;
            }
            catch (IOException e)
            {
                return false;
            }

        }

        public bool login(ObservableCollection<User> ap)
        {
            //ap.Password = null;
            string serializedUser = JsonConvert.SerializeObject(ap);
            Task<bool> userSession = Task.Run(() => this.writeSession(serializedUser));
            return userSession.Result;
        }

        public async void logout()
        {
            try
            {
                StorageFile user = await localFolder.GetFileAsync("Session.txt");
                HomePage.isAd = false;
                await user.DeleteAsync();

            }
            catch (FileNotFoundException e)
            { }
            catch (IOException e)
            { }
        }
        
        public bool isUserLogin()
        {
            Task<ObservableCollection<User>> currentUserTask = Task.Run(() => this.getCurrentUser());
            ObservableCollection<User> currentUser = currentUserTask.Result;
            return currentUser != null;
        }
    }
}
