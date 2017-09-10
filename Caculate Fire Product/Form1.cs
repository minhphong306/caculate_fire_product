using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculate_Fire_Product {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            double vo = calcVO(so_lieu[0], so_lieu[1], so_lieu[2], so_lieu[4]);
        }

        public string[] tt = { "cp", "hp", "op", "np", "sp", "ap", "wp" };
        public double[] so_lieu = { 69, 2.65, 2.29, 0.88, 0.6, 15, 9 };

        double calcVO(double cp, double hp, double op, double sp) {
            double result = 0;
            result = 0.089 * cp + 0.264 * hp - 0.0333 * (op - sp);
            return result;
        }

        double calcVt(double va) {
            double result = 0;
            result = 1.2 * va;
            return result;
        }

        double calcVso2() {
            double result = 0;
            result = 0.683 * Math.Pow(10, -2) * 0.6;
            return result;
        }

        double calcVco(double cp) {
            double result = 0;
            result = 1.865 * Math.Pow(10, -2) * 0.09 * cp;
            return result;
        }


        double calcVco2(double cp) {
            double result = 0;
            result = 1.853 * Math.Pow(10, -2) * (1 - 0.03);
            return result;
        }

        double calcVh2o(double hp, double wp, double d, double vt) {
            double result = 0;
            result = 0.111 * hp + 0.124 * wp + 0.0016 * d * vt;
            return result;
        }

        double calcVo2(double va) {
            double result = 0;
            result = 0.21 * (1.2 - 1) * va;
            return result;
        }
        double calcVspc(double VSO2, double VCO, double vco2, double vh2o, double vn2, double vo2) {
            double result = 0;
            result = VSO2 + VCO + vco2 + vh2o + vn2 + vo2;
            return result;
        }

        double calcLc(double vspc, double B) {
            double result = 0;
            result = (vspc * B) / 3600;
            return result;
        }

        double calcMso2(double vso2, double B) {
            double result = 0;
            result = (Math.Pow(10, 3) * vso2 * B * 2.926) / 3600;
            return result;
        }

        double calcMco(double vco, double B) {
            double result = 0;
            result = (10000 * vco * B * 1.25) / 3600;
            return result;
        }

        double calcMco2(double vco, double B) {
            double result = 0;
            result = (10000 * vco * 28 * B * 1.977) / 3600;
            return result;
        }

        double calcMbui(double ap, double B) {
            double result = 0;
            result = (10 * 0.9 * ap * B) / 3600;
            return result;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            
        }
    }
}
