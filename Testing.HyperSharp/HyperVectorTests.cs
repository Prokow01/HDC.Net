// HyperSharp/Testing.HyperSharp/HyperVectorTests.cs
// 
// 
// Created: 2022-07-16
// Created By: Peter Rokowski
// 
// Last Modified: 2022-07-16
// By: Peter Rokowski

using System;
using FluentAssertions;
using HyperSharp.Datamodel;

namespace Testing.HyperSharp {
    /// <summary>
    /// Tests for the basic HyperVector Class
    /// </summary>
    public class HyperVectorTests {

        /// <summary>
        /// Basic tests that the structure operates as expected
        /// </summary>
        [Fact]
        public void EqualityTests() {
            int vectorSize = 10;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize, false);
            
            // check the simple initialization
            for (int i = 0; i < vectorSize; i++) {
                a.Get(i).Should().Be(0);
                b.Get(i).Should().Be(0);
            }

            // check dimensions
            a.Dimensions.Should().Be(vectorSize);
            a.Dimensions.Should().Be(b.Dimensions);
            
            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            
            a.Set(setValue);
            b.Set(setValue);
            
            // check the new Values
            for (int i = 0; i < vectorSize; i++) {
                a.Get(i).Should().Be(b.Get(i));
            }

            // do the final check that these do in fact equal
            bool hyperVectorsEqual = a.Equals(b);
            hyperVectorsEqual.Should().BeTrue();
        }
        
        /// <summary>
        /// basic tests for inequality; based on vectorSize
        /// </summary>
        [Fact]
        public void EqualityTests_SizeMistmatch() {
            int vectorSize = 10;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize+1, false);

            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            
            a.Set(setValue);
            b.Set(setValue);
            
            // check the new Values
            for (int i = 0; i < vectorSize; i++) {
                a.Get(i).Should().Be(b.Get(i));
            }

            // do the final check that these do in fact equal
            bool hyperVectorsAreEqual = a.Equals(b);
            hyperVectorsAreEqual.Should().BeFalse();
        }
        
        /// <summary>
        /// basic tests for inequality; based on vector values
        /// </summary>
        [Fact]
        public void EqualityTests_VectorsMistmatch() {
            int vectorSize = 10000;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize, false);

            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            int[] setValue2 = { 1, -1, 1, 1, 1, 1, 1, -1, 1, -1 };
            
            a.Set(setValue);
            b.Set(setValue2);

            // do the final check that these do in fact equal
            bool hyperVectorsAreEqual = a.Equals(b);
            hyperVectorsAreEqual.Should().BeFalse();
        }

        /// <summary>
        /// The idea is that for sufficiently large HyperVectors, randomly generated ones will be orthogonal always.
        /// </summary>
        [Fact]
        public void OrthogonalityTest_Simple() {
            int vectorSize = 100;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize, false);
            a.Equals(b).Should().BeTrue();
            
            a.InitializeBinary();
            b.InitializeBinary();
            a.Equals(b).Should().BeFalse();
        }
        
        /// <summary>
        /// The idea is that for sufficiently large HyperVectors, randomly generated ones will be orthogonal always.
        /// </summary>
        [Fact]
        public void OrthogonalityTest_Complex() {
            HyperVector a = new HyperVector(10000, false);
            HyperVector b = new HyperVector(10000, false);
            a.Equals(b).Should().BeTrue();

            // these HyperVectors should never realistically intersect 
            int Simulations = 10000;
            for (int i = 0; i < Simulations; i++) {
                a.InitializeBinary();
                b.InitializeBinary();
                a.Equals(b).Should().BeFalse();  
            }
        }

        /// <summary>
        /// Simple binding operation (addition)
        /// </summary>
        [Fact]
        public void BindTest() {
            int vectorSize = 10;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize, false);

            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, -1 };
            int[] setValue2 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            
            a.Set(setValue);
            b.Set(setValue2);

            a.Bind(b).Should().BeTrue();
            
            int[] expectedValues = new int[10] { 2, 0, 2, 2, 2, 2, 2, 0, 2, 0 };
            for (int i = 0; i < vectorSize; i++) {
                a.Get(i).Should().Be(expectedValues[i]);
            }
        }
        
        /// <summary>
        /// Simple binding operation (addition)
        /// </summary>
        [Fact]
        public void BindTest_IncompatibleVectors() {
            int vectorSize = 10;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize+1, false);

            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            int[] setValue2 = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            
            a.Set(setValue);
            b.Set(setValue2);

            a.Bind(b).Should().BeFalse();
            
            int[] expectedValues = new int[10] { 2, 0, 2, 2, 2, 2, 2, 0, 2, 0 };
            for (int i = 0; i < vectorSize; i++) {
                a.Get(i).Should().NotBe(expectedValues[i]);
            }
        }

        [Fact]
        public void BundleTest() {
            int vectorSize = 10;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize, false);

            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            int[] setValue2 = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };

            a.Set(setValue);
            b.Set(setValue2);
            
            HyperVector c = a.Bundle(b);

            for (int i = 0; i < vectorSize; i++) {
                c.Get(i).Should().Be(1);
            }
        }
        
        [Fact]
        public void BundleTest_IncompatibleVectors() {
            int vectorSize = 10;
            HyperVector a = new HyperVector(vectorSize, false);
            HyperVector b = new HyperVector(vectorSize+1, false);

            int[] setValue = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1 };
            int[] setValue2 = { 1, -1, 1, 1, 1, 1, 1, -1, 1, 1, -1 };

            a.Set(setValue);
            b.Set(setValue2);
            
            a.Invoking(y => a.Bundle(b))
             .Should().Throw<Exception>()
             .WithMessage("Vectors are not compatible");
        }
    }
}