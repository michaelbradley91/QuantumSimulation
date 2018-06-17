using System.Numerics;

namespace QuantumSimulation
{
    public class Qubit
    {
        // The qubits polarisations
        public Complex Horiztonal { get; }
        public Complex Vertical { get; }

        public Qubit(Complex horizontal, Complex vertical)
        {
            // Normalise the values first
            var (normalisedHorizontal, normalisedVertical) = ComplexHelpers.Normalise(horizontal, vertical);

            Horiztonal = normalisedHorizontal;
            Vertical = normalisedVertical;
        }
    }
}
