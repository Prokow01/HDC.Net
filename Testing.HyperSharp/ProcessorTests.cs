using System.Collections.Generic;
using FluentAssertions;
using HyperSharp;
using HyperSharp.MNIST;

namespace Testing.HyperSharp {
    public class ProcessorTests {
        
        private static readonly string Train_Labels_Path = @"../../../../HyperSharp/MNIST/train-labels.idx1-ubyte";
        private static readonly string Train_Data_Path = @"../../../../HyperSharp/MNIST/train-images.idx3-ubyte";
        private static readonly string Test_Labels_Path = @"../../../../HyperSharp/MNIST/t10k-labels.idx1-ubyte";
        private static readonly string Test_Data_Path = @"../../../../HyperSharp/MNIST/t10k-images.idx3-ubyte";
        
        // public IdxHelper IdxHelper = new IdxHelper();
        private List<MnistDigit> _trainData = IdxHelper.FetchMnistSet(Train_Data_Path, Train_Labels_Path);
        private List<MnistDigit> _testData = IdxHelper.FetchMnistSet(Test_Data_Path, Test_Labels_Path);
        
        [Fact]
        public void IdxLoadDataTest() {
            _trainData.Count.Should().Be(60000);
            _testData.Count.Should().Be(10000);
        }
        
    }
}

