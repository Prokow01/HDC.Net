using System.Collections.Concurrent;
using HyperSharp.Datamodel;

namespace HyperSharp; 

public class Encoder {
    
    private readonly ConcurrentDictionary<string, Dictionary<string, HyperVector>> _encodingScheme;

    /// <summary>
    /// The Encoding element
    /// </summary>
    public Encoder() {
        _encodingScheme = new ConcurrentDictionary<string, Dictionary<string, HyperVector>>();
    }

    /// <summary>
    /// Registers a new Encoding Scheme, assuming integer lookup values as labels
    /// </summary>
    /// <param name="label"></param>
    /// <param name="dimensionUpperLimit"></param>
    /// <param name="dimensionLowerLimit"></param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public void RegisterIndexBasedScheme(string label, int dimensionUpperLimit, int dimensionLowerLimit = 0) {

        if (dimensionLowerLimit >= dimensionUpperLimit) {
            throw new ArgumentException(
                $"Lower Limit {dimensionLowerLimit} must be less than Upper Limit {dimensionUpperLimit}");
        }
        
        if (!_encodingScheme.TryAdd(label, new Dictionary<string, HyperVector>())) {
            throw new Exception($"Could not add Label {label} to Encoder");
        }

        for (int i = dimensionLowerLimit; i <= dimensionUpperLimit; i++) {
            _encodingScheme[label][$"{i}"] = HyperVector.NewVector();
        }
    }

    /// <summary>
    /// Gets
    /// </summary>
    /// <param name="schemeName"></param>
    /// <param name="valueCode"></param>
    /// <returns></returns>
    public HyperVector Get(string schemeName, string valueCode) {
        return _encodingScheme[schemeName][valueCode];
    }

    /// <summary>
    /// Gets the whole encoding scheme todo make .CopyOf() implementation for safer lookups
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public Dictionary<string, HyperVector> GetScheme(string label) {
        return _encodingScheme[label];
    }
}