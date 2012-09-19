﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Models;
using System.Configuration;
using System.Web.Management;

namespace DataAccess
{
    public class DataAccess
    {
        public List<Exercise> GetExerciseCollection()
        {
            var modelExercises = new List<Exercise>();

            var mongoConnectionString = ConfigurationManager.AppSettings["MONGOLAB_URI"].ToString();
            new LogEvent(string.Format("Mongolab {0}",mongoConnectionString)).Raise();
            var login = ConfigurationManager.AppSettings["login"].ToString();
            new LogEvent(string.Format("Email substring {0}", login)).Raise();
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

        public class LogEvent : WebRequestErrorEvent
        {
            public LogEvent(string message)
                : base(null, null, 100001, new Exception(message))
            {
            }
        }
    }
}
