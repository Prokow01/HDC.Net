using System.Collections.Generic;
using HyperSharp.Datamodel;

namespace HyperSharp {
    /// <summary>
    /// Really an MNIST processor, this needs to be extracted and abstracted away to make a little more general-purpose.
    /// </summary>
    public class Processor {
        private readonly Dictionary<int, HyperVector> _grayscaleLookup = new Dictionary<int, HyperVector>();
        private readonly Dictionary<int, HyperVector> _positionLookup = new Dictionary<int, HyperVector>();
        private readonly int _dimensions;
        
        private readonly Dictionary<int, HyperVector> _associativeMemory = new Dictionary<int, HyperVector>();


        /// <summary>
        /// Processor that handles basic HDC calculations
        /// </summary>
        public Processor(int dimensions) {
            _dimensions = dimensions;
            Init();
        }

        /// <summary>
        /// Initializes the Processor with a specific hyper-dimension
        /// </summary>
        private void Init() {
            // set up the grayscale color code 0 - 255
            for (int i = 0; i < 256; i++) {
                _grayscaleLookup[i] = new HyperVector(_dimensions);
            }
            
            // set up the pixel position table 28 * 28 = 784
            for (int i = 0; i < 784; i++) {
                _positionLookup[i] = new HyperVector(_dimensions);
            }
        }

        /// <summary>
        /// Encode an image into HyperVector
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public HyperVector Encode(int[][] image) {
            HyperVector rvEncodedImage = new HyperVector(_dimensions, false);

            for (int i = 0; i < image.Length; i++) {
                
            }
            
                // for (int j = 0; j < image[i].Length; j++) {
                //     
                // }
            // for (int pixelIndex = 0; pixelIndex < image.Length; pixelIndex++) {
            //     int pixelValue = image[pixelIndex];
            //     HyperVector temp = _positionLookup[pixelIndex].Bundle(_grayscaleLookup[pixelValue]);
            //     rvEncodedImage.Bind(temp);
            // }

            return rvEncodedImage;
        }

        /// <summary>
        /// Train an associative memory
        /// </summary>
        /// <param name="trainingImages"></param>
        /// <param name="trainingLabels"></param>
        public void Train(int[][][] trainingImages, int[] trainingLabels) {
            for (int i = 0; i < trainingLabels.Length; i++) {
                int label = trainingLabels[i];
                int[][] trainingImage = trainingImages[i];

                HyperVector encodedImage = Encode(trainingImage);

                if (!_associativeMemory.ContainsKey(label)) {
                    _associativeMemory[label] = new HyperVector();
                }
                _associativeMemory[label].Bind(encodedImage);
            }
        }
        
        public void Test() {
            
        }

        public void Predict() {
            
        }
        
        // read image and label
    }
}