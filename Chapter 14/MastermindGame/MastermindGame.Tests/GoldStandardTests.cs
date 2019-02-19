using System;
using System.Collections.Generic;
using Xunit;

namespace MastermindGame.Tests
{
    public class GoldStandardTests
    {
        [Fact]
        public void StandardTestRun()
        {
            // Arrange
            var inout = new MockInputOutput();
            var rand = new MockRandomGenerator();
            var game = new Mastermind(inout, rand);

            // Arrange - Inputs
            rand.SetLetters('A', 'B', 'C', 'F');
            inout.InFeed.Enqueue("AAA");
            inout.InFeed.Enqueue("AAAA");
            inout.InFeed.Enqueue("ABBB");
            inout.InFeed.Enqueue("ABCC");
            inout.InFeed.Enqueue("ABCD");
            inout.InFeed.Enqueue("ABCF");
            inout.InFeed.Enqueue(" ");

            // Arrange - Outputs
            var expectedOutputs = new Queue<string>();
            expectedOutputs.Enqueue("Take a guess: ");
            expectedOutputs.Enqueue("Password length is 4." + Environment.NewLine);
            expectedOutputs.Enqueue("Take a guess: ");
            expectedOutputs.Enqueue("+---" + Environment.NewLine);
            expectedOutputs.Enqueue("Take a guess: ");
            expectedOutputs.Enqueue("++--" + Environment.NewLine);
            expectedOutputs.Enqueue("Take a guess: ");
            expectedOutputs.Enqueue("+++-" + Environment.NewLine);
            expectedOutputs.Enqueue("Take a guess: ");
            expectedOutputs.Enqueue("+++" + Environment.NewLine);
            expectedOutputs.Enqueue("Take a guess: ");
            expectedOutputs.Enqueue("++++" + Environment.NewLine);
            expectedOutputs.Enqueue("Congratulations you guessed the password in 6 tries." + Environment.NewLine);

            // Act
            game.Play();

            // Assert
            inout.OutFeed.ForEach(text =>
            {
                Assert.Equal(expectedOutputs.Dequeue(), text);
            });
        }
    }
}
