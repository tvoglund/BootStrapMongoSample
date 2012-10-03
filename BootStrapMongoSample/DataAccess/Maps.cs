using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Utilities;

namespace DataAccess
{
    internal static class Maps
    {
        internal static Exercise Map(ExerciseInternal exerciseIn)
        {
            Exercise exOut = new Exercise();
            exOut = Mapper.Map<ExerciseInternal, Exercise>(exerciseIn);
            exOut.setNumber = exerciseIn.set;  //note this is setNumber because set is used in ember.js
            exOut.Id = exerciseIn.Id.ToString();
            return exOut;
        }

        internal static ExerciseInternal Map(Exercise exerciseIn)
        {
            ExerciseInternal exOut = new ExerciseInternal();
            exOut = Mapper.Map<Exercise, ExerciseInternal>(exerciseIn);
            exOut.set = exerciseIn.setNumber;
            return exOut;
        }
    }
}