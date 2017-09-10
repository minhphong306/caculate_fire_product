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
    public partial class Form1 : Form
    {
        private double cp, hp, op, np, sp, ap, wp, B, d, H, tk;
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

        double calcVA(double vo, double d) {
            double result = 0;
            result = (1 + 0.0016 * d) * vo;
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

        private void Form1_Load(object sender, EventArgs e) {

        }

        double calcVh2o(double hp, double wp, double d, double vt) {
            double result = 0;
            result = 0.111 * hp + 0.124 * wp + 0.0016 * d * vt;
            return result;
        }

        double calcVN2(double np, double vt) {
            double result = 0;
            result = 0.8 * Math.Pow(10 , -2) * np + 0.79 * vt;
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

        double calcMco2(double vco2, double B) {
            double result = 0;
            result = (10000 * vco2 * B * 1.977) / 3600;
            return result;
        }

        double calcMbui(double ap, double B) {
            double result = 0;
            result = (10 * 0.9 * ap * B) / 3600;
            return result;
        }

        double calcLt(double Lc, double tk) {
            double result = 0;
            result = Lc * (273 + tk) / 273;
            return result;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            cp = double.Parse(txtCp.Text.Replace(".", ","));
            hp = double.Parse(txtHp.Text.Replace(".", ","));
            op = double.Parse(txtOp.Text.Replace(".", ","));
            np = double.Parse(txtNp.Text.Replace(".", ","));
            sp = double.Parse(txtSp.Text.Replace(".", ","));
            ap = double.Parse(txtAp.Text.Replace(".", ","));
            wp = double.Parse(txtWp.Text.Replace(".", ","));

            B = double.Parse(txtB.Text.Replace(".", ","));
            d = double.Parse(txtd.Text.Replace(".", ","));
            H = double.Parse(txtH.Text.Replace(".", ","));
            tk = double.Parse(txtTk.Text.Replace(".", ","));


            double VO = calcVO(cp, hp, op, sp);
            double VA = calcVA(VO, d);
            double VT = calcVt(VA);
            double VSO2 = calcVso2();
            double VCO = calcVco(cp);
            double VCO2 = calcVco2(cp);
            double Vh2o = calcVh2o(hp, wp, d, VT);
            double VN2 = calcVN2(np, VT);

            double Vo2 = calcVo2(VA);
            double VSPC = calcVspc(VSO2, VCO, VCO2, Vh2o, VN2, Vo2);
            double LC = calcLc(VSPC, B);
            double LT = calcLt(LC, tk);
            double MSO2 = calcMso2(VSO2, B);
            double MCO = calcMco(VCO, B);
            double MCO2 = calcMco2(VCO2, B);
            double Mbui = calcMbui(ap, B);

            double[] arr = new double[16];

            arr[0] = calcVO(cp, hp, op, sp);
            arr[1] = calcVA(VO, d);
            arr[2] = calcVt(VA);
            arr[3] = calcVso2();
            arr[4] = calcVco(cp);
            arr[5] = calcVco2(cp);
            arr[6] = calcVh2o(hp, wp, d, VT);
            arr[7] = calcVN2(np, VT);

            arr[8] = calcVo2(VA);
            arr[9] = calcVspc(VSO2, VCO, VCO2, Vh2o, VN2, Vo2);
            arr[10] = calcLc(VSPC, B);
            arr[11] = calcLt(LC, tk);
            arr[12] = calcMso2(VSO2, B);
            arr[13] = calcMco(VCO, B);
            arr[14] = calcMco2(VCO2, B);
            arr[15] = calcMbui(ap, B);

            var index = dgvResult.Rows.Add();

            DataGridViewRow result_row = dgvResult.Rows[index];
            for (int i = 0; i < arr.Length; i++)
            {
                result_row.Cells[i].Value = arr[i];
            }

            //dgvResult.Rows.Add(result_row);
        }
    }
}
