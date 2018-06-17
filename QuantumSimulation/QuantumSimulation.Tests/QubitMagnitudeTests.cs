using System;
using System.Numerics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuantumSimulation.Tests
{
    [TestClass]
    public class QubitMagnitudeTests
    {
        [TestMethod]
        public void KetOne_HasTotalProbabilityOne()
        {
            var qubit = BaseStates.KetOne;

            var totalProbability = GetTotalProbability(qubit);

            totalProbability.Should().Be(1);
        }

        [TestMethod]
        public void KetZero_HasTotalProbabilityOne()
        {
            var qubit = BaseStates.KetZero;

            var totalProbability = GetTotalProbability(qubit);

            totalProbability.Should().Be(1);
        }

        [TestMethod]
        public void Qubit_GivenNormalisedProbabilities_HasTotalProbabilityOne()
        {
            var qubit = new Qubit(new Complex(Math.Sqrt(2), 0), new Complex(Math.Sqrt(2), 0));

            var totalProbability = GetTotalProbability(qubit);

            totalProbability.Should().BeApproximately(1, 0.0000000001);
        }

        [TestMethod]
        public void Qubit_GivenNonNormalisedProbabilities_HasTotalProbabilityOne()
        {
            var qubit = new Qubit(new Complex(100, 0), new Complex(-2913, 0));

            var totalProbability = GetTotalProbability(qubit);

            totalProbability.Should().BeApproximately(1, 0.0000000001);
        }


        private double GetTotalProbability(Qubit qubit)
        {
            var horizontal = qubit.Horiztonal.Magnitude;
            var vertical = qubit.Vertical.Magnitude;

            var sum = horizontal * horizontal + vertical * vertical;
            return sum;
        }
    }
}
