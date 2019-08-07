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

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence
    {
        private int _dimension = 0;
        private Lazy<Dictionary<int, VanDerCorputSequence>> _baseSequences;

        public HaltonSequence(int dimension)
        {
            _dimension = dimension;
            _baseSequences = new Lazy<Dictionary<int, VanDerCorputSequence>>( () => new Dictionary<int, VanDerCorputSequence>());
        }

        public IEnumerable<List<double>> GetSequence()
        {
            InitializeBases();

            long iSequenceIndex = 0L;
            while (iSequenceIndex < long.MaxValue)
            {
                List<double> result = new List<double>();
                for (int i = 1; i <= _dimension; i++)
                {
                    var value = _baseSequences.Value[i].Compute(iSequenceIndex).ToDouble();
                    result.Add(value);
                }
                yield return result;
                iSequenceIndex++;
            }
        }

        private void InitializeBases()
        {
            for (int dimensionIndex = 1; dimensionIndex <= _dimension; dimensionIndex++)
            {
                _baseSequences.Value.Add(dimensionIndex, new VanDerCorputSequence(dimensionIndex+1));
            }
        }
    }
}