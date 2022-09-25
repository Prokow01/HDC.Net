// HyperSharp/IdxHelper.cs
// 
// Created: 2022-09-24
// Created By: Peter Rokowski

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HyperSharp {
    
    /// <summary>
    /// Class for formatting the Idx-Ubyte files that MNIST are stored in
    ///
    /// based on info from https://jamesmccaffrey.wordpress.com/2013/11/23/reading-the-mnist-data-set-with-c/
    /// </summary>
    public class IdxHelper {

        public string Train_Labels_Path;
        public string Train_Data_Path;
        public string Test_Labels_Path;
        public string Test_Data_Path;
        
        
        public IdxHelper() {
            Train_Labels_Path = @"../../../../HyperSharp/MNIST/train-labels.idx1-ubyte";
            Train_Data_Path = @"MNIST/train-zd.idx3-ubyte";
            Test_Labels_Path = @"MNIST/t10k-labels.idx1-ubyte";
            Test_Data_Path = @"MNIST/t10k-images.idx3-ubyte";
        }
        
        private int _parseColumnCount(string path) {
            var tmp = path.Split(".");
            string t = tmp[tmp.Length-1].Split("-")[0];
            int rv = Int32.Parse($"{t[3]}");
            
            return rv;
        }
        
        private List<int[][]> _ReadIdxFile(string filePath) {
            List<int[][]> rv = new List<int[][]>();

            int colCount = _parseColumnCount(filePath);

            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryReader binRead = new BinaryReader(fileStream);

            int[] metaData = new int[colCount];
            for (int i = 0; i < colCount; i++) {
                metaData[i] = ReadBigInt32(binRead);
            }
            
            return rv;
        }
        public static int ReadBigInt32(BinaryReader br)
        {
            var bytes = br.ReadBytes(sizeof(Int32));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public List<int[][]> FetchTrainData() {
            return _ReadIdxFile(Train_Data_Path);
        }
        public List<int[][]> FetchTrainLabels() {
            return _ReadIdxFile(Train_Labels_Path);
        }
        public List<int[][]> FetchTestData() {
            return _ReadIdxFile(Train_Data_Path);
        }
        public List<int[][]> FetchTestLabels() {
            return _ReadIdxFile(Train_Labels_Path);
        }
    }
}