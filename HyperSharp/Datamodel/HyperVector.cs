using System;

namespace HyperSharp.Datamodel {
    /// <summary>
    /// Notes: turn into VectorOps class or something, also HyperVectors can exist in multiple polarities not just bipolar
    /// </summary>
    public class HyperVector {
        private readonly int[] _vector;
        public int Dimensions { get; }

        /// <summary>
        /// The base class, this should have up to thousands of dimensions and basic operations. todo override + and * operators
        /// </summary>
        public HyperVector(int dimensions=10000, bool initialize = true) {
            Dimensions = dimensions;
            _vector = new int[Dimensions];

            if (initialize)
                InitializeBinary();
        }

        private bool _VectorsAreCompatible(HyperVector otherVector) {
            return Dimensions == otherVector.Dimensions;
        }

        /// <summary>
        /// Debug operation for testing, should never really be used.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="index"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Set(int[] vector, int index = 0) {
            if (vector == null) {
                throw new ArgumentNullException(nameof(vector), "cannot be null");
            }
            
            if (vector.Length > Dimensions || vector.Length + index > Dimensions) {
                throw new Exception($"setting vector size and start point is too big for this Hypervector size {Dimensions} != {vector.Length} + {index} ");
            }

            // set the vector from the starting point; possibly more complicated than we need
            for (int i = 0; i < vector.Length; i++) {
                _vector[i] = vector[i + index];
            }
        }

        /// <summary>
        /// Gets the value of the hypervector at dimensional index (i)
        /// </summary>
        /// <param name="i">index to return</param>
        /// <returns></returns>
        public int Get(int i) {
            return _vector[i];
        }

        /// <summary>
        /// Bind Operation
        /// </summary>
        /// <returns></returns>
        public bool Bind(HyperVector other) {
            if (!_VectorsAreCompatible(other)) {
                return false;
            }

            for (int i = 0; i < Dimensions; i++) {
                _vector[i] += other.Get(i);
            }

            return true;
        }

        /// <summary>
        /// Bundle operation (essentially exclusive or (XOR))
        /// </summary>
        /// <returns></returns>
        public HyperVector Bundle(HyperVector other) {
            throw new NotImplementedException();
        }
        

        /// <summary>
        /// dotcompare; over ==
        /// </summary>
        /// <returns></returns>
        public bool Equals(HyperVector other) {
            if (Dimensions != other.Dimensions)
                return false;
                // throw new Exception($"hypervectors are not of the same dimensions {Dimensions} != {other.Dimensions}");
                
            for (int i = 0; i < Dimensions; i++) {
                if (_vector[i] != other.Get(i))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Initialize the Vector with ones and Zeros
        /// </summary>
        public void InitializeBinary() {
            Random r = new();

            for (int i = 0; i < Dimensions; i++) {
                _vector[i] = (r.Next(0, 2)==0) ? -1 : 1;
            }
        }
    }
}