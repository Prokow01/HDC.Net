using System.Collections.Generic;
using HyperSharp.Datamodel;

namespace HyperSharp {
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
        }

        private void Init(int dimensions) {
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
        public HyperVector Encode(int[] image) {
            HyperVector rvEncodedImage = new HyperVector(_dimensions, false);
            for (int pixelIndex = 0; pixelIndex < image.Length; pixelIndex++) {
                int pixelValue = image[pixelIndex];
                HyperVector temp = _positionLookup[pixelIndex].Bundle(_grayscaleLookup[pixelValue]);
                rvEncodedImage.Bind(temp);
            }

            return rvEncodedImage;
        }

        /// <summary>
        /// Train an associative memory
        /// </summary>
        /// <param name="trainingImages"></param>
        /// <param name="trainingLabel"></param>
        public void Train(int[][] trainingImages, int[] trainingLabel) {
            for (int i = 0; i < trainingLabel.Length; i++) {
                int label = trainingLabel[i];
                int[] trainingImage = trainingImages[i];

                HyperVector encodedImage = Encode(trainingImage);
                
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