using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }

        /// <summary>
        /// создание нового контроллера
        /// </summary>
        /// <param name="user">пользователь приложениия</param>
        public UserController(string userName,string genderName,DateTime birthDay,double weight,double height)
        {
            //todo проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
            
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TO DO Что делать если пользователя не прочитали
            }
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
                
            }
        }
        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        
    }
}
