﻿using System;

namespace AmericanOptions.Model
{
   [Serializable]
    public class BtResult
    {
        public IntegralPoint IntegralPointD1;
        public IntegralPoint IntegralPointD2;
        public double Distribution;
        public IntegralFunction IntegralFunction;
        public double a;
        public Result Result;

        public BtResult()
        {
            Result = new Result();
        }
    }
}