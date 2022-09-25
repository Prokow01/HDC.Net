// HyperSharp/HyperSharp/MnistDigit.cs
// 
// 
// Created: 2022-09-24
// Created By: Peter Rokowski
// 
// Last Modified: 2022-09-24
// By: Peter Rokowski

using System;

namespace HyperSharp.MNIST {
    public class MnistDigit {
        public int Label { get; set; }
        public int[][] Pixels { 
            get;
            set;
        }
    }
}