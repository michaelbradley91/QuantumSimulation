using System.Numerics;

namespace QuantumSimulation
{
    public static class BaseStates
    {
        public static Qubit KetZero = new Qubit(Complex.One, Complex.Zero); // |0>
        public static Qubit KetOne = new Qubit(Complex.Zero, Complex.One); // |1>
    }
}
