namespace SBM_Amortization
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Amortization
    {
        private InputDataAmortization input;

        public InputDataAmortization Input
        {
            get { return input; }
            set { input = value; }
        }

        public Amortization() { }

        public Amortization(InputDataAmortization input)
        {
            this.Input = input;
        }

        public List <OutputDataAmortization> calculateBalanceAndResidual()
        {
            List<OutputDataAmortization> result = null;
            if (input != null)
            {
                if (input.PercentageRate == null)
                {
                    double cbuf = (input.CurrencyRate + input.Digression) / (input.Value + input.Digression);
                    cbuf = Math.Pow(cbuf, 1.0d / input.NumberOfYears);
                    input.PercentageRate = (1 - cbuf) * 100;

                }
                else
                {
                    input.CurrencyRate = input.Value * Math.Pow(1.0d - ((double)input.PercentageRate / 100.0d), input.NumberOfYears);
                }

                double buf = (double)input.PercentageRate / 100.0d;

                //if B is not used, it is zero and is equivalent (almost) to prevRn = A
                double prevModifiedRn = input.Value + input.Digression; 

                //real value of Rn, calculated on each iteration as Rn = Rn - Dn, Dn calculated with modified parameters
                double rn = input.Value;

                result = new List<OutputDataAmortization>();

                for (uint i = 1; i <= input.NumberOfYears; i++)
                {
                    OutputDataAmortization output = new OutputDataAmortization();
                    output.NumberOfYear = i;
                    double modifiedRn = prevModifiedRn * (1 - buf);
                    output.Balance = prevModifiedRn - modifiedRn;
                    prevModifiedRn = modifiedRn;
                    output.AmortizationSum = rn - output.Balance;
                    rn = output.AmortizationSum;

                    result.Add(output);
                }

            }

            return result;
        }

        public List <OutputDataAmortization> calculateValueOfAcquisitions()
        {
            List <OutputDataAmortization> result = null;
            if (input != null)
            {
                if (input.PercentageRate == null)
                {
                    input.PercentageRate = (float)((((input.Value - input.CurrencyRate) / input.NumberOfYears) / input.Value) * 100.0d);

                }
                else
                {
                    input.CurrencyRate = input.Value - input.NumberOfYears * (input.Value * ((double)input.PercentageRate / 100.0d));
                }

                double buf = (double)input.PercentageRate / 100.0d;
                double balance = input.Value * buf;

                result = new List<OutputDataAmortization>();

                for (uint i = 1; i <= input.NumberOfYears; i++)
			    {
			        OutputDataAmortization output = new OutputDataAmortization();
                    output.NumberOfYear = i;
                    output.Balance = balance;
                    output.AmortizationSum = input.Value * (1.0d - i * buf);
                    /*if (output.AmortizationSum < -1e-10)
                    {
                        "Балансовата стойност Rn става птрицателна в година";
                        break;
                    }*/
                    result.Add(output);                   
			    }

            }

            return result;
        }
    }
}
