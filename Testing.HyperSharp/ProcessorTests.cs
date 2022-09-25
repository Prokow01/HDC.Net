using System.Collections.Generic;
using FluentAssertions;
using HyperSharp;

namespace Testing.HyperSharp {
    public class ProcessorTests {
        private List<int[][]> _TrainLabels;
        private List<int[][]> _TrainData;
        private List<int[][]> _TestLabels;
        private List<int[][]> _TestData;
        
        public IdxHelper IdxHelper = new IdxHelper();
        
        [Fact]
        public void TestIdxDataLoad() {
            _TrainLabels = IdxHelper.FetchTrainLabels();

            _TrainLabels.Count.Should().BePositive();
        }
        
    }
}

