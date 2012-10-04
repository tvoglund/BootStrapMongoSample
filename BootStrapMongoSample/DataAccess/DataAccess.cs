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
        public string DbConnectionString = ConfigurationManager.AppSettings["MONGOLAB_URI"].ToString();
        public string DbLogin = ConfigurationManager.AppSettings["login"].ToString();
        public string DbPassword = ConfigurationManager.AppSettings["password"].ToString();
        public string DbName = ConfigurationManager.AppSettings["database"].ToString();



        public string DbLocation = "Cloud";
        public string CreatePassword = "aa4520c2-ca79-4757-be8a-59277c5a2b3e";

        public List<Exercise> GetExerciseCollection()
        {
            var modelExercises = new List<Exercise>();

            MongoServer mongo = MongoServer.Create(DbConnectionString);
            try
            {
                MongoDatabase database = null;

                if (DbLocation.Equals("Local"))
                {
                    database = mongo.GetDatabase("workout");
                }
                else
                {
                    //below is for mongolab
                    MongoCredentials mc = new MongoCredentials(DbLogin, DbPassword);
                    database = mongo.GetDatabase(DbName, mc);
                    //end of monglab
                }

                var exerciseCollection = database.GetCollection("exercise");
                var exercises = database.GetCollection("exercise").FindAllAs<ExerciseInternal>().ToList();
                foreach (var exercise in exercises)
                {
                    modelExercises.Add(Maps.Map(exercise));
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                mongo.Disconnect();
            }

            return modelExercises;
        }

        public Exercise CreateExerciseCollection(Exercise exercise)
        {
            var exerciseResponse = new Exercise();

            if (exercise.CreatePassword == CreatePassword)
            {

                MongoServer mongo = MongoServer.Create(DbConnectionString);
                try
                {
                    MongoDatabase database = null;

                    if (DbLocation.Equals("Local"))
                    {
                        database = mongo.GetDatabase("workout");
                    }
                    else
                    {
                        //below is for mongolab
                        MongoCredentials mc = new MongoCredentials(DbLogin, DbPassword);
                        database = mongo.GetDatabase(DbName, mc);
                        //end of monglab
                    }

                    MongoCollection<ExerciseInternal> exercises = database.GetCollection<ExerciseInternal>("exercise");
                    var exerciseInternal = new ExerciseInternal();
                    exerciseInternal = Maps.Map(exercise);
                    //var result = exercises.Insert(exerciseInternal);
                }
                catch (Exception ex)
                {
                    //TODO:  Add some logging...
                }
                finally
                {
                    mongo.Disconnect();
                }
            }


            return exercise;
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
