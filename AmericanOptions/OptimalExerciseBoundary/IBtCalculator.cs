﻿using AmericanOptions.Model;

namespace AmericanOptions.OptimalExerciseBoundary
{
    public interface IBtCalculator
    {
        BtResult CalculateBtK0(double k);
        BtResult CalculateBtK1(double r, double sigma, double t, double K, double S, int n, double T);
        BtResult CalculateBtK(double r, double sigma, double t, double K, double S, int n, double T, BtResult BtK_1);
    }
}