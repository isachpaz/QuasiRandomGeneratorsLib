
#region License and Terms
// QuasiRandomGeneratorsLib
// Copyright (c) 2019 Ilias. Sachpazidis. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace MyUtilsLib
{
    public static class MyUtils
    {
        public static IEnumerable<double> ToDouble(this IEnumerable<Tuple<long, long>> input)
        {
            foreach (Tuple<long, long> tuple in input)
            {
               yield return (double)tuple.Item1 / (double)tuple.Item2;
            }
            
        }

        public static double ToDouble(this Tuple<long, long> input)
        {
            return (double) input.Item1 / (double) input.Item2;
        }

        public static IEnumerable<Tuple<T1, T2>> ZipTwoEnumerable<T1, T2>(IEnumerable<T1> list1, IEnumerable<T2> list2)
        {
            foreach (var tuple in list1.Zip(list2, Tuple.Create))
            {
                yield return tuple;
            }
        }
    }
}