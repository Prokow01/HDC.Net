namespace HyperSharp.Datamodel {
    /// <summary>
    /// Notes: turn into VectorOps class or something
    /// </summary>
    public class HyperVector {
        public int Dimensions { get; set; }

        /// <summary>
        /// The base class, this should have up to thousands of dimensions and basic operations. todo override + and * operators
        /// </summary>
        public HyperVector(int dimensions=10000) {
            Dimensions = dimensions;
        }

        /// <summary>
        /// Bind Operation
        /// </summary>
        /// <returns></returns>
        public HyperVector Bind(HyperVector other) {
            return null;
        }

        /// <summary>
        /// Bundle operation (essentially exclusive or (XOR))
        /// </summary>
        /// <returns></returns>
        public HyperVector Bundle(HyperVector other) {
            return null;
        }

        /// <summary>
        /// dotcompare; over ==
        /// </summary>
        /// <returns></returns>
        public bool IsOrthagonal(HyperVector other) {
            return false;
        }
    }
}