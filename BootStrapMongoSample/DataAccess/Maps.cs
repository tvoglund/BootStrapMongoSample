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

            return exOut;
        }
    }
}