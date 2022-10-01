// HyperSharp/IdxHelper.cs
// 
// Created: 2022-09-24
// Created By: Peter Rokowski

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HyperSharp.MNIST;

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
        
        
        // public IdxHelper() {
        //     Train_Labels_Path = @"../../../../HyperSharp/MNIST/train-labels.idx1-ubyte";
        //     Train_Data_Path = @"../../../../HyperSharp/MNIST/train-images.idx3-ubyte";
        //     Test_Labels_Path = @"../../../../HyperSharp/MNIST/t10k-labels.idx1-ubyte";
        //     Test_Data_Path = @"../../../../HyperSharp/MNIST/t10k-images.idx3-ubyte";
        // }
        
        // private int _parseColumnCount(string path) {
        //     var tmp = path.Split(".");
        //     string t = tmp[tmp.Length-1].Split("-")[0];
        //     int rv = Int32.Parse($"{t[3]}");
        //     
        //     return rv;
        // }
        
        public static List<MnistDigit> FetchMnistSet(string dataFilePath, string labelFilePath) {
            List<MnistDigit> rv = new List<MnistDigit>();
            
            using (BinaryReader dataRead = new BinaryReader(new FileStream(dataFilePath, FileMode.Open))) {
                using (BinaryReader labelRead = new BinaryReader(new FileStream(labelFilePath, FileMode.Open))) {
                
                    int magic1 = ReadBigInt32(dataRead); // discard
                    int numImages = ReadBigInt32(dataRead);  
                    int numRows = ReadBigInt32(dataRead); 
                    int numCols = ReadBigInt32(dataRead); 

                    int magic2 = ReadBigInt32(labelRead); 
                    int numLabels = ReadBigInt32(labelRead);

                    if (numImages != numLabels) {
                        throw new Exception("Incorrect count of images vs labels!!");
                    }
                    
                    var tmp = new int[numRows][];
                    for (int i = 0; i < numRows; i++) {
                        tmp[i] = new int[numCols];
                    }
                    
                    for (int k = 0; k < numLabels; k++) {
                    
                        for (int i = 0; i < numRows; ++i)
                        {
                            for (int j = 0; j < numCols; ++j)
                            {
                                tmp[i][j] = dataRead.ReadByte();
                            }
                        }

                        byte label = labelRead.ReadByte();
                        
                        rv.Add(new MnistDigit() {
                            Pixels = tmp,
                            Label = label
                        });
                    }
                }        
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
        
        
        // public List<MnistDigit> FetchTrainSet() {
        //     return _ReadIdxFiles(Train_Data_Path, Train_Labels_Path);
        // }
        // public List<MnistDigit> FetchTestSet() {
        //     return _ReadIdxFiles(Test_Data_Path, Test_Labels_Path);
        // }
    }
}