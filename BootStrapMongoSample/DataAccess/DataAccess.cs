using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Models;
using System.Configuration;
using System.Web.Management;
using System.IO;

namespace DataAccess
{
    public class DataAccess
    {
        public List<Exercise> GetExerciseCollection()
        {
            var modelExercises = new List<Exercise>();

            try
            {

                //var mongoConnectionString = ConfigurationManager.AppSettings["MONGOLAB_URI"].ToString();
                //var login = ConfigurationManager.AppSettings["login"].ToString();
                //var password = ConfigurationManager.AppSettings["password"].ToString();
                //MongoServer mongo = MongoServer.Create(mongoConnectionString);
                //MongoCredentials mc = new MongoCredentials(login, password);

                //new LogEvent(string.Format("mongolab_uri:  {0}{1}login:  {2}{1}password{3}{1}", mongoConnectionString, Environment.NewLine, login, password)).Raise();    





                //MongoServer mongo = MongoServer.Create("mongodb://199.141.41.138:27017");
                //MongoServer mongo = MongoServer.Create("mongodb://192.168.0.3:27017");
                //var workout = mongo.GetDatabase("workout");
                //below is for mongolab
                //mongodb://appharbor_bc09b46d-eeb1-4970-b1dc-0a0774e058d6:lhf6utmuo44u29fv66353pd4q5@ds037607-a.mongolab.com:37607/appharbor_bc09b46d-eeb1-4970-b1dc-0a0774e058d6
                MongoServer mongo = MongoServer.Create("mongodb://appharbor_bc09b46d-eeb1-4970-b1dc-0a0774e058d6:lhf6utmuo44u29fv66353pd4q5@ds037607-a.mongolab.com:37607/appharbor_bc09b46d-eeb1-4970-b1dc-0a0774e058d6");
                MongoCredentials mc = new MongoCredentials("tvoglund", "Bela%Kavi_1");



                var workout = mongo.GetDatabase("appharbor_bc09b46d-eeb1-4970-b1dc-0a0774e058d6", mc);
                //end of monglab
                var exerciseCollection = workout.GetCollection("exercise");
                var exercises = workout.GetCollection("exercise").FindAllAs<ExerciseInternal>().ToList();

                mongo.Disconnect();

                foreach (var exercise in exercises)
                {
                    modelExercises.Add(Maps.Map(exercise));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return modelExercises;
        }

        public class LogEvent : WebRequestErrorEvent
        {
            public LogEvent(string message)
                : base(null, null, 100001, new Exception(message))
            {
            }
        }
    }
}
