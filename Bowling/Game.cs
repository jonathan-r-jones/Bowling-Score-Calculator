using System;
using System.Collections.Generic;

namespace Bowling
{
    public class Game
    {
        public List<Frame> Frames { get; set; }
        private string _filename;
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public Game(string filename)
        {
            _filename = filename;
        }
        public Game()
        {
        }
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
        public int Score()
        {
            var score = 0;
            var rollIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (FrameIsStrike(rollIndex))
                {
                    score += 10 + ScoreStrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (FrameIsSpare(rollIndex))
                {
                    score += 10 + ScoreSpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += ScoreRegularFrame(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }
        private bool FrameIsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
        private bool FrameIsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }
        private int ScoreStrikeBonus(int rollIndex)
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }
        private int ScoreSpareBonus(int rollIndex)
        {
            return rolls[rollIndex + 2];
        }
        private int ScoreRegularFrame(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
        public void PrintScoreFrames2()
        {
            LoadFrames();
            Console.Write("frame\t");
            Console.Write("roll 1\t");
            Console.Write("roll 2\t");
            Console.Write("roll 3\t");
            Console.Write("isMark \t");
            Console.Write("isStrike \t");
            Console.Write("isSpare \t");
            Console.WriteLine("Score");

            var score = 0;
            var rollIndex = 0;
            foreach (var frame in Frames)
            {
                if (FrameIsStrike(rollIndex))
                {
                    score += 10 + ScoreStrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (FrameIsSpare(rollIndex))
                {
                    score += 10 + ScoreSpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += ScoreRegularFrame(rollIndex);
                    rollIndex += 2;
                }
                Console.Write(frame.Number);
                Console.Write("\t" + frame.FirstRoll);
                Console.Write("\t" + frame.SecondRoll);
                Console.Write("\t" + frame.ThirdRoll);
                Console.Write("\t" + frame.IsMark);
                Console.Write("\t" + frame.IsStrike);
                Console.Write("\t" + frame.IsSpare);
                Console.WriteLine("\t" + score);
            }
        }
        public void LoadFrames()
        {
            Frames = new List<Frame>();
            FileProcess fileProcess = new FileProcess();
            List<int> rolls2 = fileProcess.GetRolls(_filename);
            Frame frame = new Frame();
            int frameNumber = 1;
            bool firstRollInFrame = true;
            bool isThirdBall = false;
            foreach (var roll in rolls2)
            {
                this.Roll(roll);
                //qq
                if (firstRollInFrame)
                {
                    frame.FirstRoll = roll;
                    firstRollInFrame = false;
                    frame.IsSpare = false;
                    if (roll == 10)
                    {
                        frame.IsStrike = true;
                        frame.IsMark = true;
                        if (frameNumber != 10)
                        {
                            frame.Number = frameNumber;
                            Frames.Add(frame);
                            firstRollInFrame = true;
                            frame = new Frame();
                            frameNumber++;
                            frame.Number = frameNumber;
                        }
                    }
                    else
                    {
                        frame.IsStrike = false;
                    }
                }
                else
                {
                    if (frameNumber == 10)
                    {
                        if (!isThirdBall)
                        {
                            frame.SecondRoll = roll;
                            isThirdBall = true;
                            if (!frame.IsMark)
                            {
                                Frames.Add(frame);
                                firstRollInFrame = true;
                            }
                        }
                        else
                        {
                            frame.ThirdRoll = roll;
                            frame.Number = frameNumber;
                            Frames.Add(frame);
                            firstRollInFrame = true;
                        }
                    }
                    else
                    {
                        frame.SecondRoll = roll;
                        if (frame.FirstRoll + frame.SecondRoll == 10)
                        {
                            frame.IsMark = true;
                            frame.IsSpare = true;
                        }
                        else
                        {
                            frame.IsMark = false;
                            frame.IsSpare = false;
                        }
                        frame.Number = frameNumber;
                        Frames.Add(frame);
                        firstRollInFrame = true;
                        frame = new Frame();
                        frameNumber++;
                        frame.Number = frameNumber;
                    }
                }
            }
        }
    }
}
