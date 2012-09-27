using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Models;
using System.Configuration;

namespace DataAccess
{
    public class DataAccess
    {
        public List<Exercise> GetExerciseCollection()
        {
            var modelExercises = new List<Exercise>();

            var mongoConnectionString = ConfigurationManager.AppSettings["MONGOLAB_URI"].ToString();
            var login = ConfigurationManager.AppSettings["login"].ToString();
            var password = ConfigurationManager.AppSettings["password"].ToString();

            MongoServer mongo = MongoServer.Create(mongoConnectionString);
            MongoCredentials mc = new MongoCredentials(login,password);
            var workout = mongo.GetDatabase("appharbor_bc09b46d-eeb1-4970-b1dc-0a0774e058d6", mc);
            //end of monglab
            var exerciseCollection = workout.GetCollection("exercise");
            var exercises = workout.GetCollection("exercise").FindAllAs<ExerciseInternal>().ToList();

            mongo.Disconnect();

            foreach (var exercise in exercises)
            {
                modelExercises.Add(Maps.Map(exercise));
            }

            return modelExercises;
        }
    }
}
